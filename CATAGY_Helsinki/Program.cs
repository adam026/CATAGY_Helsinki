using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_Helsinki
{
    internal class Program
    {
        static List<Sportolo> sportolok = new List<Sportolo>();
        static void Main(string[] args)
        {
            Beolvasas();
            F03();
            F04();
            F05();
            F06();
            F08();
        }

        private static void F08()
        {
            var statisztika = new Dictionary<int, int>();
            foreach (var sport in sportolok)
            {
                if (!statisztika.ContainsKey(sport.ElertHelyezes))
                {
                    statisztika.Add(sport.ElertHelyezes, 1);
                }
                else
                {
                    statisztika[sport.ElertHelyezes] += 1;
                }
            }


            var eredmeny = sportolok.Where(x => x.ElertHelyezes == statisztika.Keys.First()).OrderBy(y => y.SportoloSzama).Last();
            Console.WriteLine($"8. Feladat:\n\tHelyezés: {eredmeny.ElertHelyezes}\n\tSportág: {eredmeny.SportagNeve}\n\tVersenyszám: {eredmeny.VersenyszamNeve}\n\tSportolók száma: {eredmeny.SportoloSzama}");
        }

        private static void F06()
        {
            var torna = 0;
            var uszas = 0;

            foreach (var sportag in sportolok)
            {
                if (sportag.SportagNeve == "torna")
                {
                    torna++;
                }
                else if (sportag.SportagNeve == "uszas")
                {
                    uszas++;
                }
            }
            Console.Write("6. Feladat: ");
            if (torna > uszas)
            {
                Console.WriteLine("Torna sportágban szereztek több érmet");
            }
            else if (torna == uszas)
            {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }
            else
            {
                Console.WriteLine("Úszás sportágban szereztek több érmet");
            }
        }

        private static void F05()
        {
            var olimpiaiPontok = 0;
            foreach (var sportolo in sportolok)
            {
                switch (sportolo.ElertHelyezes)
                {
                    case (1):
                        olimpiaiPontok += 7;
                        break;
                    case (2):
                        olimpiaiPontok += 5;
                        break;
                    case (3):
                        olimpiaiPontok += 4;
                        break;
                    case (4):
                        olimpiaiPontok += 3;
                        break;
                    case (5):
                        olimpiaiPontok += 2;
                        break;
                    case (6):
                        olimpiaiPontok += 1;
                        break;
                }
            }

            Console.WriteLine($"5. Feladat: Olimpiai pontok száma: {olimpiaiPontok}");
        }

        private static void F04()
        {
            var arany = 0;
            var ezust = 0;
            var bronz = 0;
            foreach (var sportolo in sportolok)
            {
                if (sportolo.ElertHelyezes == 1)
                {
                    arany++;
                }
                else if (sportolo.ElertHelyezes == 2)
                {
                    ezust++;
                }
                else if (sportolo.ElertHelyezes == 3)
                {
                    bronz++;
                }
            }

            Console.WriteLine($"4. Feladat:\n\tArany: {arany}\n\tEzüst: {ezust}\n\tBronz: {bronz}\n\tÖsszesen: {arany + ezust + bronz}");

        }

        private static void F03()
        {
            var pontszerzok = sportolok.Where(x => x.ElertHelyezes > 0).Count();
            Console.WriteLine($"3. Feladat: Pontszerző helyezések száma: {pontszerzok}");
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"..\..\RES\helsinki.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    sportolok.Add(new Sportolo(sr.ReadLine()));
                }
            }
        }
    }
}
