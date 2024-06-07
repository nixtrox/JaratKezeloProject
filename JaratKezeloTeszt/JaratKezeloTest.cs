using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    internal class JaratKezeloTest
    {

        [Test]
        public void ujJarat_HelyesAdatok()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratSzam", "indulasRepter", "erkezesRepter", DateTime.Now);
        }



        [Test]
        public void ujJarat_NullJaratSzammal_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();

            Assert.Throws<ArgumentNullException>(() => j.ujJarat(null, "indulasRepter", "erkezesRepter", DateTime.Now));
        }

        [Test]
        public void ujJarat_UresJaratSzammal_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();
            Assert.Throws<ArgumentNullException>(() => j.ujJarat("", "indulasRepter", "erkezesRepter", DateTime.Now));
        }


        [Test]
        public void ujJarat_NullIndulasRepter_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();
            Assert.Throws<ArgumentNullException>(() => j.ujJarat("jaratszam", null, "erkezesRepter", DateTime.Now));
        }

        [Test]
        public void ujJarat_UresIndulasRepter_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();
            Assert.Throws<ArgumentNullException>(() => j.ujJarat("jaratszam", "", "erkezesRepter", DateTime.Now));
        }


        [Test]
        public void ujJarat_NullErkezesRepter_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();
            Assert.Throws<ArgumentNullException>(() => j.ujJarat("jaratszam", "indulasRepter", null, DateTime.Now));
        }

        [Test]
        public void ujJarat_UresErkezesRepter_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();
            Assert.Throws<ArgumentNullException>(() => j.ujJarat("jaratszam", "indulasRepter", "", DateTime.Now));
        }

        [Test]
        public void ujJarat_LetezoJaratszam_ArgumentException()
        {
            JaratKezelo j = new JaratKezelo();

            j.ujJarat("jaratszam", "indulasRepter", "erkezesRepter", DateTime.Now);

            Assert.Throws<ArgumentException>(() => j.ujJarat("jaratszam", "indulasRepter", "erkezesRepter", DateTime.Now));
        }



        [Test]
        public void keses_MegfeleloAdatokPozitivKeses()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratSzam", "indulasRepter", "erkezesRepter", DateTime.Now);
            j.keses("jaratSzam", 10);

        }

        [Test]
        public void keses_MegfeleloAdatokNegativKeses()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratSzam", "indulasRepter", "erkezesRepter", DateTime.Now);
            j.keses("jaratSzam", 15);
            j.keses("jaratSzam", -10);

        }

        [Test]
        public void keses_MegfeleloAdatokNegativKesesSumm()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratSzam", "indulasRepter", "erkezesRepter", DateTime.Now);
            j.keses("jaratSzam",5);
           
            Assert.Throws<ArgumentException>(() => j.keses("jaratSzam", -10));

        }



        [Test]
        public void mikorIndul_MegfeleloBemenet()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratSzam", "indulasRepter", "erkezesRepter", DateTime.Now);
            j.mikorINdul("jaratSzam");
        }


        [Test]
        public void mikorIndul_NullBemenet_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();


            Assert.Throws<ArgumentNullException>(() => j.mikorINdul(null));
        }

        [Test]
        public void mikorIndul_NincsMegfeleloJaratszam_ArgumentException()
        {
            JaratKezelo j = new JaratKezelo();

            j.ujJarat("jaratszam", "indulasRepter", "erkezesRepter", DateTime.Now);

            Assert.Throws<ArgumentException>(() => j.mikorINdul("asdasd"));


        }


        [Test]
        public void jaratokRepuloterrol_MegfeleloAdatok()
        {
            JaratKezelo j = new JaratKezelo();
            j.ujJarat("jaratszam", "indulasRepter", "erkezesRepter", DateTime.Now);
            j.jaratokRepuloterrol("indulasRepter");
        }


        [Test]
        public void jaratokRepuloterrol_NullRepter_ArgumentNullException()
        {
            JaratKezelo j = new JaratKezelo();


            Assert.Throws<ArgumentNullException>(() => j.jaratokRepuloterrol(null));
        }


        [Test]
        public void jaratokRepuloterrol_NemLétezikAMegadottRepter_ArgumentException()
        {
            JaratKezelo j = new JaratKezelo();

            j.ujJarat("jaratszam", "indulasRepter", "erkezesRepter", DateTime.Now);

            Assert.Throws<ArgumentException>(() => j.jaratokRepuloterrol("asdasd"));


        }











    }
}
