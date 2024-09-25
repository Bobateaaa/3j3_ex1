using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceFixe : MonoBehaviour
{
    //déclarer les variables
    public GameObject cible;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = cible.transform.position + new Vector3(5, 7, -10); // positionne la caméra à 10 unités au-dessus de la cible
        transform.LookAt(cible.transform); 
        
        
    }
}
