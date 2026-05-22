using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Voiture : MonoBehaviour
{
    public float vitesse;

    public float vitesseRotation;

    public int vies = 3;

    public float temps = 0;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    AudioSource audiosource;


    public InputAction actionDeplacement;

    public InputAction actionRotation;

    public GameObject panneauBon;

    public GameObject panneauMauvais;

    public GameObject panneauDefaite;

    public GameObject panneauVictoire;

    public GameObject ligneArrivee;

    public GameObject canvas;

    public AudioClip SonMauvais;
    public AudioClip SonBon;



    public AudioClip SonVictoire;


    public AudioClip[] encouragement;



    public List<Color> couleurs;
    public int indexQuestion = 0;

    public TMP_Text texteVies;
    public TMP_Text texteTemps;











    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();
        texteVies.text = $"{vies}";
        ChangerCouleur();
    }

    void OnEnable()
    {
        actionDeplacement.Enable();
        actionRotation.Enable();
    }

    void OnDisable()
    {
        actionDeplacement.Disable();
        actionRotation.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        temps += Time.deltaTime;
        texteTemps.text = $"{temps:F1}";

        float directionDeplacement = 0;
        directionDeplacement = actionDeplacement.ReadValue<float>();
        transform.Translate(Vector2.up * directionDeplacement * vitesse * Time.deltaTime);


        float rotation = 0;
        rotation = actionRotation.ReadValue<float>();
        transform.Rotate(0, 0, rotation * vitesseRotation * Time.deltaTime);






    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        Color cBarriere = collision.gameObject.GetComponent<SpriteRenderer>().color;
        Color cVoiture = spriteRenderer.color;

        //Cette portion de code a été générée par intelligence artificielle, 
        // elle compare les couleurs de la barrière et de la voiture, en tenant compte d'une petite marge d'erreur pour les valeurs de couleur.
        float eps = 0.01f;

        if (
            Mathf.Abs(cBarriere.r - cVoiture.r) < eps &&
            Mathf.Abs(cBarriere.g - cVoiture.g) < eps &&
            Mathf.Abs(cBarriere.b - cVoiture.b) < eps
        )
        {
            //C'est bon

            panneauBon.SetActive(true);
            Invoke("EnleverPanneau", 0.5f);
            audiosource.PlayOneShot(SonBon);
            int random = Random.Range(0, encouragement.Length);

            audiosource.PlayOneShot(encouragement[random]);



        }
        else
        {
            panneauMauvais.SetActive(true);
            Invoke("EnleverPanneau", 0.5f);
            audiosource.PlayOneShot(SonMauvais);

            vies--;
            texteVies.text = $"{vies}";
        }




        indexQuestion++;
        ChangerCouleur();

        if (vies <= 0)
        {
            panneauDefaite.SetActive(true);




        }


        if (collision.gameObject.CompareTag("Arrivee"))
        {

            panneauVictoire.SetActive(true);
            panneauMauvais.SetActive(false);
            panneauDefaite.SetActive(false);

            canvas.SetActive(false);

            audiosource.Stop();
            audiosource.PlayOneShot(SonVictoire);
            actionDeplacement.Disable();
            actionRotation.Disable();









        }


        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.gameObject.CompareTag("Barriere"))
            {
                Destroy(collision.transform.parent.gameObject, 0.3f);
            }
        }















    }

    void EnleverPanneau()
    {
        panneauBon.SetActive(false);
        panneauMauvais.SetActive(false);
    }

    void ChangerCouleur()
    {
        if (indexQuestion * 2 + 1 < couleurs.Count)
        {

            int positionAleatoire = Random.Range(indexQuestion * 2, indexQuestion * 2 + 2);
            Color couleurAleatoire = couleurs[positionAleatoire];
            spriteRenderer.color = couleurAleatoire;
        }
    }


    public void RedemarrerSceneClic()
    {
        SceneManager.LoadScene("Niveau 2");
    }

    public void NiveauSuivant()
    {
        SceneManager.LoadScene("Niveau 3");
    }


}
