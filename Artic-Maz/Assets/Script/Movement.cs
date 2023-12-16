using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de d�placement du personnage
    public int pointsEnergie = 100; // Points d'�nergie initiaux
    public int destructeursMur = 3; // Nombre de destructeurs de mur disponibles

    private bool destructeurUtilise = false; // Indique si le destructeur actuel a �t� utilis�

    void Update()
    {
        // D�placement
        DeplacerPersonnage();

        // Gestion des ennemis
        GererEnnemis();

        // Utiliser un destructeur de mur
        if (Input.GetKeyDown(KeyCode.Space) && destructeursMur > 0 && !destructeurUtilise)
        {
            UtiliserDestructeurMur();
        }
    }

    void DeplacerPersonnage()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");
        Vector3 deplacement = new Vector3(deplacementHorizontal, deplacementVertical, 0) * vitesse * Time.deltaTime;
        transform.Translate(deplacement);

        // V�rifier si le personnage touche un mur
        RaycastHit2D hitMur = Physics2D.Raycast(transform.position, deplacement, 0.5f);
        if (hitMur.collider != null && hitMur.collider.CompareTag("Mur"))
        {
            // G�rer la collision avec le mur
            PerdrePointsEnergie(2);
        }

        // V�rifier si le personnage touche un aliment (poisson ou crabe)
        RaycastHit2D hitAliment = Physics2D.Raycast(transform.position, deplacement, 0.5f, LayerMask.GetMask("Aliment"));
        if (hitAliment.collider != null)
        {
            // G�rer la collision avec l'aliment
            GagnerPointsEnergie(hitAliment.collider.GetComponent<Aliment>().points);
            Destroy(hitAliment.collider.gameObject); // D�truire l'aliment apr�s l'avoir mang�
        }
    }

    void GererEnnemis()
    {
        // V�rifier si le personnage touche un ennemi (orques)
        RaycastHit2D hitEnnemi = Physics2D.Raycast(transform.position, Vector2.zero, 0f, LayerMask.GetMask("Ennemi"));
        if (hitEnnemi.collider != null)
        {
            // G�rer la collision avec l'ennemi
            AttaquerParEnnemi(hitEnnemi.collider.GetComponent<Ennemi>().puissanceAttaque);
        }
    }

    void AttaquerParEnnemi(int puissanceAttaque)
    {
        PerdrePointsEnergie(puissanceAttaque);
        // G�rer d'autres actions en cas d'attaque par un ennemi
    }

    void UtiliserDestructeurMur()
    {
        // Mettez ici la logique pour d�truire un mur
        // Par exemple, trouvez le mur devant le personnage et d�truisez-le
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.5f);
        if (hit.collider != null && hit.collider.CompareTag("Mur"))
        {
            Destroy(hit.collider.gameObject);
            destructeursMur--;
            destructeurUtilise = true; // Marquer le destructeur comme utilis�
        }
    }

    void GagnerPointsEnergie(int points)
    {
        pointsEnergie += points;
        // G�rer d'autres actions lors de la r�cup�ration d'�nergie (peut-�tre afficher un message, etc.)
    }

    void PerdrePointsEnergie(int points)
    {
        if (pointsEnergie > 0)
        {
            pointsEnergie -= points;
            // G�rer la perte d'�nergie ici (peut-�tre afficher un message, etc.)
        }
    }
}
