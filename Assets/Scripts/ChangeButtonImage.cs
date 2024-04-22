using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour
{
    public Sprite NewImage;
    public Button Button;
    
    public void ChangeButton()
    {
        Button.image.sprite = NewImage;
    }
}
