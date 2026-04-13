using UnityEngine;
using UnityEngine.SceneManagement;
public class GestionRoute : MonoBehaviour





{

    public string intro = "Intro";


    public GameObject PanneauVictoire;

    public GameObject PanneauDefaite;

    public AudioClip SonEchec;
    public AudioClip SonVictoire;
    public AudioClip SonMusique;

    AudioSource audiosource;



    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void AuClicVictoire()
    {

        PanneauVictoire.SetActive(true);

        audiosource.PlayOneShot(SonVictoire);
        Invoke("RedemarrerScene", 2f);




    }

    public void AuClicDefaite()
    {
        PanneauDefaite.SetActive(true);
        audiosource.PlayOneShot(SonEchec);
    }

    public void AuDebutSurvol()
    {
        anim.Play("Couleur route");
        anim.Play("Couleur route 2");
        anim.Play("Couleur route 3");

    }

    public void AuFinSurvol()
    {
        anim.Play("Idle");
    }

     public void RedemarrerSceneClic()
    {
         SceneManager.LoadScene(intro);
    }




}
