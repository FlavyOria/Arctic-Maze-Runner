using UnityEngine;

public class Food : MonoBehaviour
{
    public enum TypeAliment
    {
        Crabe,
        Lobster,
        Fish
    }

    public TypeAliment typeAliment;
    public int points = 0; // Points d'énergie par défaut

    void Start()
    {
        // Assigner les points d'énergie en fonction du type d'aliment
        switch (typeAliment)
        {
            case TypeAliment.Crabe:
                points = 5;
                break;
            case TypeAliment.Lobster:
                points = 10;
                break;
            case TypeAliment.Fish:
                points = 2;
                break;
                // Ajoutez d'autres cas pour d'autres types d'aliments si nécessaire
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Le joueur (personnage) est entré en collision avec l'aliment
            collision.GetComponent<DeplacementPersonnage>().GagnerPointsEnergie(points);
            // Détruire l'aliment après qu'il a été mangé
            Destroy(gameObject);
        }
    }
}
