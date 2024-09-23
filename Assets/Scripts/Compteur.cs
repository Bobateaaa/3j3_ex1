using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Compteur : MonoBehaviour
{
    public int temps = 120;
    public TMP_Text compteurUI;
    private DeplacementHelico ScriptDeplacementHelico;
    public bool finJeu;
    public GameObject helico; 


    void Start()
    {
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 
    }

    void Update()
    {
        finJeu = ScriptDeplacementHelico.finJeu;

        if(finJeu == true)
        {
            StopCoroutine(AfficherLeTemps());
        }
    }
 
    public void DemarrerJeu()
    {
        StartCoroutine(AfficherLeTemps());
    }

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
