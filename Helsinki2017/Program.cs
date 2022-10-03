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
        public string Technikai { get; private set; }
        public string Komponens { get; private set; }
        public int Levonas { get; private set; }
        public adat(string sor)
        {
            string[] elemek = sor.Split(';');
            Nev = elemek[0];
            Orszag = elemek[1];
            Technikai = elemek[2];
            Komponens = elemek[3];
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
                donto.Add(new adat(sor));
            }
            foreach (var sor in File.ReadAllLines("donto.csv").Skip(1))
            {
                donto.Add(new adat(sor));
            }
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"Elindult versenyzők száma: {rovidprogram.Count()}");
            Console.WriteLine("3.Feladat");

            Console.ReadKey();
        }
    }
}
