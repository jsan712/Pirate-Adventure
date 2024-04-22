using UnityEngine;

public class CaptionTrigger : MonoBehaviour
{
    public string Caption;
    public float DisplayDuration;   // in seconds

    private void OnTriggerEnter(Collider other)
    {
        CaptionHandler potentionalHandler = other.GetComponent<CaptionHandler>();
        if(potentionalHandler != null)
        {
            // send caption info to caption handler
            potentionalHandler.RecieveCaption(Caption, DisplayDuration);
            gameObject.SetActive(false);
        }
    }
}
