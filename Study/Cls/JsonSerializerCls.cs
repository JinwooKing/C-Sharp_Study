using ConsoleAppSample.Model.Helper;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ConsoleAppSample.Study.Cls
{
    public class JsonSerializerCls
    {
        //System.Text.Json 네임스페이스
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.text.json
        public JsonSerializerCls()
        {
            //1. 옵션 설정(JsonSerializerOptions)
            var options = new JsonSerializerOptions
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

            //2. 객체 생성
            Person person = new Person()
            {
                Name = "박진우",
                Age = DateTime.Now.Year - 1994,
                Nickname = new string[] { "원빈", "장동건", "현빈" },
                Favoritefood = new List<string>() { "소고기", "돼지고기", "닭고기" },
                Birthday = DateTime.Parse("1994-08-09"),
                Employed = true
            };

            //3. 직렬화(객체를 JSON으로)
            string jsonString = JsonSerializer.Serialize(person, options);
            Console.WriteLine(jsonString);

            jsonString = @"
            {
              ""Name"": ""박진우"",
              ""Age"": 28,
              ""Nickname"": [
                ""원빈"",
                ""장동건"",
                ""현빈""
              ],
              ""Favoritefood"": [
                ""소고기"",
                ""돼지고기"",
                ""닭고기""
              ],
              ""Birthday"": ""1994-08-09T00:00:00+09:00"",
              ""Employed"": true
            }
            
            ";

            //4. 역직렬화(JSON을 객체로)
            Person Person = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine(Person.Name);
            Console.WriteLine(Person.Age);
            Console.WriteLine(Person.Nickname);
            Console.WriteLine(Person.Favoritefood);
            Console.WriteLine(Person.Birthday);
            Console.WriteLine(Person.Employed);

            //5. JsonNode (역직렬화할 클래스가 없는 경우)
            JsonNode jsonNode = JsonNode.Parse(jsonString);
            Console.WriteLine(jsonNode.ToJsonString(options));
            Console.WriteLine(jsonNode["Name"]);
            Console.WriteLine(jsonNode["Age"]);
            Console.WriteLine(jsonNode["Nickname"]);
            Console.WriteLine(jsonNode["Favoritefood"].ToJsonString(options));
            Console.WriteLine(jsonNode["Birthday"]);
            Console.WriteLine(jsonNode["Employed"]);

        }

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

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string[]? Nickname { get; set; }
        public List<string>? Favoritefood { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public bool Employed { get; set; }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
