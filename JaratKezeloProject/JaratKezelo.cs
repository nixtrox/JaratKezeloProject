using System.Diagnostics.Metrics;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {


        internal class Jarat
        {
            private string jaratSzam;
            private string kezdetiRepter;
            private string celRepter;
            private DateTime indulasIdopontja;
            private int aktualisKeses;

            public Jarat(string jaratszam, string kezdetiRepter, string celRepter, DateTime indulasIdopontja)
            {
                this.jaratSzam = jaratszam;
                this.kezdetiRepter = kezdetiRepter;
                this.celRepter = celRepter;
                this.indulasIdopontja = indulasIdopontja;
                this.aktualisKeses = 0;
            }

            public string JaratSzam { get => jaratSzam; set => jaratSzam = value; }
            public string KezdetiRepter { get => kezdetiRepter; set => kezdetiRepter = value; }
            public string CelRepter { get => celRepter; set => celRepter = value; }
            public DateTime IndulasIdopontja { get => indulasIdopontja; set => indulasIdopontja = value; }
            public int AktualisKeses { get => aktualisKeses; set => aktualisKeses = value; }
        }



        private List<Jarat> jaratok = new List<Jarat>();

        public void ujJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {

         

            if(jaratSzam == null)
            {
                throw new ArgumentNullException(nameof(jaratSzam));
            }

            if (repterHonnan == null)
            {
                throw new ArgumentNullException(nameof(repterHonnan));
            }

            if (repterHova == null)
            {
                throw new ArgumentNullException(nameof(repterHova));
            }

            if (jaratSzam == "")
            {
                throw new ArgumentNullException(nameof(jaratSzam));
            }


            if (repterHonnan == "")
            {
                throw new ArgumentNullException(nameof(repterHonnan));
            }

            if (repterHova == "")
            {
                throw new ArgumentNullException(nameof(repterHova));
            }


            int i = 0;
            while(i < jaratok.Count && jaratok[i].JaratSzam != jaratSzam)
            {
                i++;
            }

            if(i < jaratok.Count)
            {
                throw new ArgumentException("Már létezik ilyen járatszám", nameof(jaratSzam));
            }



            Jarat j1 = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(j1);

        }

        public void keses(string jaratSzam, int keses)
        {
            foreach(var item in jaratok)
            {
                if(item.JaratSzam == jaratSzam)
                {
                    item.AktualisKeses += keses;



                    if(item.AktualisKeses < 0)
                    {
                        throw new ArgumentException("NegativKesesException");
                    }
                }
            }

           
        }

        public DateTime mikorINdul(string jaratSzam)
        {
            DateTime newTime = DateTime.Now ;

            if(jaratSzam == null)
            {
                throw new ArgumentNullException(nameof(jaratSzam));
            }

            int counter = 0;
            foreach (var item in jaratok)
            {
                if (item.JaratSzam == jaratSzam)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new ArgumentException("Nincs ilyen járat.", nameof(jaratSzam));
            }


            foreach (var item in jaratok)
            {
                if(item.JaratSzam == jaratSzam)
                {
                    newTime = item.IndulasIdopontja.Add(TimeSpan.FromMinutes(item.AktualisKeses));
                    return newTime;
                }
                
               
            }

            throw new ArgumentException("Nincs ilyen járat", nameof(jaratSzam));
            
        }


        public List<string>jaratokRepuloterrol(string repter)
        {
            List<string> mylist = new List<string>();



            if(repter == null)
            {
                throw new ArgumentNullException(nameof(repter));
            }


            int counter = 0;
            foreach(var item in jaratok)
            {
                if(item.KezdetiRepter == repter)
                {
                   counter++;
                }
            }
            if(counter == 0)
            {
                throw new ArgumentException("Egyik járat sem indul erről a reptérről.", nameof(repter));
            }

            if(repter == null)
            {
                throw new ArgumentNullException(nameof(repter));
            }

            foreach(var item in jaratok)
            {
                if(item.KezdetiRepter == repter)
                {
                    mylist.Add(item.JaratSzam);
                }
            }

            return mylist;
        }


    }





}