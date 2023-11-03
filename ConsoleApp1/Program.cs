using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Text
{
    class Person
    {
        public string Name { get; set; } = null;
        public string Age { get; set; } = null;
        public string Email { get; set; } = null;

    }
    class Program
    {
        static void WriteToCsv(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }

                }


                List<Person> people = new()
            {
            new(){Name = "Tung", Age ="34", Email = "tungbinhdinh89@gmail.com"},
            new(){Name = "Quang", Age ="31", Email = "tungbinhdinh89@gmail.com"},
            new(){Name = "Nguyen", Age ="4", Email = "tungbinhdinh89@gmail.com"},
            new(){Name = "Tuyen", Age ="31", Email = "tungbinhdinh89@gmail.com"},
            };

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

        static void Main(string[] args)
        {

            var dictionaryPath = "D:\\share\\";
            var fileName = "data.csv";
            var filePath = Path.Combine(dictionaryPath, fileName);
            //string combinedString = string.Join(Environment.NewLine, people.ToString());
            //File.WriteAllText(path, combinedString);
            //Console.WriteLine(combinedString);
            WriteToCsv(filePath);

            Console.ReadKey();


        }
    }
}