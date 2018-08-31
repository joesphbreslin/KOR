using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform buttonParent;
    Menu_Inventory menu_Inventory;

    void AddMainMenuButtons() {
        GridLayoutGroup glg = buttonParent.GetComponent<GridLayoutGroup>();
        glg.cellSize = new Vector2(300, glg.cellSize.y);
        DestroyButtonObjects();
        Settings();
        Inventory();
        Equipment();
        Save();
    }
    public void DestroyButtonObjects()
    {
        foreach (RectTransform t in buttonParent)
        {
            Destroy(t.gameObject);
        }
    }
    // Use this for initialization
    void Settings () {
        GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
        Button b = g.GetComponent<Button>();
        Text text = g.GetComponentInChildren<Text>();
        text.text = "Settings";
        b.onClick.AddListener(delegate { /*StartCoroutine(Targeting("SPECIAL"));*/ });
    }
	
	// Update is called once per frame
	void Inventory () {
        GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
        Button b = g.GetComponent<Button>();
        Text text = g.GetComponentInChildren<Text>();
        text.text = "Inventory";
        b.onClick.AddListener(delegate { menu_Inventory.InventoryMenu(buttonParent, buttonPrefab); });
    }

    void Equipment()
    {
        GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
        Button b = g.GetComponent<Button>();
        Text text = g.GetComponentInChildren<Text>();
        text.text = "Equipment";
        b.onClick.AddListener(delegate { /*StartCoroutine(Targeting("SPECIAL"));*/ });
    }

    void Save()
    {
        GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
        Button b = g.GetComponent<Button>();
        Text text = g.GetComponentInChildren<Text>();
        text.text = "Save";
        b.onClick.AddListener(delegate { /*StartCoroutine(Targeting("SPECIAL"));*/ });
    }

    private void Start()
    {
        menu_Inventory = GetComponent<Menu_Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddMainMenuButtons();
        }
    }
}
