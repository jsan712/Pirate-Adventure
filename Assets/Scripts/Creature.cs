using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public static bool isSpawned;
    
    [SerializeField] private AudioSource creatureRoar;
    [SerializeField] private CaptionHandler _captionHandler;
    private SkinnedMeshRenderer skinnedMeshRenderer;

    private void Start()
    {
        skinnedMeshRenderer = gameObject.transform.Find("CatFish").GetComponent<SkinnedMeshRenderer>();
        SetIsSpawn();
    }

    private void Update()
    {
        if (ObjectSelector.allCollected == true && IsSpawned() == false)
        {
            SpawnCreature();
            SetIsSpawn();
        }
    }

    public bool IsSpawned()
    {
        return isSpawned;
    }

    private bool SetIsSpawn()
    {
        if (ObjectSelector.allCollected == true)
        {
            return true;
        }
        return false;
    }

    private void SpawnCreature()
    {
        skinnedMeshRenderer.GetComponent<SkinnedMeshRenderer>().enabled = true;
        creatureRoar.enabled = true;
        _captionHandler.RecieveCaption("Oh no...", 7);
    }
}
