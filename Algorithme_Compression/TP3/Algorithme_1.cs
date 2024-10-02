// <copyright file="Algorithme_1.cs" company="cstjean.qc.ca">
// Fabrice Senecal
// </copyright>
namespace TP3;

using System.Text;

/// <summary>
/// classe contenant les méthodes et instances
/// nécessaire pour la compression des données.
/// </summary>
public class Algorithme_1
{
    private Dictionary<char, double> pourcentage = new Dictionary<char, double>();

    private SystemeDEncodage systemeCompresseur = new SystemeDEncodage();

    private Node? root;

    private Dictionary<char, string> dictionnaireDeCode = new Dictionary<char, string>();

    /// <summary>
    /// centralise les méthodes utilisée pour la compression de donnée.
    /// </summary>
    /// <param name="messageACompresser">string à comprésser en bits.</param>
    /// <returns>La string compréssé.</returns>
    public string CompressionComplete(string messageACompresser)
    {
        CalculeFrequence(messageACompresser);
        root = systemeCompresseur.ConstruireArbre(pourcentage);
        return CompresseMessage(messageACompresser);
    }

    /// <summary>
    /// Parcour l'arbre binaire fait par le systeme d'encodage en se dirigeant
    /// soit à gauche si le bit est de 0 ou a droite si le bit est 1. Enfin, si le
    /// noeud actuel est une feuille, la lettre est ajouté a un string builder. La
    /// méthode boucle au travers de chaque bits du message compréssé.
    /// </summary>
    /// <param name="messageCompresse">string de bits à décompresser.</param>
    /// <returns>Une string su message décompressé.</returns>
    public string? DecompresseMessage(string messageCompresse)
    {
        if (root != null)
        {
            Node noeudActuel = root;
            StringBuilder messageDecompresse = new StringBuilder();

            foreach (var bit in messageCompresse)
            {
                if (bit == '0')
                {
                    noeudActuel = noeudActuel.Left!;
                }
                else if (bit == '1')
                {
                    noeudActuel = noeudActuel.Right!;
                }

                if (noeudActuel.Caractere != '*')
                {
                    messageDecompresse.Append(noeudActuel.Caractere);
                    noeudActuel = root;
                }
            }

            return messageDecompresse.ToString();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Calcule la fréquence d'apparition de chaque caractère sur le total en utilisant un dictionnaire.
    /// si le caractère est présent la fréquence est incrémenté sinon le caractère est ajouté avec une fréquence de un.
    /// Enfin, la méthode boucle au travers de chaque KeyValuePair pour calculer le pourcentage
    /// d'apparition et insérer le caractère et la donné dans le dictionnaire <see cref="pourcentage"/>.
    /// </summary>
    /// <param name="messageACompress">string à comprésser en bits.</param>
    private void CalculeFrequence(string messageACompress)
    {
        var frequences = new Dictionary<char, int>();

        foreach (char lettre in messageACompress)
        {
            if (frequences.ContainsKey(lettre))
            {
                frequences[lettre]++;
            }
            else
            {
                frequences.Add(lettre, 1);
            }
        }

        foreach (var frequence in frequences)
        {
            pourcentage.Add(frequence.Key, Math.Round((double)frequence.Value / frequences.Values.Sum(), 2));
        }
    }

    /// <summary>
    /// Méthode invoquant la fonction récursive pour faire l'encodage.
    /// </summary>
    private void FaireEncodage()
    {
        FaireEncodageRecursif(root!, string.Empty);
        foreach(var code in dictionnaireDeCode)
        {
            Console.WriteLine(code);
        }
    }

    /// <summary>
    /// Méthode récursive qui créer le <see cref="dictionnaireDeCode"/> en
    /// prenant en compte le positionnement des noeuds pour faire l'encodage de chaque caractères.
    /// </summary>
    /// <param name="root">le noeud actuellement traiter.</param>
    /// <param name="caractereEncode">string builder qui créer la string du caractère une fois encodé.</param>
    private void FaireEncodageRecursif(Node root, string caractereEncode)
    {
        if (root.Caractere != '*')
        {
            dictionnaireDeCode.Add(root.Caractere, caractereEncode);
        }
        else
        {
            FaireEncodageRecursif(root.Left!, caractereEncode + '0');
            FaireEncodageRecursif(root.Right!, caractereEncode + '1');
        }
    }

    /// <summary>
    /// Méthode faisant la compression complète du message selon le <see cref="dictionnaireDeCode"/> qui lui
    /// contien la traductions en bits de chaque caractère utilisé dans le message à compresser.
    /// </summary>
    /// <param name="messageACompress">message à compresser.</param>
    /// <returns>une string du message convertis en bits.</returns>
    private string CompresseMessage(string messageACompress)
    {
        if (dictionnaireDeCode.Count == 0)
        {
            FaireEncodage();
        }

        string messageCompresse = string.Empty;

        for (int i = 0; i < messageACompress.Length; i++)
        {
            messageCompresse += dictionnaireDeCode[messageACompress[i]];
        }

        return messageCompresse;
    }
}
