// <copyright file="SystemeDEncodage.cs" company="cstjean.qc.ca">
// Fabrice Senecal
// </copyright>
namespace TP3;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Contient les méthodes pour création de l'arbre binaire utilisé pour la compression de données.
/// </summary>
public class SystemeDEncodage
{
    /// <summary>
    /// Construit l'arbre binnaire des feuilles vers la racine tout en s'assurant
    /// de lordre des noeuds dans la queu pour la construction optimale de l'arbre.
    /// </summary>
    /// <param name="pourcentages"> Dictionnaire contenant les pourcentages des fréquences d'apparition des lettres.</param>
    /// <returns>la racine de l'arbre binaire.</returns>
    public Node ConstruireArbre(Dictionary<char, double> pourcentages)
    {
        var pourcentageOrdonee = pourcentages.OrderBy(p => p.Value);
        Queue<Node> queueOrdonne = new Queue<Node>();

        foreach (var pourcentage in pourcentageOrdonee)
        {
            queueOrdonne.Enqueue(new Node(pourcentage.Key, pourcentage.Value));
        }

        while (queueOrdonne.Count > 1)
        {
            var gauche = queueOrdonne.Dequeue();
            var droite = queueOrdonne.Dequeue();

            var parent = new Node('*', gauche.Pourcentage + droite.Pourcentage);
            parent.Left = gauche;
            parent.Right = droite;

            queueOrdonne.Enqueue(parent);
            TrieQueue(queueOrdonne);
        }

        return queueOrdonne.Dequeue();
    }

    /// <summary>
    /// Méthode qui créer une liste à partir de la queue pour ensuite
    /// trier les données à partir de la méthode de trie récursive et les
    /// réinsère dans la queue.
    /// </summary>
    /// <param name="p_queueOrdonne">queue contenant les noeuuds restant à polacer dans l'arbre.</param>
    private void TrieQueue(Queue<Node> p_queueOrdonne)
    {
        List<Node> listeAOrdonner = new List<Node>(p_queueOrdonne);

        List<Node> listeOrdonnee = TrieQueueRecrursif(listeAOrdonner);

        p_queueOrdonne.Clear();

        for (int i = 0;  i < listeOrdonnee.Count; i++)
        {
            p_queueOrdonne.Enqueue(listeOrdonnee[i]);
        }
    }

    /// <summary>
    /// Méthode récursive faisant le trie de la liste en trouvant l'index
    /// du noeud avec le plus petit pourcentage, Ensuite le noeud touvé est
    /// échangé avec le noeud se trouvant à l'index 0. pour finir la méthode
    /// est réinvoqué en passant la liste modifié en sautant la première donné.
    /// </summary>
    /// <param name="listeAOrdonner">Liste créer pour ordonner les noeuds qu'elle contient.</param>
    /// <returns>Une nouvelle liste avec les noeuds mit en ordre du plus petit au plus grand.</returns>
    private List<Node> TrieQueueRecrursif(List<Node> listeAOrdonner)
    {
        if (listeAOrdonner.Count <= 1)
        {
            return listeAOrdonner;
        }

        int indexFrequencePlusPetite = TrouverPlusPetitIndex(listeAOrdonner);

        Node node = listeAOrdonner[0];
        listeAOrdonner[0] = listeAOrdonner[indexFrequencePlusPetite];
        listeAOrdonner[indexFrequencePlusPetite] = node;

        List<Node> resteDeListe = TrieQueueRecrursif(listeAOrdonner.Skip(1).ToList());

        return new List<Node> { listeAOrdonner[0] }.Concat(resteDeListe).ToList();
    }

    /// <summary>
    /// Trouve l'index du noeud contenant le plus petit pourcentage.
    /// </summary>
    /// <param name="listeAOrdonner">liste de donnée à mettre en ordre.</param>
    /// <returns>l'index du noeud contenant le plus petit pourcentage.</returns>
    private int TrouverPlusPetitIndex(List<Node> listeAOrdonner)
    {
        int index = 0;
        for (int i = 0; i < listeAOrdonner.Count; i++)
        {
            if (listeAOrdonner[i].Pourcentage < listeAOrdonner[index].Pourcentage)
            {
                index = i;
            }
        }

        return index;
    }
}
