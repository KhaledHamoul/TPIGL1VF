using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIGL1.Data;

namespace TpIGL1.Traitements
{

    public class StringHelper
    {
        public static string JoindreChaines(string[] tabMots, char carSeparationArg)
        {
            string motsJoint = string.Empty;
            try
            {
                for (int i = 0; i < tabMots.Length; i++)
                {
                    if (i == 0)
                    {
                        motsJoint = tabMots[0];
                    }
                    else
                    {
                        motsJoint += carSeparationArg + tabMots[i];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return motsJoint;
        }

        public static List<string> FractionnerChaine(string chaineArg, char carFractionArg)
        {
            List<string> chaines = new List<string>();
            try
            {
                string sousChaine = string.Empty;
                for (int i = 0; i < chaineArg.Length; i++)
                {
                    if (chaineArg[i] == carFractionArg)
                    {
                        if (sousChaine != string.Empty)
                        {
                            chaines.Add(sousChaine);
                            sousChaine = string.Empty;
                        }
                    }
                    else
                    {
                        sousChaine += chaineArg[i];
                    }
                }
                if (sousChaine != string.Empty) chaines.Add(sousChaine);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return chaines;
        }

        public static void EliminerMotsVides(ref string motArg)
        {
            string nouvelleChaine = motArg;
            try
            {
                nouvelleChaine = EliminerMot(nouvelleChaine, "ou");
                nouvelleChaine = EliminerMot(nouvelleChaine, "et");
                nouvelleChaine = EliminerMot(nouvelleChaine, "à");
                nouvelleChaine = EliminerMot(nouvelleChaine, "non");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            motArg = nouvelleChaine;
        }

        public static string EliminerMot(string motArg, string motEliminerArg)
        {
            string nouvelleChaine = string.Empty;
            try
            {
                int i = 0;
                while (i < motArg.Length)
                {
                    if (motArg[i] == motEliminerArg[0])
                    {
                        if (MotExiste(motArg, motEliminerArg, i))
                        {
                            i += motEliminerArg.Length + 1;
                        }
                    }
                    if (i < motArg.Length)
                    {
                        nouvelleChaine += motArg[i];
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nouvelleChaine;
        }

        private static bool MotExiste(string motArg, string motRechArg, int startIndexArg)
        {
            try
            {
                if ((startIndexArg == 0) || (motArg[startIndexArg - 1] == Constants.blanc))
                {
                    if (motRechArg.Length <= motArg.Length - startIndexArg)
                    {
                        for (int i = 1; i < motRechArg.Length; i++)
                        {
                            if (motRechArg[i] != motArg[i + startIndexArg])
                            {
                                return false;
                            }
                        }
                        if ((motArg.Length == (startIndexArg + motRechArg.Length)))
                        {
                            return true;
                        }
                        if ((motArg[motRechArg.Length + startIndexArg] != Constants.blanc) && (motArg[motRechArg.Length + startIndexArg] != Constants.virgule) && (motArg[motRechArg.Length + startIndexArg] != Constants.point))
                        {
                            return false;
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void MajMinText(ref string textArg)
        {
            string nouveauText = string.Empty;
            try
            {
                for (int i = 0; i < textArg.Length; i++)
                {
                    if ((i == 0) || (textArg[i - 1] == Constants.sautLigne) || ((i > 1) && (textArg[i - 1] == Constants.blanc) && (textArg[i - 2] == Constants.point)))
                    {
                        nouveauText += char.ToUpper(textArg[i]);
                    }
                    else
                    {
                        nouveauText += char.ToLower(textArg[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            textArg = nouveauText;
        }

        public static int NmbrOccurencesMot(string textArg, string motRechArg)
        {
            if (string.IsNullOrEmpty(textArg) || string.IsNullOrWhiteSpace(textArg))
            {
                throw new ArgumentNullException("Texte vide");
            }
            int nmbrOccur = 0;
            try
            {
                int i = 0;
                while (i < textArg.Length)
                {
                    if (MotExiste(textArg, motRechArg, i))
                    {
                        nmbrOccur++;
                        i += motRechArg.Length;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nmbrOccur;
        }

        public static void PermutationChars(ref string motArg)
        {
            string nouveauMot = string.Empty;
            try
            {
                int maxIndex = motArg.Length;
                if (motArg.Length % 2 != 0) maxIndex = motArg.Length - 1;
                for (int i = 0; i < maxIndex; i += 2)
                {
                    nouveauMot += motArg[i + 1];
                    nouveauMot += motArg[i];
                }
            }
            catch (Exception exep)
            {
                throw new Exception(exep.Message);
            }
            motArg = nouveauMot;
        }
    }
}
