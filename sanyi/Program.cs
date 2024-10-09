using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sanyi
{
    enum szinek { zold,fekete,piros}
    enum neme { fiu,lany}

    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }
        public szinek Szine { get; set; }
        public DateTime Datum { get; set; }
        public neme Neme { get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year - Datum.Year;

        public override string ToString()
        {
            return $"{ID,-5 }{Neve,-10} {Szine,-10} {Datum.ToString("yy.mm.dd"), -5} {Neme,-10} {Suly, -5} {Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>
            {
                new Cica()
                {
                    ID = 1,
                    Neve = "Sanyi",
                    Suly = 10,
                    Szine = szinek.fekete,
                    Neme=neme.fiu,
                    Datum = new DateTime(2022,04,17)
                },
                new Cica()
                {
                    ID = 2,
                    Neve = "Kolompar",
                    Suly = 15,
                    Szine = szinek.piros,
                    Neme=neme.fiu,
                    Datum = new DateTime(2020,05,19)
                },
                new Cica()
                {
                    ID = 1,
                    Neve = "Laca",
                    Suly = 5,
                    Szine = szinek.fekete,
                    Neme=neme.lany,
                    Datum = new DateTime(2019,01,25)
                },
            };
            Cica uj = cicak.First();
            Console.WriteLine(uj);

            

            Cica utolso = cicak.Last();
            Console.WriteLine(utolso);

            int osszsuly = cicak.Sum(x => x.Suly);
            Console.WriteLine($"ossz suly: {osszsuly}");

            double atlag = cicak.Average(x => x.Kor);
            Console.WriteLine($"atlag kor: {atlag:0.00}");

            int lanydb = cicak.Count(x => x.Neme == neme.lany);
            Console.WriteLine($"lany db: {lanydb}");

            int minsuly = cicak.Min(x => x.Suly);
            Console.WriteLine($"min suly: {minsuly}");

            cicak.Where(x => x.Kor > 3).ToList().ForEach(x => Console.WriteLine(x.Neve));
            cicak.Where(x => x.Szine == szinek.fekete).ToList().ForEach(x => Console.WriteLine(x.Neve));

            Console.ReadKey();

        }
    }
}
