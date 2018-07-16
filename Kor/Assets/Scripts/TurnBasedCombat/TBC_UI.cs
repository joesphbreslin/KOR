using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBC_UI : MonoBehaviour {

    public Image image;
    public Text text;
    string enemyTag = "TBC_Enemy";
    string playerTag = "TBC_Player";
    string friendTag = "TBC_Friend";


    TBC_Manager tBC_Manager;
    TBC_Queue tBC_Queue;

    private void Start()
    {
        tBC_Manager = GetComponent<TBC_Manager>();
        tBC_Queue = GetComponent<TBC_Queue>();
    }
    //This is a temp for UI purposes but also handles turn Order Indexing
    public void Next()
    {
        if (tBC_Manager.turnOrderIndex != tBC_Queue.turnOrder.Count - 1)
        {
            tBC_Manager.turnOrderIndex++;
        }
        else
        {
            tBC_Manager.turnOrderIndex = 0;
        }

        UpdateUi();
    }

    public void UpdateUi()
    {
        GameObject g = tBC_Queue.turnOrder[tBC_Manager.turnOrderIndex];
        if(g.tag == enemyTag)
        {
            Debug.Log("Enemy is Selected");
            UpdateImage(g, enemyTag, image);
            UpdateText(g,enemyTag,text);
        }
        else if (g.tag == playerTag)
        {
            Debug.Log("Player Selected");

            UpdateImage(g, playerTag, image);
            UpdateText(g, playerTag, text);
        }
        else
        {
            Debug.Log("Friend is Selected");

            UpdateImage(g, friendTag, image);
            UpdateText(g, friendTag, text);
        }
    }

    void UpdateImage(GameObject g,string tag, Image img)
    {
        if (tag == enemyTag)
            img.sprite = g.GetComponent<TBC_Enemy>().enemy.enemyMenuSprite as Sprite;
        else if (tag == playerTag)
            img.sprite = g.GetComponent<TBC_Player>().player.playerMenuSprite as Sprite;
        else
            img.sprite = g.GetComponent<TBC_Friend>().friend.friendMenuSprite as Sprite;
    }

    void UpdateText(GameObject g, string tag, Text txt)
    {
        if (tag == enemyTag)
            txt.text = g.GetComponent<TBC_Enemy>().enemy.name;
        else if (tag == playerTag)
            txt.text = g.GetComponent<TBC_Player>().player.name;
        else
            txt.text = g.GetComponent<TBC_Friend>().friend.name;
    }
}
