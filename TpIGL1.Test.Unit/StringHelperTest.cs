using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIGL1.Traitements;
using Xunit;
namespace TpIGL.Test.Unit
{
    public class StringHelperTest
    {

        [Fact]
        public void JoindrePlusieursChainesDunTabAvecSeparateur()
        {
            string[] tab = { "Joindre", "plusieurs", "chaines", "avec", "separateur" };
            Assert.Equal("Joindre,plusieurs,chaines,avec,separateur", StringHelper.JoindreChaines(tab, ','));
        }


        [Fact]
        public void FractionnerUneChaineEnPlusieursChainesDansUneListe()
        {
            string str = "Fractionner,en plusieurs,chaines";
            List<string> list = new List<string>();
            list.Add("Fractionner");
            list.Add("en Plusieurs");
            list.Add("chaines");
            Assert.Equal(list.ToArray().ToString(), StringHelper.FractionnerChaine(str, ',').ToArray().ToString());
        }


        [Fact]
        public void EliminerMotsVides()
        {
            string str = "Boukhoulda et Salaheddine ou Hamoul et Khaled";
            StringHelper.EliminerMotsVides(ref str);
            Assert.Equal("Boukhoulda Salaheddine Hamoul Khaled", str);
        }

        [Fact]
        public void MettreChaqueDebutPhraseMajEtLeResteMin()
        {
            string str = "chaque DEBUT De Phrase en Maj. et le reste\nen Min";
            StringHelper.MajMinText(ref str);
            Assert.Equal("Chaque debut de phrase en maj. Et le reste\nEn min", str);
        }

        [Fact]
        public void NmbresdOccurencesMotDansUneChaine()
        {
            string str = "Realisation du TP, implementation xunit en projet TP";
            Assert.Equal(2, StringHelper.NmbrOccurencesMot(str, "TP"));
        }

        [Fact]
        public void PermuterCharsDeuxaDeuxDuneChaine()
        {
            string str = "oxox";
            StringHelper.PermutationChars(ref str);
            Assert.Equal("xoxo", str);
        }
    }
}
