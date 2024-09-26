using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script pour faire la gestion du déplacement de l'hélicoptère,
//la gestion de jauge d'essence, le son du bidon et la fin du jeu
//  
// Matilda Kang
public class DeplacementHelico : MonoBehaviour
{
    // Déclarer les variables
    private Rigidbody rb; 
    public GameObject heliceAvant; 
    public GameObject objetExplosion;

    private float vitesseHelice; 
    private bool demarreMoteur;

    float vitesseAvant = 0f; 
    float vitesseAvantMax = 10000f; 
    float vitesseTourne = 1000f; 
    float vitesseMonte = 1000f; 


    private TourneObjet tourneObjet;
    public bool finJeu;
    public AudioSource audioSource;
    public AudioClip sonBidon;
    public Image jaugeEssence;
    public float quantiteEssence = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //initialiser les variables
        finJeu = false;

        jaugeEssence.fillAmount = quantiteEssence;

        tourneObjet = heliceAvant.GetComponent<TourneObjet>();
        
        // Initialiser la référence au Rigidbody
        rb = GetComponent<Rigidbody>();

        // Fixer l'angle de rotation local de l'hélicoptère sur l'axe X à 0
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

        // Désactiver la gravité au début
        rb.useGravity = false;

        // Démarrer le compteur pour la jauge d'essence
        StartCoroutine(Compteur());

    }


    void Update()
    {
        // Mettre à jour la jauge d'essence
        jaugeEssence.fillAmount = quantiteEssence;

        // Si la quantité d'essence est inférieure ou égale à 0, activer la fin du jeu
        if(quantiteEssence <= 0)
        {
            finJeu = true;
        }

        // Si la fin du jeu est activée, activer la fin du jeu
        if(finJeu == true)
        {
            FinDuJeu();
        }
    }


   
    void FixedUpdate()
    {
        // Mettre à jour les variables et vérifier les états
        vitesseHelice = tourneObjet.vitesseRotation.y;
        demarreMoteur = tourneObjet.demarreMoteur;

        // Si le jeu n'est pas terminé, permettre le contrôle de l'hélicoptère
        if(finJeu == false)
        {
            
          // Si la vitesse de l'hélice est suffisante, désactiver la gravité et permettre le contrôle
            if (vitesseHelice > 20f)
            {
                rb.useGravity = false;

                // Appliquer une force pour monter/descendre
                var forceMonter = Input.GetAxis("Vertical") * vitesseMonte;
                rb.AddRelativeForce(Vector3.up * forceMonter);

                // Appliquer un couple pour tourner à gauche/droite
                var forceTourner = Input.GetAxis("Horizontal") * vitesseTourne;
                rb.AddRelativeTorque(0, forceTourner, 0);

                // Si la touche E est enfoncée, augmenter la vitesse vers l'avant
                if (Input.GetKey(KeyCode.E))
                {
                    vitesseAvant += 5f;
                    if (vitesseAvant > vitesseAvantMax)
                    {
                        vitesseAvant = vitesseAvantMax;
                    }
                    rb.AddRelativeForce(Vector3.forward * vitesseAvant);
                }
                // Si la touche Q est enfoncée, diminuer la vitesse vers l'avant
                else if (Input.GetKey(KeyCode.Q))
                {
                    vitesseAvant -= 5f;
                    if (vitesseAvant < 0)
                    {
                        vitesseAvant = 0;
                    }
                    rb.AddRelativeForce(Vector3.forward * vitesseAvant);
                }
            }
            // Si le moteur n'est pas démarré, activer la gravité
            else if (!demarreMoteur)
            {
                rb.useGravity = true;
            }
        }
        else if(finJeu == true)
        {
            Invoke("FinDePartie", 8f);
        }
    }


    // Si l'hélicoptère entre en collision avec le terrain, activer l'explosion
    void OnCollisionEnter(Collision collisionTrue)   
    {
        if (collisionTrue.gameObject.tag == "terrain") 
        {
            FinDuJeu();
        } 

    }


    // Si l'hélicoptère entre en collision avec un bidon, détruire le bidon et ajouter de l'essence
    void OnTriggerEnter(Collider triggerTrue)
    {
        if (triggerTrue.gameObject.tag == "bidon")
        {
            Destroy(triggerTrue.gameObject);
            GetComponent<AudioSource>().PlayOneShot(sonBidon);
            quantiteEssence += 0.5f;
        }
    }


    // Compteur pour la jauge d'essence
    IEnumerator Compteur()
    {
        yield return new WaitForSeconds(1);
        quantiteEssence -= 0.02f;

        if(quantiteEssence > 0)
        {
            StartCoroutine(Compteur());
        }

    }


    // Activer la fin du jeu
    void FinDuJeu()
    {
            finJeu = true;
            objetExplosion.SetActive(true);
            rb.useGravity = true;
            rb.drag = 0;
            rb.angularDrag = 0;
            rb.freezeRotation = false;
    }


    // Activer la fin de la partie
    void FinDePartie()
    {
        SceneManager.LoadScene("SceneTerrain");
    }

}