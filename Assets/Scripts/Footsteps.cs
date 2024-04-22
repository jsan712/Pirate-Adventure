using UnityEngine;

// Code adapted from Omogonix's How to Add Footsteps Sounds in Unity YouTube video.
public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footstepsSound;
    [SerializeField] private AudioSource _splashSound;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _waterMask;
    [SerializeField] private Transform _groundChecker;

    private bool _isGround;
    private bool _isWater;
    void Update()
    {
        _isGround = Physics.CheckSphere(_groundChecker.position, .5f, _groundMask);
        _isWater = Physics.CheckSphere(_groundChecker.position, .5f, _waterMask);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (_isGround == true)
            {
                footstepsSound.enabled = true;
            }
            else if (_isWater == true)
            {
                _splashSound.enabled = true;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            _splashSound.enabled = false;
        }

        /*if (_isGround == false)
        {
            _splashSound.Play();
        }*/
    }
}
