using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace megoldasok
{

    public class Autok
    {
        public int sorszam { get; set; }
        public string marka { get; set; }
        public string modell { get; set; }
        public int gyartasi_ev { get; set; }
        public string szin {  get; set; }
        public int eladott_db {  get; set; }
        public int atlag_eladas { get; set; }

        public Autok(string sor)
        {
            var adatok = sor.Split(';');
            sorszam = int.Parse(adatok[0]);
            marka =  adatok[1];
            modell = adatok[2];
            gyartasi_ev = int.Parse(adatok[3]);
            szin = adatok[4];
            eladott_db = int.Parse(adatok[5]);
            atlag_eladas = int.Parse(adatok[6]);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] sorok = File.ReadAllLines("autok.txt");
            List<Autok> autok = new List<Autok>();
            foreach (var sor in sorok.Skip(1))
            {
                Autok auto = new Autok(sor);
                autok.Add(auto);
            }

            int auto_szam = autok.Count();
            Console.WriteLine(auto_szam);

            int legregebbi = autok.Min(auto => auto.gyartasi_ev); // legkorábbi gyártási év

            Console.WriteLine(legregebbi); // legkorábbi gyártási év autó adatai

            var zoldautok = autok.FindAll(auto => auto.szin == "Zöld");

            foreach (var auto in zoldautok)
            { Console.WriteLine($"{auto.marka} {auto.modell} {auto.szin}"); }
        }
    }
}
