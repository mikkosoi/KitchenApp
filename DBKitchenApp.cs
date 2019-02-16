using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using JAMK.IT;
using System.Diagnostics;
using System.Globalization;
using KitchenApp;

namespace JAMK.IT
{
    public class DB
    {
        public static List<Aineet> GetAineet()
        {
            // Haetaan tiedot SQL-palvelimelta
            try
            {
                List<Aineet> aineet = new List<Aineet>();

                // määritellään yhteysmerkkijono
                string cs = GetMysqlConnectionString();
                // sql-kysely
                string sql = "SELECT nimi, parastaennen, maara, mittayksikko FROM AINEET ORDER BY nimi";  // TODO muokkaa sopiva sql lause
                // luodanaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))  // HUOM! using sulkee tietokantayhteyden sulkujen lopussa (ei tarvita conn.Close()
                {
                    conn.Open();
                    // suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        // käydään tulokset läpi ja muutetaan kukin tietue (row / rivi) Aineet-olioksi
                        while (rdr.Read())
                        {
                            Aineet a = new Aineet();

                            var pe = rdr.GetDateTime(1);
                            var date = pe.Date;             // nyt ParastaEnnen muututtetu string-tyyppiseksi, ei enää DateTime
                            a.Nimi = rdr.GetString(0);
                            //   a.ParastaEnnen = rdr.GetDateTime(1);
                            a.ParastaEnnen = date.ToString("dd.MM.yyyy");
                            a.Maara = rdr.GetFloat(2);
                            a.Mittayksikko = rdr.GetString(3);
                            aineet.Add(a);
                        }
                    }
                }
                // palautus
                return aineet;
            }
            catch
            {
                throw;
            }
        }

