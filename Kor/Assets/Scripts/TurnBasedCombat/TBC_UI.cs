using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBC_UI : MonoBehaviour {

    public Image image;
    public Text text;
    public GameObject turnOrderParentObj;

    GameObject go;
    TBC_Manager tBC_Manager;
    TBC_Order tBC_Order;

    private void Awake()
    {
        tBC_Manager = GetComponent<TBC_Manager>();
        tBC_Order = GetComponent<TBC_Order>();
    }

    public void UpdateUi()
    {
        go = tBC_Order.lCharacters[tBC_Manager.turnOrderIndex];
        UpdateImage(go, image);
        UpdateText(go, text);
        UpdateTurnOrderImages(turnOrderParentObj, tBC_Manager.turnOrderIndex);
    }

    void UpdateImage(GameObject g, Image img)
    {
        img.sprite = g.GetComponent<TBC_Character>().character.menuSprite as Sprite;
    }

    void UpdateText(GameObject g, Text txt)
    {     
        txt.text = g.GetComponent<TBC_Character>().character.name;
    }

    void UpdateTurnOrderImages(GameObject _turnOrderParentObj, int _turnOrderIndex)
    {
        Image[] turnOrderImages = _turnOrderParentObj.GetComponentsInChildren<Image>();
        for(int i = 0; i < tBC_Order.lCharacters.Count; i++)
        {
            int j = i + _turnOrderIndex;
            if (j >= tBC_Order.lCharacters.Count)
            { j = j - tBC_Order.lCharacters.Count;
            }
            turnOrderImages[i].sprite = tBC_Order.lCharacters[j].GetComponent<TBC_Character>().character.menuSprite as Sprite;
        }
    }

  
}
