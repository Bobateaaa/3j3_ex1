using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDome : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("OuvertureDome", true);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("OuvertureDome", false);
        }
        
    }
}
