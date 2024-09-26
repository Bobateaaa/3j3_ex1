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
    private DeplacementHelico ScriptDeplacementHelico;
    public bool finJeu;
    public GameObject helico; 

    // Start is called before the first frame update
    void Start()
    {
        //Récupérer le script DeplacementHelico
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 

        // Initialiser les variables
        acceleration = 2;
        demarreMoteur = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        //Récupérer la valeur de finJeu
        finJeu = ScriptDeplacementHelico.finJeu;
        
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
        
        // Arrêter la rotation si la fin du jeu est vrai
        if (finJeu == true)
        {
            vitesseRotation = Vector3.zero;
        }

        if(vitesseRotation.y < 0) vitesseRotation.y = 0;  // pour éviter les valeurs négatives

        transform.Rotate(vitesseRotation); // tourner l'objet selon la vitesse de rotation
    }
}