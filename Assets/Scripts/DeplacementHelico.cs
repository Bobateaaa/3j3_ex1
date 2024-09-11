using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject heliceAvant;
    private float vitesseHelice;
    private bool demarreMoteur;
    float vitesseAvant = 0f;  
    float vitesseAvantMax = 10000f; 
    float vitesseTourne = 1000f;  
    float vitesseMonte = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
        rb.useGravity = false; // Disable gravity at the start
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Access the y component of vitesseRotation
        vitesseHelice = heliceAvant.GetComponent<TourneObjet>().vitesseRotation.y;
        demarreMoteur = heliceAvant.GetComponent<TourneObjet>().demarreMoteur;

        if (vitesseHelice > 6f)
        {
            rb.useGravity = false;

            // Apply force to move up and down
            var forceMonter = Input.GetAxis("Vertical") * vitesseMonte;
            rb.AddRelativeForce(Vector3.up * forceMonter);

            // Apply torque to turn left and right
            var forceTourner = Input.GetAxis("Horizontal") * vitesseTourne;
            rb.AddRelativeTorque(0, forceTourner, 0);

            if (Input.GetKey(KeyCode.E))
            {
                // Apply force to move forward
                vitesseAvant += 500f;
                if (vitesseAvant > vitesseAvantMax)
                {
                    vitesseAvant = vitesseAvantMax;
                }
                rb.AddRelativeForce(Vector3.forward * vitesseAvant);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                // Apply force to move backward
                vitesseAvant -= 500f;
                if (vitesseAvant < 0)
                {
                    vitesseAvant = 0;
                }
                rb.AddRelativeForce(Vector3.forward * vitesseAvant);
            }
        }
        else if (!demarreMoteur)
        {
            rb.useGravity = true;
        }
    }
}