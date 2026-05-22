using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joueur : MonoBehaviour


{
    public InputAction actionDeplacement;
    public InputAction actionRotation;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float vitesse;

    public float vitesseRotation;

     public GameObject panneauVictoire;

     public GameObject formesFin;

     AudioSource audiosource;

     public AudioClip SonVictoire;
     


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();

       

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
        float directionDeplacement = 0;
        directionDeplacement = actionDeplacement.ReadValue<float>();
        transform.Translate(Vector2.up * directionDeplacement * vitesse * Time.deltaTime);


        float rotation = 0;
        rotation = actionRotation.ReadValue<float>();
        transform.Rotate(0, 0, rotation * vitesseRotation * Time.deltaTime);


    }

     void OnTriggerEnter2D(Collider2D collision)
    {
         

        if (collision.gameObject.CompareTag("Arrivee"))
        {
            panneauVictoire.SetActive(true);
            Destroy(formesFin);
            audiosource.Stop();
            audiosource.PlayOneShot(SonVictoire);
            
            actionDeplacement.Disable();
        actionRotation.Disable();

           
        }
    }

    
    

}