        public static List<Reseptit> GetReseptit()
        {
            try
            {
                List<Reseptit> resepti = new List<Reseptit>();
                string cs = GetMysqlConnectionString();
                string sql = "SELECT nimi, valmistusaika, haaste FROM RESEPTIT ORDER BY nimi";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Reseptit a = new Reseptit();
                            a.Nimi = rdr.GetString(0);
                            a.Valmistusaika = rdr.GetInt32(1);
                            a.Haaste = rdr.GetString(2);
                            resepti.Add(a);
                        }
                    }
                }
                return resepti;
            }
            catch
            {
                throw;
            }
        }
        public static List<Aineet> GetReseptiAineet(string reseptinimi)
        {
            try
            {
                List<Aineet> reseptiaineet = new List<Aineet>();
                string cs = GetMysqlConnectionString();
                string sql = "select AINEET.nimi, OHJEET.maara, OHJEET.mittayksikko from OHJEET, AINEET, RESEPTIT where OHJEET.Resepti_ID = RESEPTIT.Resepti_ID and OHJEET.Aine_ID = AINEET.Aine_ID and RESEPTIT.nimi = '" + reseptinimi + "'";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Aineet a = new Aineet();
                            a.Nimi = rdr.GetString(0);
                            a.Maara = rdr.GetFloat(1);
                            a.Mittayksikko = rdr.GetString(2);
                            reseptiaineet.Add(a);
                        }
                    }
                }
                return reseptiaineet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Aineet> GetPuutteet(string reseptinimi)   //listaa reseptin ja varastossa olevien aineiden väliset erot jos niitä on 
        {                                                                   
            try
            {
                List<Aineet> puutteet = new List<Aineet>();
                string cs = GetMysqlConnectionString();
                string sql = "select AINEET.nimi, (OHJEET.Maara - AINEET.maara) AS erotus, AINEET.mittayksikko from OHJEET, AINEET, RESEPTIT where OHJEET.Resepti_ID = RESEPTIT.Resepti_ID and OHJEET.Aine_ID = AINEET.Aine_ID and RESEPTIT.nimi = '" + reseptinimi+"' and  AINEET.maara < OHJEET.Maara;";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Aineet a = new Aineet();
                            a.Nimi = rdr.GetString(0);
                            a.Maara = rdr.GetFloat(1);
                            a.Mittayksikko = rdr.GetString(2);
                            puutteet.Add(a);
                        }
                    }
                }
                return puutteet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Reseptiohjeet(string reseptinimi)  //Haetaan pelkkä reseptin ohje 
        {
            try
            {
                string ohjeet = "";
                string cs = GetMysqlConnectionString();
                string sql = "SELECT ohje FROM RESEPTIT WHERE RESEPTIT.nimi = '" + reseptinimi + "'"; 
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())

                        while (rdr.Read())
                        {
                            ohjeet = rdr.GetString(0);
                        }
                }
                return ohjeet;
            }
            catch
            {
                throw;
            }
        }
        public static string Yksikot(string reseptinimi)  // pelkkien yksiköiden listaus
        {
            try
            {
                string yksikot = "";
                string cs = GetMysqlConnectionString();
                string sql = "SELECT mittayksikko FROM AINEET WHERE nimi = '" + reseptinimi + "'";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())

                        while (rdr.Read())
                        {
                            yksikot = rdr.GetString(0);
                        }
                }
                return yksikot;
            }
            catch 
            {
                throw;
            }
        }

        public static List<Aineet> GetOstoslista()
        {
            try
            {
                List<Aineet> aineet = new List<Aineet>();
                string cs = GetMysqlConnectionString();
                string sql = "SELECT Aine_ID, Nimi, Maara, Yksikko FROM OSTOSLISTA";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Aineet a = new Aineet();
                            a.AineID = rdr.GetInt32(0);
                            a.Nimi = rdr.GetString(1);
                            a.Maara = rdr.GetFloat(2);
                            a.Mittayksikko = rdr.GetString(3);
                            aineet.Add(a);
                        }
                    }
                }
                return aineet;
            }
            catch
            {
                throw;
            }
        }


        public static bool LisaaAineita(Aineet aine)  // Lisätään uusi aine tietokantaan
        {
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");  // Tätä tarvitaan pilkun muuttamiseksi pisteeksi
            string test = aine.Maara.ToString(new CultureInfo("en-US"));                                                // SQL ei ota vastaan pilkkuerotinta joten se täytyy muuttaa pisteeksi.
            decimal testi = Convert.ToDecimal(test);                                            // Muutetaan tuhaterotinta
            test = testi.ToString(new CultureInfo("en-US"));                                    // Vaihdetaan pilkku pisteeksi CultureInfon avulla
            string cs = GetMysqlConnectionString();
            string sql = string.Format("INSERT INTO AINEET (nimi, maara, parastaennen, mittayksikko) VALUES (@0,@1,@2,@3)"); //SQL-injektion esto @-merkeillä
      
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@0", aine.Nimi); //SQL-injektion esto @-merkeillä
                cmd.Parameters.AddWithValue("@1", test);
                cmd.Parameters.AddWithValue("@2", aine.ParastaEnnen);
                cmd.Parameters.AddWithValue("@3", aine.Mittayksikko);

                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }

        public static bool LisaaOstoslistaan(Aineet aine)   // Tuotteen lisäys ostoslistalle
        {
            bool match = false;
            Aineet a = new Aineet();

            List<Aineet> lista = DB.GetOstoslista();

            if (lista != null)
            { 
                foreach (var item in lista) // käydään ostoslista läpi
                {

                    a = (Aineet)item;
                    if (a.Nimi == aine.Nimi) // verrataan ostoslistan nimiä lisättävän olion nimeen
                    {
                        match = true;
                        break;
                    }
                }
             }
                if (!match)
                    {

                        System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");  // vastaava muutos kts. LisaaAineita metodista selite
                        string test = aine.Maara.ToString();
                        decimal testi = Convert.ToDecimal(test);
                        test = testi.ToString(new CultureInfo("en-US"));
                        string cs = GetMysqlConnectionString();
                        string sql = string.Format("INSERT INTO OSTOSLISTA (Nimi, Maara, Yksikko) VALUES (@0,@1,@2)"); //SQL-injektion esto @-merkeillä
                        using (MySqlConnection conn = new MySqlConnection(cs))
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@0", aine.Nimi); //SQL-injektion esto 
                            cmd.Parameters.AddWithValue("@1", test);
                            cmd.Parameters.AddWithValue("@2", aine.Mittayksikko);
                            int lkm = cmd.ExecuteNonQuery();
                            if (lkm == 1)
                                return true;
                            else
                                return false;
                        }                  

                }
                    else //jos nimi löytyi ostoslistalta, päivitetään sen määrää
                    {
                    
                        string cs = GetMysqlConnectionString();
                        string sql = "UPDATE OSTOSLISTA SET maara = maara +'" + aine.Maara + "' where nimi = '" + aine.Nimi + "'"; 
                        using (MySqlConnection conn = new MySqlConnection(cs))
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            int lkm = cmd.ExecuteNonQuery();
                            if (lkm == 1)
                                return true;
                            else
                                return false;
                        }
                    }      
        } 
        public static bool PoistaOstoslistasta(int aineid)  // Tuotteen poisto ostoslistasta
        {
           
            string cs = GetMysqlConnectionString();
            string sql = "delete from OSTOSLISTA where Aine_ID = '" + aineid + "'";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }
        public static bool PoistaKaikkiOstoslistasta()  // Poista kaikki tuotteet ostoslistasta
        {

            string cs = GetMysqlConnectionString();
            string sql = "delete from OSTOSLISTA where Aine_ID > 0";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }

        public static bool MuokkaaAineita(string nimi, float maara)  //Aineiden varastosaldon muokkaus, alle nollan meno estetty mySQL:n puolella triggerissä
        {
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
            string test = maara.ToString();
            decimal testi = Convert.ToDecimal(test);
            test = testi.ToString(new CultureInfo("en-US"));

            string cs = GetMysqlConnectionString();
            string sql = "UPDATE AINEET SET maara = maara +'" + test + "' where nimi = '" + nimi + "'";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }
        public static bool PoistaAineita(string nimi)
        {
            string cs = GetMysqlConnectionString();
            string sql = "DELETE FROM AINEET where nimi = '" + nimi + "'";  //Poistaa tällä hetkellä kaikki saman nimiset listasta, pitäisi välittää olio josta aine_id:n perusteella poisto
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }

        public static bool LisaaResepti(Reseptit reseptit, List<Aineet> L)
        {
            bool b = false;  
            bool c = false;
            string cs = GetMysqlConnectionString();
            string sql = string.Format("INSERT INTO RESEPTIT (Nimi, Haaste, Valmistusaika, Ohje) VALUES (@0,@1,@2,@3)");
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@0", reseptit.Nimi); //SQL-injektion esto 
                cmd.Parameters.AddWithValue("@1", reseptit.Haaste);
                cmd.Parameters.AddWithValue("@2", reseptit.Valmistusaika);
                cmd.Parameters.AddWithValue("@3", reseptit.Ohje);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                     b = true;
                else
                    b = false;
            }
            Aineet a = new Aineet();
            foreach (var item in L)
            {
                a = (Aineet)item;
                string mysql = string.Format("INSERT INTO OHJEET (Resepti_ID, Aine_ID, maara, mittayksikko) VALUES ((Select Resepti_ID from RESEPTIT where nimi = @0),(Select Aine_ID from AINEET where nimi = @1), @2,(Select mittayksikko from AINEET where nimi = @3))");
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(mysql, conn);
                    cmd.Parameters.AddWithValue("@0", reseptit.Nimi); 
                    cmd.Parameters.AddWithValue("@1", a.Nimi);
                    cmd.Parameters.AddWithValue("@2", a.Maara);
                    cmd.Parameters.AddWithValue("@3", a.Nimi);
                    int lkm = cmd.ExecuteNonQuery();
                    if (lkm == 1)
                        c = true;
                    else
                        c = false;
                }
            }
            if (b && c)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static List<Reseptit> VertaaPuutteet() // Palauttaa reseptin nimen jos reseptissä on puutteita
        {
            List<Reseptit> resepti = new List<Reseptit>();

            string cs = GetMysqlConnectionString();
            string sql = string.Format("select distinct RESEPTIT.nimi from OHJEET, AINEET, RESEPTIT where OHJEET.Resepti_ID = RESEPTIT.Resepti_ID and OHJEET.Aine_ID = AINEET.Aine_ID  and  AINEET.maara < OHJEET.Maara;"); 
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Reseptit r = new Reseptit();
                        r.Nimi = rdr.GetString(0);                        
                        resepti.Add(r);
                    }
                }
            }
            return resepti;
        }

        public static List<Reseptit> HaeToteutettavat()   //listaa reseptit nimeltä jotka voi toteuttaa
        {
            try
            {
                List<Reseptit> resepti = new List<Reseptit>();
                string cs = GetMysqlConnectionString();
                string sql = "select nimi, valmistusaika, haaste from RESEPTIT where Resepti_ID not in (select RESEPTIT.Resepti_ID from OHJEET, AINEET, RESEPTIT where OHJEET.Resepti_ID = RESEPTIT.Resepti_ID and OHJEET.Aine_ID = AINEET.Aine_ID and AINEET.maara < OHJEET.Maara)"; 
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Reseptit a = new Reseptit();
                            a.Nimi = rdr.GetString(0);
                            a.Valmistusaika = rdr.GetInt32(1);
                            a.Haaste = rdr.GetString(2);
                            resepti.Add(a);                            
                        }
                    }
                }
                return resepti;
            }
            catch 
            {
                throw;
            }
        }

        public static bool PoistaResepti(string nimi) // Poista yksittäinen resepti
        {   
            string cs = GetMysqlConnectionString();
            string sql = "DELETE FROM RESEPTIT where nimi = '" + nimi + "'";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    return true;
                else
                    return false;
            }
        }
        public static bool TallennaResepti(Reseptit resepti, List<Aineet> ainelista)  //Reseptin aineiden määrän ja ohjeen syöttäminen
        {                                                                             
            bool b = false;
            bool c = false;
            string cs = GetMysqlConnectionString();
           string sql = "UPDATE RESEPTIT SET ohje = @0 where nimi = @1"; 
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@0", resepti.Ohje);
                cmd.Parameters.AddWithValue("@1", resepti.Nimi);
                int lkm = cmd.ExecuteNonQuery();
                if (lkm == 1)
                    b = true;
                else
                    b = false;
            }

            // päivitetään tietokannan reseptiin aineiden nimet ja määrät (ainemäärät)   

            Aineet a = new Aineet();
            foreach (var item in ainelista)
            {
                a = (Aineet)item;

                cs = GetMysqlConnectionString();
                sql = "UPDATE OHJEET SET Maara = @0 where Resepti_ID = (Select Resepti_ID from RESEPTIT where nimi = @1) and Aine_ID = (Select Aine_ID from AINEET where nimi = @2)";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@0", a.Maara);
                    cmd.Parameters.AddWithValue("@1", resepti.Nimi);
                    cmd.Parameters.AddWithValue("@2", a.Nimi);
                    
                    int lkm = cmd.ExecuteNonQuery();
                    if (lkm == 1)
                        c = true;
                    else
                        c = false;
                }
            }

            if (b && c)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

      
        private static string GetMysqlConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;
            return connectionString;
        }
    }
}