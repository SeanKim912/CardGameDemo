using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    /*
    Add event handlers Pointer Enter and Pointer Exit in Card prefab, and tie to relevant ZoomCard.PointerEnter/Exit
    script and handler in the dropdown menu.
    */
    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity);
    }

    public void OnHoverExit()
    {

    }
}
