using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAMK.IT;

namespace JAMK.IT
{
    public static class Varasto
    {


        public static List<string> Resepti(List<Reseptit> nimet)
        {
            List<string> resepti = new List<string>();
            foreach (var item in nimet)
            {
                if (!resepti.Contains(item.Nimi))
                {
                    resepti.Add(item.Nimi);
                }
            }
            return resepti;
        }


            public static List<string> Mittayksikot(List<Aineet> yksikot)
        {
            List<string> mitat = new List<string>();
            foreach (var item in yksikot)
            {
                if (!mitat.Contains(item.Mittayksikko))
                {
                    mitat.Add(item.Mittayksikko);
                }
            }
            return mitat;
        }

        public static string Yksikot;
    
    }


    public static class Ainelistat
    {
        public static List<string> Ainelista(List<Aineet> ainelista)
        {
            List<string> listat = new List<string>();
            foreach (var item in ainelista)
            {
                if (!listat.Contains(item.Nimi))
                {
                    listat.Add(item.Nimi);
                }
            }
            return listat;
        }
    }
    public class Aineet
    {
        public int AineID { get; set; }
        public string Nimi { get; set; }
        public string ParastaEnnen { get; set; }
        public float Maara { get; set; }
        public string Mittayksikko { get; set; }
        
    }

    public class Reseptit
    {
        public int ReseptiID { get; set; }
        public string Nimi { get; set; }
        public string Ohje { get; set; }
        public int Valmistusaika { get; set; }
        public string Haaste { get; set; }
        
    }
}
