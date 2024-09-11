using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneObjet : MonoBehaviour
{
    public Vector3 vitesseRotation;
    public float vitesseRotationMax;
    private Rigidbody rb;
    public bool demarreMoteur;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        demarreMoteur = false;
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
            Vector3 Torque = Vector3.up * vitesseRotationMax * Time.deltaTime;
            rb.AddTorque(Torque);
            vitesseRotation = rb.angularVelocity;
        }
        else
        {
            // Apply torque to decelerate
            rb.AddTorque(0, 0, 0);
            vitesseRotation = Vector3.zero;
        }

    }
}