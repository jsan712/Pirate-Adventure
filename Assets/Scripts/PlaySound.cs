using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    public void PlaySoundEffect()
    {
        clickSound.Play();
    }
}
