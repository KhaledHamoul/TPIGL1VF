using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIGL1.Data;

namespace TpIGL1.Traitements
{ /// commentaire khaled
    /// <summary>
    /// Cette classe contient diverses methodes qui traitent les chaines de characteres
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Joindre plusieur chaines a partir d'un tableau dans une seule chaine
        /// </summary>
        /// <param name="tabMots"></param>
        /// <param name="carSeparationArg"></param>
        /// <returns>une seule chaine contenant les chaines</returns>
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
        
        /// <summary>
        /// Fractionne une chaines de caracteres en plusieurs chaines en utilisons un separateur
        /// </summary>
        /// <param name="chaineArg"></param>
        /// <param name="carFractionArg"></param>
        /// <returns>une liste des chaines divisées</returns>
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

        /// <summary>
        /// Elimine les mots "ou,et,a,non" d'une chaine de charactere
        /// </summary>
        /// <param name="motArg"></param>
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

        /// <summary>
        /// Elemine toute occurence d'un mot donné d'une chaine
        /// </summary>
        /// <param name="motArg"></param>
        /// <param name="motEliminerArg"></param>
        /// <returns>une chaine sans occurence du mot specifié</returns>
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

        /// <summary>
        /// verifie si un mot précie existe dans la chaine
        /// </summary>
        /// <param name="motArg"></param>
        /// <param name="motRechArg"></param>
        /// <param name="startIndexArg"></param>
        /// <returns>vraie si le mot existe, non sinon</returns>
        private static bool MotExiste(string motArg, string motRechArg, int startIndexArg)
        {
            try
            {
                if ((startIndexArg == 0) || (motArg[startIndexArg - 1] == Constants.blanc) ||(motArg[startIndexArg - 1] == Constants.sautLigne))
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

        /// <summary>
        /// Met chaque debut de phrase d'un text en Majuscule et le reste en minuscule
        /// </summary>
        /// <param name="textArg"></param>
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

        /// <summary>
        /// donne le nombre d'occurences d'un mot dans une chaine de charactere
        /// </summary>
        /// <param name="textArg"></param>
        /// <param name="motRechArg"></param>
        /// <returns>le nombre d'occurences</returns>
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

        /// <summary>
        /// permute les characteres d'une chaines deux a deux
        /// </summary>
        /// <param name="motArg"></param>
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
                if (motArg.Length % 2 != 0) nouveauMot += motArg[motArg.Length - 1];
            }
            // commentaire  changer
            catch (Exception expeption)
            {
                throw new Exception(expeption.Message);
            }
            motArg = nouveauMot;
        }
    }
}