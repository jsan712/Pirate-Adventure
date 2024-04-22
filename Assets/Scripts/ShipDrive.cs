using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDrive : MonoBehaviour
{
    [SerializeField] private Material _hoveredMaterial;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform drivingLoc;
    [SerializeField] private AudioSource rowSound;

    private float proximity;
    private MeshRenderer _meshRenderer;
    private Material _defaultMaterial;

    //public float proximityMin=10f;
    public string Caption;
    public float DisplayDuration;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMaterial = _meshRenderer.material;
    }

    // Start is called before the first frame update
    void Start()
    {
        // proximity=1000f;
        rowSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /* void Update()
    {
        proximity= Vector3.Distance (player.transform.position, transform.position);
        if (proximity<proximityMin & Input.GetKeyDown(KeyCode.B)) ///proximity close enough and key pressed
        {
            ///var delta = drivingLoc.transform.position - player.transform.position;
            ///player.transform.position += delta * Time.deltaTime * followSpeed;  if want to try to make smooth motion into boat
            player.transform.position=drivingLoc.transform.position;
            transform.parent=player.transform;
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            transform.SetParent(null);
        }
    } */

    public void DriveBoat()
    {
        player.transform.position = drivingLoc.transform.position;
        transform.parent = player.transform;
        rowSound.enabled = true;
    }

    public void Dismount()
    {
        rowSound.enabled = false;
        transform.SetParent(null);
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
}
