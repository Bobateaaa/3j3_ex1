using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{

    private Rigidbody rb;
    float vitesseAvant = 0f;  
    float vitesseAvantMax = 10000f; 
    float vitesseTourne = 1000f;  
    float vitesseMonte = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply force to move up and down
        var forceMonter = Input.GetAxis("Vertical") * vitesseMonte;
        rb.AddRelativeForce(Vector3.up * forceMonter);

        // Apply torque to turn left and right
        var forceTourner = Input.GetAxis("Horizontal") * vitesseTourne;
        rb.AddRelativeTorque(0, forceTourner, 0);

        if (Input.GetKey(KeyCode.E))
        {
            // 
            vitesseAvant += 500f;
            if (vitesseAvant > vitesseAvantMax)
            {
                rb.AddRelativeForce(Vector3.forward * 500f);
                vitesseAvant = vitesseAvantMax;
            }
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            // 
            vitesseAvant -= 500f;
            if (vitesseAvant < 0)
            {
                vitesseAvant = 0;
            }
        }
    }
}
