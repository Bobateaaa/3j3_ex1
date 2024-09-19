using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int temps = 100;
    public TMP_Text compteurUI;
    public Image jaugeEssence;


    void Start()
    {
        //to create a countdown once a second
        //InvokeRepeating("afficherLeTemps", 0, 1);
        jaugeEssence.fillAmount = 0.5f;

    }

    //Putting condition onClick() button and sliding GameManager in the condition for onClick()
    public void DemarrerJeu()
    {
        StartCoroutine(afficherLeTemps());
    }

    //if not using StartCoroutine change to void and remove yeild return and
    // the other start coroutine condition and put in start and no demarrer jeu
    IEnumerator afficherLeTemps()
    {
        yield return new WaitForSeconds(1);
        temps--;
        compteurUI.text = temps.ToString();

        if(temps > 0)
        {
            StartCoroutine(afficherLeTemps());
        }

    }


    void Update()
    {
        
    }
}
