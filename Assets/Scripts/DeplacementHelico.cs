using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    public bool finJeu;

    // Start is called before the first frame update
    void Start()
    {
        // Accéder à la vitesse de rotation de l'hélice avant
        vitesseHelice = heliceAvant.GetComponent<TourneObjet>().vitesseRotation.y;

        // Accéder à l'état de l'hélice avant
        demarreMoteur = heliceAvant.GetComponent<TourneObjet>().demarreMoteur;
        // Initialiser la référence au Rigidbody
        rb = GetComponent<Rigidbody>();

        // Fixer l'angle de rotation local de l'hélicoptère sur l'axe X à 0
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

        // Désactiver la gravité au début
        rb.useGravity = false;
    }


   
    void FixedUpdate()
    {

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
                    vitesseAvant += 10f;
                    if (vitesseAvant > vitesseAvantMax)
                    {
                        vitesseAvant = vitesseAvantMax;
                    }
                    rb.AddRelativeForce(Vector3.forward * vitesseAvant);
                }
                // Si la touche Q est enfoncée, diminuer la vitesse vers l'avant
                else if (Input.GetKey(KeyCode.Q))
                {
                    vitesseAvant -= 10f;
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

        }
    }

    void OnCollisionEnter(Collision collisionTrue)   // le type de la variable est Collision 
    {
        if (collisionTrue.gameObject.tag == "terrain") 
        {
            finJeu = true;
            objetExplosion.SetActive(true);
            rb.useGravity = true;
            rb.drag = 0;
            rb.angularDrag = 0;
            rb.freezeRotation = false;

            
        } 

    }

}