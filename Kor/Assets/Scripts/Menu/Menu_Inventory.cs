using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Inventory : MonoBehaviour {


    
    public void InventoryMenu(RectTransform buttonParent, GameObject buttonPrefab)
    {
      foreach(RectTransform t in buttonParent)
        {
            Destroy(t.gameObject);
        }
        GridLayoutGroup glg = buttonParent.GetComponent<GridLayoutGroup>();
        glg.cellSize = new Vector2(100, glg.cellSize.y);
        foreach (Item i in Inventory._instance.items)
        {
            if (i.itemAmount > 0)
            {
                GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
                Button b = g.GetComponent<Button>();
                Text text = g.GetComponentInChildren<Text>();
                text.text = i.name + "\t\t " + i.itemAmount;
                b.onClick.AddListener(delegate { /*AssignSelectedItem(i); StartCoroutine(Targeting("ITEM"));*/ });
            }
        }
    }

}
