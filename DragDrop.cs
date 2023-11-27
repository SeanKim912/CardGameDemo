using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    /*
    Remember to have DropZone higher than PlayerArea in Hierarchy to prevent bugs.
    When dealing with collisions you have to manage Collision Layers. Add layer for Cards and set
    card assets to that layer. Then in Project Settings > Physics 2D > Layer Collision Matrix tab,
    uncheck "Cards" to tell Unity that you don't want cards to collide with other cards.
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    /*
    Since this script is a child of the card asset itself, you won't have a GameObject to drag and bind the script to in the Unity window.
    Go to Add Component and add the Event Triggers -> Begin Drag and End Drag.
    For DropZone functionality, Add Component -> Box Collider 2D and Rigid Body 2D. Edit Collider to match dimensions of Card. In Rigid Body
    set Drag and Gravity to 0, Collision Detection to Continuous, and check X, Y, Z for constraints. Be sure to add a corresponding Box
    Collider to your DropZone.
    */

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
