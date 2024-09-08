using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneObjet : MonoBehaviour
{
    public Vector3 vitesseRotation;
    public float vitesseRotationMax;
    private Rigidbody rb;
    private bool demarreMoteur;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        demarreMoteur = false;
        vitesseRotation = new Vector3(0, 0, 0);
        rb.useGravity = false; // Disable gravity
        rb.isKinematic = false; // Ensure Rigidbody is not kinematic
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            demarreMoteur = !demarreMoteur;
            print(demarreMoteur);

            if (!demarreMoteur)
            {
                // Stop rotation when motor is turned off
                rb.angularVelocity = Vector3.zero;
            }
        }

        if (demarreMoteur)
        {
            // Apply torque to accelerate
            rb.AddTorque(Vector3.up * vitesseRotationMax);
        }
        else
        {
            // Apply torque to decelerate
            rb.AddTorque(0, 0, 0);
        }

    }
}