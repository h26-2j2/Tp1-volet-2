using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GestionScenes : MonoBehaviour
{

    public string intro = "Intro";

    public string Scenejeu = "Niveau 1";

    public string Niveau2 = "Niveau 2";

    public string Niveau3 = "Niveau 3";


    public void demarrerJeu()
    {
        SceneManager.LoadScene(Scenejeu);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void NiveauSuivant()
    {
        SceneManager.LoadScene("Niveau 3");
    }



    public void RedemarrerJeu()
    {
        SceneManager.LoadScene("Intro");
    }



}