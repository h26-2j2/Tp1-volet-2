using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour

{

 public GameObject formeMise;
    public GameObject formeManquante;
    AudioSource audiosource;
    public AudioClip liproll;


    public AudioClip boop;

       public AudioClip[] encouragement;
   
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

     public void AuDeposer(BaseEventData eventData)
    {

        PointerEventData pointerEventData = eventData as PointerEventData;

        GameObject objetDepose = pointerEventData.pointerDrag;


        if(objetDepose == formeMise && transform.parent.gameObject.CompareTag("Obstacle"))
        {   
            
              objetDepose.transform.SetParent(transform);
        objetDepose.transform.localPosition = Vector3.zero;
        objetDepose.GetComponent<Collider2D>().enabled = false;  
        
        audiosource.PlayOneShot(boop);
     int random = Random.Range(0,encouragement.Length);
           audiosource.PlayOneShot(encouragement[random]);
        
            
        Destroy(transform.parent.gameObject,1.2f);
         
        
      
      

        
        
     
           

        
        
        
        //Aide avec Intelligence artificielle à partir d'ici
        DragAndDrop dragScript = objetDepose.GetComponent<DragAndDrop>();
        if (dragScript != null)
        {
            dragScript.bonEndroit = true;
            /*audiosource.PlayOneShot(liproll);*/

            
        }//


        }

      
    }

   

    
}
