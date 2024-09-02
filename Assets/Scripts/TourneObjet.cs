using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneObjet : MonoBehaviour
{
    public Vector3 vitesseRotation;
    public float vitesseRotationMax;
    public float acceleration = 5.0f; 
    public float deceleration = 5.0f; 
    private Rigidbody rb;
    private bool demarreMoteur = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vitesseRotation = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            demarreMoteur = !demarreMoteur;
            print(demarreMoteur);
        }

        if (demarreMoteur)
        {
            // Accelerate
            vitesseRotation.y += acceleration * Time.deltaTime;
            if (vitesseRotation.y > vitesseRotationMax)
            {
                vitesseRotation.y = vitesseRotationMax;
            }
        }
        else
        {
            // Decelerate
            vitesseRotation.y -= deceleration * Time.deltaTime;
            if (vitesseRotation.y < 0)
            {
                vitesseRotation.y = 0;
            }
        }

        // Apply the rotation
        transform.Rotate(vitesseRotation * Time.deltaTime);
    }
}