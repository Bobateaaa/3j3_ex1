using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneObjet : MonoBehaviour
{
    // Déclarer les variables
    public Vector3 vitesseRotation;
    public float vitesseRotationMax;
    public bool demarreMoteur;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        // Initialiser les variables
        acceleration = 2;
        demarreMoteur = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        // Si la touche Entrée est enfoncée, démarrer ou arrêter le moteur
        if (Input.GetKeyDown(KeyCode.Return))
        {
            demarreMoteur = !demarreMoteur;
        }

        // Si le moteur est démarré, augmenter la vitesse de rotation
        if (demarreMoteur)
        {
            if (vitesseRotation.y < vitesseRotationMax)
            {
                vitesseRotation.y += acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (vitesseRotation.y > 0) vitesseRotation.y -= acceleration;
            vitesseRotation.y = 0;
        }
        

        if(vitesseRotation.y < 0) vitesseRotation.y = 0;  // pour éviter les valeurs négatives

        transform.Rotate(vitesseRotation); // tourner l'objet selon la vitesse de rotation
    }
}