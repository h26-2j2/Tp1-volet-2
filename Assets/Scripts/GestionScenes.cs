using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GestionScenes : MonoBehaviour
{

public string intro = "Intro";

public string Scenejeu = "Niveau 1";


public void demarrerJeu()
{
     SceneManager.LoadScene(Scenejeu);
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
           
        
    }

    void RedemarrerScene()
    {
        
    }

    

}