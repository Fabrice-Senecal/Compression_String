// <copyright file="Node.cs" company="cstjean.qc.ca">
// Fabrice Senecal
// </copyright>

namespace TP3;

/// <summary>
/// Classe qui contiens les propriétées nécessaire 
/// pour instancier un noeud dans l'arbre.
/// </summary>
public class Node
{
    /// <summary>
    /// Initialise une nouvelle instance de la class <see cref="Node"/>.
    /// </summary>
    /// <param name="lettre">lettre assignée au noeud.</param>
    /// <param name="pourcentage">Pourcentage de la fréquence d'apparition de la lettre.</param>
    public Node(char lettre, double pourcentage)
    {
        Caractere = lettre;
        Pourcentage = pourcentage;
        Left = null;
        Right = null;
    }

    /// <summary>
    /// Char représentant le caractère assignée au noeud.
    /// </summary>
    public char Caractere { get; private set; }

    /// <summary>
    /// Double représentant le pourcentage de la fréquence d'apparition de la lettre.
    /// </summary>
    public double Pourcentage { get; private set; }

    /// <summary>
    /// Obtien et set Le noeud positionné a gauche une fois le noeud actuel instancié.
    /// </summary>
    public Node? Left { get; set; }

    /// <summary>
    /// Obtien et set le noeud positionné a droite une fois le noeud actuel instancié.
    /// </summary>
    public Node? Right { get; set; }
}
