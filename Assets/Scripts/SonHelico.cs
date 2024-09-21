using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonHelico : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject demarreMoteur;
    public bool demarrerMoteur;
    private TourneObjet ScriptDemarrerMoteur;
    private float vitesseRotation;
    private AudioSource audioSource;
    public AudioSource sonHelico;
    public GameObject helico; 
    private DeplacementHelico ScriptDeplacementHelico;
    public bool finJeu;

    // Start is called before the first frame update
    void Start()
    {
        ScriptDemarrerMoteur = demarreMoteur.GetComponent<TourneObjet>();
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.pitch = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        demarrerMoteur = ScriptDemarrerMoteur.demarreMoteur;
        vitesseRotation = ScriptDemarrerMoteur.vitesseRotation.y;
        finJeu = ScriptDeplacementHelico.finJeu;

        // Normaliser la vitesse de rotation à une plage entre 0 et 1
        float vitesseGeneraliser = Mathf.Clamp01(vitesseRotation / 25);

        // Ajuster en douceur le volume pour correspondre à la vitesse normalisée
        audioSource.volume = Mathf.Lerp(audioSource.volume, vitesseGeneraliser, Time.deltaTime);

        // Ajuster le pitch pour correspondre à la vitesse normalisée
        audioSource.pitch = Mathf.Lerp(0.5f, 1f, vitesseGeneraliser);

        if (demarrerMoteur)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (audioSource.mute)
                {
                    audioSource.mute = false;
                    audioSource.UnPause();
                }
                else
                {
                    audioSource.mute = true;
                    audioSource.Pause();
                }
            }
        }
        else
        {
            if (audioSource.volume <= 0.01f)
            {
                audioSource.Stop();
            }
        }

        if (audioSource.pitch > 1f)
        {
            audioSource.pitch = 1f;
        }

        if (finJeu)
        {
            sonHelico.Stop();
        }

        // Je voulais ajouter un fade out aussi, alors j'ai utilisé quelque chose d'autre
        // audioSource.volume = vitesseRotation / 50;
    }
}