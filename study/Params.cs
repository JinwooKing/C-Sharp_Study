using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study
{
	public class Params
	{
		Params()
		{
			#region Params
			{
				//params
				//https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/params

				int[] arr = { 1, 2, 3, 4, 5 };
				Console.WriteLine($"Sum(arr) : {Sum(arr)}");

				int[] arr2 = Enumerable.Range(1, 1000).ToArray();
				Console.WriteLine($"Sum(arr2) : {Sum(arr2)}");

				int[] arr3 = (from x in arr2 where x % 2 == 0 select x).ToArray();
				Console.WriteLine($"Sum(arr3) : {Sum(arr3)}");

				Print(arr);
				PrintInt(arr);
                PrintInt(1);
                PrintInt(1, 2);
                PrintInt(1,2,3);
                Print(new int[] { 1, 2, 3 });
				PrintInt(new int[] { 1, 2, 3 });
				Print(new string[] { "TEST", "TEST2" });
				Print(new object[] { arr, 1, "TEST", 'A' });

				//1. 가변 인자를 받아서 합을 계산하는 함수
				int Sum(params int[] arr)
				{
					int rtnVal = 0;
					foreach (int num in arr)
					{
						rtnVal += num;
					}
					return rtnVal;
				}

				//2. 가변 인자를 받아서 출력하는 함수
				void Print(params object[] arr)
				{

					foreach (var x in arr)
					{
						Console.Write(x + " ");
					}
					Console.WriteLine();
				}

				//3. 가변 인자를 받아서 정수를 출력하는 함수
				void PrintInt(params int[] arr)
				{

					foreach (var x in arr)
					{
						Console.Write(x + " ");
					}
					Console.WriteLine();
				}
			}
			#endregion

			#region ref
			{
				//ref
				//https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/method-parameters
				//1. 값 형식을 값으로 전달
				int n = 5;
				SquareIt(n);
				Console.WriteLine($"n : {n}");

				//2. 값 형식을 참조로 전달
				int n2 = 5;
				SquareItRef(ref n2);
				Console.WriteLine($"n2 : {n2}");

				//3. 참조 형식을 값으로 전달
				int[] arr = { 2, 5 };
				Change(arr);
				Console.WriteLine($"arr[0] : {arr[0]}");

				//4. 참조 형식을 참조로 전달
				int[] arr2 = { 2, 5 };
				ChangeRef(ref arr2);
				Console.WriteLine($"arr2[0] : {arr2[0]}");

				//5. 참조 반환 값
				var bc = new BookCollection();
				ref var book = ref bc.GetBookByTitle("Call of the Wild, The");
				if (book != null)
					book = new Book { Title = "Republic, The", Author = "Plato" };
				bc.ListBooks();

				void SquareIt(int x)
				{
					x *= x;
					Console.WriteLine($"x : {x}");
				}

				void SquareItRef(ref int x)
				{
					x *= x;
					Console.WriteLine($"x : {x}");
				}

				void Change(int[] x)
				{
					x[0] = 3;
					Console.WriteLine($"x[0] : {x[0]}");
					x = new int[] { 1, 4 };
					Console.WriteLine($"x[0] : {x[0]}");
				}

				void ChangeRef(ref int[] x)
				{
					x[0] = 4;
					Console.WriteLine($"x[0] : {x[0]}");
					x = new int[] { 1, 4 };
					Console.WriteLine($"x[0] : {x[0]}");
				}
			}
			#endregion

			#region out
			{
				//out
				//https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/out-parameter-modifier
				string s = "5";
				int n;
				//1. out 인수를 사용
				int.TryParse(s, out n);
			}
			#endregion

		}
	}
	
	public class Book
	{
		public string Author;
		public string Title;
	}

	public class BookCollection
	{
		private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
						new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
					   };
		private Book nobook = null;

		public ref Book GetBookByTitle(string title)
		{
			for (int ctr = 0; ctr < books.Length; ctr++)
			{
				if (title == books[ctr].Title)
					return ref books[ctr];
			}
			return ref nobook;
		}

		public void ListBooks()
		{
			foreach (var book in books)
			{
				Console.WriteLine($"{book.Title}, by {book.Author}");
			}
			Console.WriteLine();
		}
	}
}

