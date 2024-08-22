using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ConsoleAppSample.Model.Helper
{
    /// <summary>
    /// 변환할 클래스가 있으면 <T> 없으면 JsonNode 사용
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonHelper<T>
    {
        //옵션
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            // Encoder: JSON 문자열 인코딩에 사용할 인코더를 설정합니다.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            // WriteIndented: JSON을 들여쓰기하여 가독성을 높입니다.
            WriteIndented = true,
            // DefaultIgnoreCondition: null 값이 있는 속성을 직렬화할 때 무시하는 기본 동작을 설정합니다.
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            // MaxDepth: 직렬화할 수 있는 개체의 최대 깊이를 설정합니다. 너무 깊은 개체는 예외를 발생시킬 수 있습니다.
            MaxDepth = 8,
            // ReferenceHandler: 개체 참조를 유지하기 위해 참조 처리기를 설정합니다. 이렇게 하면 참조 루프가 발생할 수 있습니다.
            ReferenceHandler = ReferenceHandler.Preserve,
            // ReadCommentHandling: JSON 데이터에서 주석을 처리하는 방법을 설정합니다. 여기서는 주석을 건너뜁니다.
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        public JsonSerializerOptions GetOption() => options;

        /// <summary>
        /// 직렬화(객체를 JsonString으로)
        /// option = true, 들여쓰기 등등
        /// </summary>
        /// <param name="value"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public string Serialize(T value, bool option = true) => option ? JsonSerializer.Serialize(value, options) : JsonSerializer.Serialize(value);

        /// <summary>
        /// 역직렬화(JsonString을 객체로)
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public T Deserialize(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, options);

        /// <summary>
        /// JsonNode 역직렬화 (역직렬화할 클래스가 없는 경우)
        /// jsonNode.ToJsonString(options); // 문자열 전체
        /// jsonNode["prop"]; // 값
        /// jsonNode["Array"].ToJsonString(options); // 배열
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public JsonNode JsonNodeDeserialize(string jsonString) => JsonNode.Parse(jsonString);

        /// <summary>
        /// JSON 파일을 읽고, JsonDocument에 데이터를 로드하고, 서식 있는(보기 좋게 출력된) JSON을 파일에 씁니다.
        /// </summary>
        /// <param name="sourceFileName"></param>
        public static void ReadJsonFileAndWriteJsonFile(string sourceFileName)
        {
            string destFileName = FileHelper.GetUniqueFileName(sourceFileName);

            string jsonString = File.ReadAllText(sourceFileName);

            var writerOptions = new JsonWriterOptions
            {
                Indented = true
            };

            var documentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            };

            using FileStream fs = File.Create(destFileName);
            using var writer = new Utf8JsonWriter(fs, options: writerOptions);
            using JsonDocument document = JsonDocument.Parse(jsonString, documentOptions);

            JsonElement root = document.RootElement;

            //1. Json 종류 Object
            if (root.ValueKind == JsonValueKind.Object)
            {
                writer.WriteStartObject();
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    property.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            //2. Json 종류 Array
            else if (root.ValueKind == JsonValueKind.Array)
            {
                writer.WriteStartArray();
                foreach (JsonElement array in root.EnumerateArray())
                {
                    writer.WriteStartObject();
                    foreach (JsonProperty property in array.EnumerateObject())
                    {
                        property.WriteTo(writer);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            //3. 해당 없음
            else
            {
                return;
            }

            writer.Flush();
        }
    }
}
