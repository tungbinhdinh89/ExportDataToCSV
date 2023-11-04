using System.Text;
using System;

namespace QuangDo

{
    class Person
    {
        public string Name { get; set; } = null;
        public string Age { get; set; } = null;
        public string Email { get; set; } = null;

    }

    public class Program
    {
        record Person(string Name, int Age, string Email);

        static void Main(string[] args)
        {
            

            bool valid;
            int count;
            do
            {
                Console.Write("Nhap so luong: ");
                valid = int.TryParse(Console.ReadLine(), out count);
            } while (!valid);

            var people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine + "---------------------");
                Console.WriteLine($"Thong tin thu {i}");
                Console.Write("Ten: ");
                var name = Console.ReadLine();
                //Console.WriteLine();

                int age = 0;
                do
                {
                    Console.Write("Tuoi: ");
                    int.TryParse(Console.ReadLine(), out age);

                } while (age <= 0);

                //Console.WriteLine();
                Console.Write("Email: ");
                var email = Console.ReadLine();


                people.Add(new(name, age, email));
            }
            WriteCsv(people);

            void WriteCsv(List<Person> people)
            {
                StringBuilder sb = new();
                sb.AppendLine("Name,Age,Email");
                foreach (var p in people)
                {
                    sb.AppendLine($"{p.Name},{p.Age},{p.Email}");
                }

                var name = $"output-{Guid.NewGuid()}.csv";
                File.WriteAllText(name, sb.ToString());
                var fullpath = Path.GetFullPath(name);
                Console.WriteLine(Environment.NewLine + $"File was saved to '{fullpath}'" + Environment.NewLine);
            }

        }
    }
}