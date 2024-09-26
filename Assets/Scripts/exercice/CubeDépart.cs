using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDépart : MonoBehaviour
{
    public MeshRenderer cubeRenderer;
    // Start is called before the first frame update

    public void DemarrerJeu()
    {
        cubeRenderer.material.color = Color.red;
        print("Le jeu démarre");
    }
}
