using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Script pour faire la gestion du compteur de temps
//lorsque le jeu démarre
//  
// Matilda Kang

public class Compteur : MonoBehaviour
{
    // Déclarer les variables
    public int temps = 120;
    public TMP_Text compteurUI;
    private DeplacementHelico ScriptDeplacementHelico;
    public bool finJeu;
    public GameObject helico; 


    void Start()
    {
        //Récupérer le script DeplacementHelico
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 
    }

    void Update()
    {
        //Récupérer la valeur de finJeu
        finJeu = ScriptDeplacementHelico.finJeu;

        //Arrêter le compteur si la fin du jeu est vrai
        if(finJeu == true)
        {
            StopCoroutine(AfficherLeTemps());
        }
    }
 
    // fonction lorsque le jeu démarre, le compteur commence
    public void DemarrerJeu()
    {
        StartCoroutine(AfficherLeTemps());
    }

    // fonction pour le faire un compteur
    IEnumerator AfficherLeTemps()
    {

        yield return new WaitForSeconds(1);
        temps--;
        compteurUI.text = temps.ToString();

        if(temps > 0)
        {
            StartCoroutine(AfficherLeTemps());
        }
        else if(temps == 0)
        {
            StopCoroutine(AfficherLeTemps());
            temps = 0;
            finJeu = true;
        }

    }

}
