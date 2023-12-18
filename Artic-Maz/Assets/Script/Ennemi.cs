using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public enum TypeEnnemi
    {
        Orque,
        Requin
    }

    public TypeEnnemi typeEnnemi;
    public int puissanceAttaque = 0; // Puissance d'attaque par défaut

    private void Start()
    {
        // Assigner la puissance d'attaque en fonction du type d'ennemi
        switch (typeEnnemi)
        {
            case TypeEnnemi.Orque:
                puissanceAttaque = 5;
                break;
            case TypeEnnemi.Requin:
                puissanceAttaque = 3;
                break;
                // Ajoutez d'autres cas pour d'autres types d'ennemis si nécessaire
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Le joueur (personnage) est entré en collision avec l'ennemi
            collision.GetComponent<DeplacementPersonnage>().AttaquerParEnnemi(puissanceAttaque);
        }
    }
}
