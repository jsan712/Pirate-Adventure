using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    [SerializeField] private AudioSource cannonSound;
    [SerializeField] private Rigidbody cannonBall;
    [SerializeField] private Transform cannonBallLoc;
    [SerializeField] private Material _hoveredMaterial;
    [SerializeField] private float moveSpeed;

    private MeshRenderer _meshRenderer;
    private Material _defaultMaterial;
    private Light myLight;

    public string Caption;
    public float DisplayDuration;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMaterial = _meshRenderer.material;
    }

    void Start()
    {
            cannonSound=GetComponent<AudioSource>();
            myLight = GetComponent<Light>();
            myLight.enabled=false;
    }

    public void HoverHighlight(bool trueFalse)
    {
        if (trueFalse)
        {
            _meshRenderer.material = _hoveredMaterial;
        }
        else
        {
            _meshRenderer.material = _defaultMaterial;
        }
    }

    public void CannonFire()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * -1);
        cannonSound.Play();
        Rigidbody projectileInstance;
        projectileInstance=Instantiate(cannonBall,cannonBallLoc.position, Quaternion.identity) as Rigidbody;
        projectileInstance.AddForce(cannonBallLoc.forward*3000f);
        myLight.enabled = true;
        Invoke("Flash",2.0f);
    }

    void Flash()
    {
        myLight.enabled = false;
    }
}
