using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3iemPersonne : MonoBehaviour
{
    public GameObject cibleJoueur;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame                                   

    void FixedUpdate() 
    {
    // Définie une position 5 mètres en hauteur et 10 mètres en arrière de la cible (selon les axes locaux de la cible)
    Vector3 positionFinale = cibleJoueur.transform.TransformPoint(0, 5, -10);  

    // prochaine position entre la position de départ de la caméra et la position finale désirée selon un facteur 0.5 
    transform.position = Vector3.Lerp(transform.position, positionFinale, 0.5f);

    // regarde toujours la cible
    transform.LookAt(cibleJoueur.transform);
    }

}
