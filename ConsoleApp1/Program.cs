using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Szine { Zold, Rozsaszin, Feher, Lila, Fekete }
    enum Neme { Fiu, Lany}
    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }
        public Szine Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year-SzuletesiDatum.Year;
        public Neme Neme { get; set; }

        public override string ToString()
        {
            return $"{ID,-5}|{Neve,-10}|{Szine,-9}|{SzuletesiDatum.ToString("yyy.MM.dd"),-10}|{Suly,-5}|{Kor,-5}|{Neme}\n_________________________________________________________";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    ID=1,
                    Neme=Neme.Fiu,
                    Neve="Megatron",
                    Suly=10,
                    Szine=Szine.Fekete,
                    SzuletesiDatum=new DateTime(2018,08,13),
                },
                new Cica()
                {
                    ID=2,
                    Neme=Neme.Lany,
                    Neve="Pizsama",
                    Suly=4,
                    Szine=Szine.Rozsaszin,
                    SzuletesiDatum=new DateTime(2022,12,20),
                },
                new Cica()
                {
                    ID=3,
                    Neme=Neme.Fiu,
                    Neve="KFC",
                    Suly=14,
                    Szine=Szine.Zold,
                    SzuletesiDatum=new DateTime(2017,06,20),
                },
                new Cica()
                {
                    ID=4,
                    Neme=Neme.Lany,
                    Neve="Korcs",
                    Suly=9,
                    Szine=Szine.Lila,
                    SzuletesiDatum=new DateTime(2019,03,15),
                },
                new Cica()
                {
                    ID=5,
                    Neme=Neme.Fiu,
                    Neve="Zacskosleves",
                    Suly=7,
                    Szine=Szine.Feher,
                    SzuletesiDatum=new DateTime(2020,02,05),
                },
            };

            Cica elsoCica = cicak.First();
            Console.WriteLine(elsoCica);

            Cica ucsoCica = cicak.Last();
            Console.WriteLine(ucsoCica);

            // össz suly
            int osszSuly = cicak.Sum(x => x.Suly);
            Console.WriteLine($"Össz súly: {osszSuly} kg\n_________________________________________________________");

            double atlagEletkor = cicak.Average(x => x.Kor);
            Console.WriteLine($"Átlag életkor: {atlagEletkor:0.00}\n_________________________________________________________");

            int lanyDb = cicak.Count(x => x.Neme == Neme.Lany);
            Console.WriteLine($"Össz lánymacska: {lanyDb}\n_________________________________________________________");

            int fiuDb = cicak.Count(x => x.Neme == Neme.Fiu);
            Console.WriteLine($"Össz fiúmacska: {fiuDb}\n_________________________________________________________");

            int kicsiMacska = cicak.Min(x => x.Suly);
            Console.WriteLine($"Legkevesebb kiló macska: {kicsiMacska}\n_________________________________________________________");

            cicak.Where(x => x.Kor >= 3).ToList().ForEach(x => Console.WriteLine(x.Neve));

            cicak.Where(x => x.Szine == Szine.Fekete).ToList().ForEach(x => Console.WriteLine(x.Neve));
            Console.ReadKey();
        }
    }
}
