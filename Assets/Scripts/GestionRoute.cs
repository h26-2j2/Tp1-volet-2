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
    public AudioClip Bravo;
    public AudioClip Instructions;

    AudioSource audiosource;



    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();

        if (Instructions != null)
            audiosource.PlayOneShot(Instructions);

    }

    // Update is called once per frame
    public void AuClicVictoire()
    {
        audiosource.Stop();
        PanneauVictoire.SetActive(true);

        audiosource.PlayOneShot(SonVictoire);
        audiosource.PlayOneShot(Bravo);







    }

    public void AuClicDefaite()
    {
        audiosource.Stop();
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
        SceneManager.LoadScene("Niveau 1");
    }

    public void NiveauSuivant()
    {
        SceneManager.LoadScene("Niveau 2");
    }




}
