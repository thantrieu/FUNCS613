/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.22</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary> 

using System;
using System.Text;

namespace ExercisesLesson611
{
    class Exercises5
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string input = "đây là xâu kí tự test interface chỉ định các hành động cần thực hiện với xâu kí tự";
            IStringUtils stringUtils = new StringUtils();
            Console.WriteLine("Số từ có trong xâu input: " + stringUtils.CountWords(input));
            Console.WriteLine("Các từ: ");
            ShowWords(stringUtils.Split(input));
            Console.WriteLine("Các từ dài nhất: ");
            var longestWords = stringUtils.FindMaxWords(input);
            ShowWords(longestWords);
            var shortestWords = stringUtils.FindMinWords(input);
            Console.WriteLine("Các từ ngắn nhất: ");
            ShowWords(shortestWords);

            Console.WriteLine("Chuỗi kí tự sau viết hoa: " + stringUtils.UpperCase(input));
            Console.WriteLine("Xâu kí tự sau sắp xếp a-z: ");
            var words = stringUtils.Split(input);
            stringUtils.SortASC(words);
            ShowWords(words);
            stringUtils.SortByLength(words);
            Console.WriteLine("Xâu kí tự sau sắp xếp theo độ dài từ: ");
            ShowWords(words);
            Console.WriteLine("Các từ sau khi đảo vị trí: " + stringUtils.Reverse(input));

            Console.WriteLine("Nhập kí tự đầu từ cần tìm: ");
            var key = Console.ReadLine()[0];
            Console.WriteLine("Kết quả tìm kiếm: ");
            ShowWords(stringUtils.StartWith(input, key));
        }

        private static void ShowWords(string[] words)
        {
            foreach (var item in words)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n---------------------------------------------------------");
        }
    }

    // interface chỉ định các hành động cần thực hiện với xâu kí tự
    interface IStringUtils
    {
        string[] Split(string input);
        int CountWords(string input);
        string UpperCase(string input);
        void SortASC(string[] input);
        void SortByLength(string[] input);
        string[] StartWith(string input, char key);
        string[] FindMaxWords(string input);
        string[] FindMinWords(string input);
        string Reverse(string input);
    }

    // lớp cha triển khai nửa vời interface
    class BaseStringUtils : IStringUtils
    {
        public virtual int CountWords(string input)
        {
            throw new NotImplementedException();
        }

        public virtual string[] FindMaxWords(string input)
        {
            throw new NotImplementedException();
        }

        public virtual string[] FindMinWords(string input)
        {
            throw new NotImplementedException();
        }

        public virtual string Reverse(string input)
        {
            throw new NotImplementedException();
        }

        public virtual void SortASC(string[] input)
        {
            throw new NotImplementedException();
        }

        public virtual void SortByLength(string[] input)
        {
            throw new NotImplementedException();
        }

        public virtual string[] Split(string input)
        {
            throw new NotImplementedException();
        }

        public virtual string[] StartWith(string input, char key)
        {
            throw new NotImplementedException();
        }

        public virtual string UpperCase(string input)
        {
            throw new NotImplementedException();
        }
    }

    class StringUtils : BaseStringUtils
    {
        public override int CountWords(string input)
        {
            return Split(input).Length;
        }

        public override string[] FindMaxWords(string input)
        {
            var result = new string[input.Length];
            int counter = 0;
            var words = Split(input);
            var maxLength = FindMaxLength(words);
            foreach (var item in words)
            {
                if (item.Length == maxLength)
                {
                    result[counter++] = item;
                }
            }
            var ret = new string[counter];
            Array.Copy(result, ret, counter);
            return ret;
        }

        // tìm độ dài lớn nhất của các từ trong danh sách
        private int FindMaxLength(string[] words)
        {
            int maxLength = 0;
            foreach (var word in words)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                }
            }
            return maxLength;
        }

        public override string[] FindMinWords(string input)
        {
            var result = new string[input.Length];
            int counter = 0;
            var words = Split(input);
            var minLength = FindMinLength(words);
            foreach (var item in words)
            {
                if (item.Length == minLength)
                {
                    result[counter++] = item;
                }
            }
            var ret = new string[counter];
            Array.Copy(result, ret, counter);
            return ret;
        }

        private int FindMinLength(string[] words)
        {
            int minLength = 0;
            foreach (var word in words)
            {
                if (word.Length < minLength)
                {
                    minLength = word.Length;
                }
            }
            return minLength;
        }

        public override string Reverse(string input)
        {
            var words = Split(input);
            Array.Reverse(words);
            StringBuilder sb = new StringBuilder();
            foreach (var item in words)
            {
                sb.Append(item + " ");
            }
            return sb.ToString().Trim();
        }

        public override void SortASC(string[] input)
        {
            Array.Sort(input);
        }

        public override void SortByLength(string[] input)
        {
            int comparer(string a, string b)
            {
                if (a == null && b == null)
                {
                    return 0;
                }
                else if (a == null && b != null)
                {
                    return 1;
                }
                else if (a != null && b == null)
                {
                    return -1;
                }
                else
                {
                    return a.Length - b.Length;
                }
            }
            Array.Sort(input, comparer);
        }

        public override string[] Split(string input)
        {
            var result = input.Split(new char[] { '\n', ' ', '\t', '.', '?', ';', ':', '!', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        public override string[] StartWith(string input, char key)
        {
            var words = Split(input);
            int index = 0;
            var result = new string[words.Length];
            foreach (var item in words)
            {
                if (item != null && item[0] == key)
                    result[index++] = item;
            }
            // tạo mảng kết quả trả về chứa các từ tìm được
            var ret = new string[index];
            Array.Copy(result, 0, ret, 0, index);
            return ret;
        }

        public override string UpperCase(string input)
        {
            var words = Split(input);
            var result = new StringBuilder();
            foreach (var item in words)
            {
                result.Append($"{item[0]}".ToUpper() + item.Substring(1));
                result.Append(" ");
            }
            return result.ToString().TrimEnd();
        }
    }
}
