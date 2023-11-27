using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject OpponentArea;

    List<GameObject> cards = new List<GameObject>();

    // public modifier exposes game object in the unity editor

    // Start is called before the first frame update
    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        for (var i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity); // Unity requries you to declare if object has any rotation, which quaternion.identity in this case says we do not
            playerCard.transform.SetParent(PlayerArea.transform, false); // transform is a property that denotes where object is. In this case it will set it as child of PlayerArea.

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(OpponentArea.transform, false);
        }
    }
}

/*
    Remember that in the editor you have to drag the specific object for the script onto the "None (Object)" tab or select it from the dropdown menu, then specify the method like OnClick in the other menu.
    Try and set broad changes to the PREFAB, not the individual instance, but you can apply "override" in the inspector if you only changed an instance.
