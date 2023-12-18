using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public float vitesse = 5f;
    public int pointsEnergie = 100;
    public int destructeursMur = 3;

    private bool destructeurUtilise = false;

    public Transform destination; // Destination du personnage (Home)

    void Update()
    {
        // D�placement
        DeplacerPersonnage();

        // Gestion des ennemis
        GererEnnemis();

        // Utiliser un destructeur de mur
        if (Input.GetKeyDown(KeyCode.Space) && destructeursMur > 0 && !destructeurUtilise)
        {
            UtiliserDestructeurWall();
        }

        // V�rifier si le personnage est arriv� � destination
        if (transform.position == destination.position && pointsEnergie > 0)
        {
            // Gagne le jeu
            Debug.Log("GameWinner!");
        }

        // V�rifier si le personnage est mort
        if (pointsEnergie <= 0)
        {
            // Perd le jeu
            Debug.Log("GameOver!");
        }
    }

    void DeplacerPersonnage()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");
        Vector3 deplacement = new Vector3(deplacementHorizontal, deplacementVertical, 0) * vitesse * Time.deltaTime;

        // V�rifier les collisions avec les murs
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, deplacement, 0.5f);
        if (hitWall.collider != null && hitWall.collider.CompareTag("Wall"))
        {
            PerdrePointsEnergie(2);
            // Changer de direction pour �viter le mur
            deplacement = Vector3.zero;
        }

        // V�rifier les collisions avec les aliments
        RaycastHit2D hitFood = Physics2D.Raycast(transform.position, deplacement, 0.5f, LayerMask.GetMask("Food"));
        if (hitFood.collider != null)
        {
            GagnerPointsEnergie(hitFood.collider.GetComponent<Food>().points);
            Destroy(hitFood.collider.gameObject);
        }

        // Appliquer le d�placement
        transform.Translate(deplacement);

        // D�duire des points d'�nergie pour chaque d�placement
        PerdrePointsEnergie(2);
    }

    void GererEnnemis()
    {
        // V�rifier les collisions avec les ennemis
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.5f, LayerMask.GetMask("Ennemi"));
        foreach (Collider2D collider in colliders)
        {
            // Attaquer par chaque ennemi � proximit�
            AttaquerParEnnemi(collider.GetComponent<Ennemi>().puissanceAttaque);
            // Changer de direction pour �viter l'ennemi
            Vector3 direction = transform.position - collider.transform.position;
            transform.Translate(direction.normalized * vitesse * Time.deltaTime);
        }
    }

    public void AttaquerParEnnemi(int puissanceAttaque)
    {
        PerdrePointsEnergie(puissanceAttaque);
        // ... (ajoutez d'autres actions en cas d'attaque par un ennemi)
    }

    void UtiliserDestructeurWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.5f);
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            Destroy(hit.collider.gameObject);
            destructeursMur--;
            destructeurUtilise = true;
        }
    }

    public void GagnerPointsEnergie(int points)
    {
        pointsEnergie += points;
    }

    void PerdrePointsEnergie(int points)
    {
        if (pointsEnergie > 0)
        {
            pointsEnergie -= points;
        }
    }
}
