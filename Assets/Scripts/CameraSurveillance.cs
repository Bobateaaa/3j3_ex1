using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurveillance : MonoBehaviour
{

    public GameObject cible;     

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // la cible est déterminée dans la fenêtre inspector
    void Update () 
    {
    
        transform.LookAt(cible.transform);  // regarde la cible, il faut utiliser le transform de l’objet cible ou sa position
    }

}
