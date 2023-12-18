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
    public int points = 0; // Points d'�nergie par d�faut

    void Start()
    {
        // Assigner les points d'�nergie en fonction du type d'aliment
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
                // Ajoutez d'autres cas pour d'autres types d'aliments si n�cessaire
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Le joueur (personnage) est entr� en collision avec l'aliment
            collision.GetComponent<DeplacementPersonnage>().GagnerPointsEnergie(points);
            // D�truire l'aliment apr�s qu'il a �t� mang�
            Destroy(gameObject);
        }
    }
}
