using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour

{
    private Vector3 positionInitiale;
    public bool bonEndroit;

    AudioSource audiosource;
    public AudioClip liproll;

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AuDebutGlisser(BaseEventData eventData)
    {

        
        positionInitiale = transform.localPosition;
        bonEndroit = false;
       

        GetComponent<Collider2D>().enabled = false;
        PointerEventData pointerEventData = eventData as PointerEventData;
        Vector3 nouvellePosition = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        nouvellePosition.z = 0;
        transform.position = nouvellePosition;
        
    }

    public void AuGlisser(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        Vector3 nouvellePosition = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        nouvellePosition.z = 0;
        transform.position = nouvellePosition;

        
    }


    public void AuFinGlisser(BaseEventData eventData)
    {
          GetComponent<Collider2D>().enabled = true;

        if (!bonEndroit)
        {
            transform.localPosition = positionInitiale;
            audiosource.PlayOneShot(liproll);
            
        }

    }

}
