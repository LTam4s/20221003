using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class adat
    {
        public string Nev { get; private set; }
        public string Orszag { get; private set; }
        public float Technikai { get; private set; }
        public float Komponens { get; private set; }
        public int Levonas { get; private set; }
        public adat(string sor)
        {
            string[] elemek = sor.Split(';');
            Nev = elemek[0];
            Orszag = elemek[1];
            Technikai = float.Parse(elemek[2].Replace(".",","));
            Komponens = float.Parse(elemek[3].Replace(".", ","));
            Levonas = int.Parse(elemek[4]); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<adat> rovidprogram = new List<adat>();
            List<adat> donto = new List<adat>();
            foreach (var sor in File.ReadAllLines("rovidprogram.csv").Skip(1))
            {
                rovidprogram.Add(new adat(sor));
            }
            foreach (var sor in File.ReadAllLines("donto.csv").Skip(1))
            {
                donto.Add(new adat(sor));
            }
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"Elindult versenyzők száma: {rovidprogram.Count()}");
            Console.WriteLine("\n3.Feladat");
            for (int i = 0; i < donto.Count(); i++)
            {
                if (donto[i].Orszag == "HUN")
                {
                    Console.WriteLine("A magyar versenyző bejutott a döntőbe!");
                }
            }
            bool nevek = true;
            string nev;
            float osszpontszam = 0;
            Console.WriteLine("\n5.Feladat");
            do
            {
                Console.Write("Kérem a versenyző nevét: ");
            nev = Console.ReadLine();

                for (int i = 0; i < rovidprogram.Count(); i++)
                {
                    if (nev == rovidprogram[i].Nev)
                    {
                        nevek = false;
                        osszpontszam = rovidprogram[i].Technikai + rovidprogram[i].Komponens - rovidprogram[i].Levonas;
                        break;
                    }
                    else
                    {
                        nevek = true;
                    }
                }
                if (nevek)
                {
                    Console.WriteLine("Ilyen nevű indulő nem volt!");
                }
            } while (nevek);
            Console.WriteLine("\n6.Feladat");
            Console.WriteLine($"A versenyző összpontszáma: {osszpontszam}");
            Console.ReadKey();
        }
    }
}
