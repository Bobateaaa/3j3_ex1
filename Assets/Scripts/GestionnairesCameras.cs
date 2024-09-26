using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pour faire la gestion des caméras
//
// Matilda Kang

public class GestionnaireCameras : MonoBehaviour
{
     // Déclarer les variables
    public GameObject cameraFPS;
    public GameObject camera3ePersonne;
    public GameObject cameraDistanceFixe;
    public GameObject cameraSurveillance;

    public GameObject helico; 
    private DeplacementHelico ScriptDeplacementHelico;
    public bool finJeu;

    // Start is called before the first frame update
    void Start()
    {
        // Prendre le script DeplacementHelico
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 

        // Initialiser les variables
        cameraFPS.SetActive(true);
        camera3ePersonne.SetActive(false); 
        cameraDistanceFixe.SetActive(false);
        cameraSurveillance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        finJeu = ScriptDeplacementHelico.finJeu;

        // Si la touche 1 est enfoncée, activer la caméra FPS
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiverCamera(cameraFPS);
        }
        // Si la touche 2 est enfoncée, activer la caméra 3e personne
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiverCamera(camera3ePersonne);
        }
        // Si la touche 3 est enfoncée, activer la caméra distance fixe
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCamera(cameraDistanceFixe);
        }
        // Si la touche 4 est enfoncée, activer la caméra de surveillance
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiverCamera(cameraSurveillance);
        }
    }

    // Fonction pour activer la caméra spécifiée
    void ActiverCamera(GameObject cameraChoisi)
    {
        // Désactiver toutes les caméras
        cameraFPS.SetActive(false);
        camera3ePersonne.SetActive(false);
        cameraDistanceFixe.SetActive(false);
        cameraSurveillance.SetActive(false);

        // Activer la caméra spécifiée
        cameraChoisi.SetActive(true);
    }
}