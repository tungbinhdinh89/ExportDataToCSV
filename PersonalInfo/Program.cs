using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PersonalInfo

{
    class Person
    {
        public string Name { get; set; } = null;
        public string Age { get; set; } = null;
        public string Email { get; set; } = null;

    }
    public class Program
    {
        static string UserName { get; set; }
        static string UserAge { get; set; }
        static string UserEmail { get; set; }
        static List<Person> people = new();
        static void Main(string[] args)
        {
            string userInput;

            do
            {
                Console.Write("Nhap so luong: ");
                userInput = Console.ReadLine();
            }
            while (!userInput.All(char.IsDigit) || string.IsNullOrEmpty(userInput));

            ConsoleWriteLine();
            bool isParseNumber = int.TryParse(userInput, out int number);

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Thong tin thu {i + 1} ");
                InputUserInfo();
                ConsoleWriteLine();
            };

            string path;
            do
            {
                Console.Write("Input Your Directory Path: ");
                path = Console.ReadLine();
            }
            while (!Path.Exists(path));

            var fileName = "output.csv";
            var filePath = Path.Combine(path, fileName);
            WriteToCsv(filePath);

            Console.ReadKey();
        }

        static void ConsoleWriteLine()
        {
            Console.WriteLine("----------------------------------------------------");
        }

        static bool ValidateEmail(string email)
        {
            Regex rx = new Regex(
    @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }

        static void InputUserInfo()
        {
            do
            {
                Console.Write("Ten: ");
                UserName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(UserName));

            do
            {
                Console.Write("Tuoi: ");
                UserAge = Console.ReadLine();
            }
            while (!UserAge.All(char.IsDigit) || string.IsNullOrEmpty(UserAge));

            do
            {
                Console.Write("Email: ");
                UserEmail = Console.ReadLine();
            }
            while (!ValidateEmail(UserEmail));
            Person AddPeople = new Person();
            AddPeople.Name = UserName;
            AddPeople.Age = UserAge;
            AddPeople.Email = UserEmail;
            people.Add(AddPeople);
        }

        static void WriteToCsv(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }

                }


                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, configPersons))
                {
                    csvWriter.WriteRecords(people);
                }

                Console.WriteLine("Data written to CSV successfully");
            }
            catch (Exception ex)
            {
                throw;
            };
        }
    }
}