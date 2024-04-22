using System.Collections;
using TMPro;
using UnityEngine;

public class CaptionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _captionTextBox;

    private void Start()
    {
        _captionTextBox.enabled = false;
    }

    public void RecieveCaption(string caption, float duration)
    {
        // Put any logic for queuing or waiting or only showing one caption at a time.
        StartCoroutine(DisplayCaption(caption, duration));
    }

    private IEnumerator DisplayCaption(string caption, float duration)
    {
        _captionTextBox.text = caption;
        _captionTextBox.enabled = true;
        yield return new WaitForSeconds(duration);
        _captionTextBox.enabled = false;
    }
}
