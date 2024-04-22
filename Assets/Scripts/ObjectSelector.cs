using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public static bool allCollected = false;
    
    [SerializeField] private Camera _selectionCamera;
    [SerializeField] private CaptionHandler _captionHandler;
    [SerializeField] private AudioSource collectionSound;

    private SelectableObject _currentlyHovered;
    private FiringScript _cannon;
    private ShipDrive _boat;
    private int _chestCounter = 0;

    void Update()
    {
        Ray ray = _selectionCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5))
        {
            SelectableObject potentialSelectable = hit.collider.gameObject.GetComponent<SelectableObject>();
            FiringScript potentialCannon = hit.collider.gameObject.GetComponent<FiringScript>();
            ShipDrive potentialBoat = hit.collider.gameObject.GetComponent<ShipDrive>();

            if (potentialSelectable != null)
            {
                potentialSelectable.HoverHighlight(true);
                _currentlyHovered = potentialSelectable;
            }
            else if (potentialCannon != null)
            {
                potentialCannon.HoverHighlight(true);
                _cannon = potentialCannon;
            }
            else if (potentialBoat != null)
            {
                potentialBoat.HoverHighlight(true);
                _boat = potentialBoat;
            }
            else
            {
                _currentlyHovered?.HoverHighlight(false);
                _currentlyHovered = null;

                _cannon?.HoverHighlight(false);
                _cannon = null;

                _boat?.HoverHighlight(false);
                _boat = null;
            }
        }
        else
        {
            _currentlyHovered?.HoverHighlight(false);
            _currentlyHovered = null;

            _cannon?.HoverHighlight(false);
            _cannon = null;

            _boat?.HoverHighlight(false);
            _boat = null;
        }

        // Activating a selected object
        if (_currentlyHovered != null)
        {
            _captionHandler.RecieveCaption(_currentlyHovered.Caption, _currentlyHovered.DisplayDuration);
            
            // Handle chest collection
            if (_currentlyHovered.gameObject.CompareTag("Chest") && Input.GetKeyDown(KeyCode.E))
            {
                collectionSound.Play();
                _currentlyHovered.gameObject.SetActive(false);
                _chestCounter++;
            }
        }

        // Handle firing cannon
        if (_cannon != null)
        {
            _captionHandler.RecieveCaption(_cannon.Caption, _cannon.DisplayDuration);

            if (Input.GetKeyDown(KeyCode.E))
            {
                _cannon.CannonFire();
            }
        }

        // Handle driving the boat
        if (_boat != null)
        {
            _captionHandler.RecieveCaption(_boat.Caption, _boat.DisplayDuration);

            if (Input.GetKeyDown(KeyCode.B))
            {
                _boat.DriveBoat();
                _captionHandler.RecieveCaption("", 5);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                _boat.Dismount();
            }
        }

        // Handle ending game
        if (_chestCounter == TreasureChest._numChests)
        {
            allCollected = true;

        }
    }
}
