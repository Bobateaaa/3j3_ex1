using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pour faire la gestion du son de l'hélicoptère et de la scene
//
// Matilda Kang

public class SonHelico : MonoBehaviour
{
    // Déclarer les variables
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
        // Récupérer les scripts
        ScriptDemarrerMoteur = demarreMoteur.GetComponent<TourneObjet>();
        ScriptDeplacementHelico = helico.GetComponent<DeplacementHelico>(); 

        // Initialiser les variables
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.pitch = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        // Récupérer les valeurs de demarrerMoteur, vitesseRotation et finJeu
        demarrerMoteur = ScriptDemarrerMoteur.demarreMoteur;
        vitesseRotation = ScriptDemarrerMoteur.vitesseRotation.y;
        finJeu = ScriptDeplacementHelico.finJeu;

        // Normaliser la vitesse de rotation à une plage entre 0 et 1
        float vitesseGeneraliser = Mathf.Clamp01(vitesseRotation / 25);

        // Ajuster en douceur le volume pour correspondre à la vitesse normalisée
        audioSource.volume = Mathf.Lerp(audioSource.volume, vitesseGeneraliser, Time.deltaTime);

        // Ajuster le pitch pour correspondre à la vitesse normalisée
        audioSource.pitch = Mathf.Lerp(0.5f, 1f, vitesseGeneraliser);

        // Si le moteur est démarré, jouer le son
        if (demarrerMoteur)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Si la touche M est enfoncée, activer ou désactiver le son
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (audioSource.mute) // Si le son est désactivé, activer le son
                {
                    audioSource.mute = false;
                    audioSource.UnPause();
                }
                else //désactiver le son
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

        // Le pitch ne doit pas dépasser 1
        if (audioSource.pitch > 1f)
        {
            audioSource.pitch = 1f;
        }

        // Si la fin du jeu est vrai, arrêter le son pour l'hélico
        if (finJeu)
        {
            sonHelico.Stop();
        }
    }
}