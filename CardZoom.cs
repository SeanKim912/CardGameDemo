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
    Drag script onto prefab inspector, add event handlers Pointer Enter and Pointer Exit in Card prefab, and tie to relevant ZoomCard.PointerEnter/Exit
    script and handler in the dropdown menu.
    */
    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false); // Here you will set the zoomed card to be instantiated within the canvas (the parent)
        zoomCard.layer = LayerMask.NameToLayer("Zoom"); // Sets layer to Zoom so it won't collide, which you should create in Inspector
        /*
        Make sure to uncheck Zoom x UI and Cards in Project Settings > Layer Collision Matrix so they don't mess with each other

        To make cardZoom go away once you start dragging the card, add another method to Begin Drag for Card1 and call the
        CardZoom.OnHoverExit so it destroys the cardZoom
        */

        RectTransform rect = zoomCard.GetComponent<RectTransform>(); // You can already see this RectTransform component in the inspector before you even grabbed it here
        rect.sizeDelta = new Vector2(240, 344);

        /*
        The zoomCard will flash on and off because essentially it's being recreated for every collision and the game doesn't know
        if it's hovering over the original card or the zoomCard. Adding 250 units to the Instantiate y position above, for example,
        causes zoomCard to instantiate in a place physically away from the original so the game doesn't get confused. Will have to
        tailor code specifically depending on situation.
         */
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}

