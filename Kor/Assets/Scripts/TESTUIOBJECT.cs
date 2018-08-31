//
//Experimenting with menu items, increasing width and item count
//SPACE For Smoothing Animation
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTUIOBJECT : MonoBehaviour {
    //Global

    #region WIDTH
    public float mod = 1f;  
    bool isLarger = false;
    public RectTransform scrollRectTransform;
    void ScaleUpScrollRect(bool _isLarger)
    {
        if (isLarger)
        {
            while (scrollRectTransform.sizeDelta.x < 400)
            {
                scrollRectTransform.sizeDelta = new Vector3(scrollRectTransform.sizeDelta.x + mod, scrollRectTransform.sizeDelta.y);
            }
        }
        else
        {
            while (scrollRectTransform.sizeDelta.x > 200)
            {
                scrollRectTransform.sizeDelta = new Vector3(scrollRectTransform.sizeDelta.x - mod, scrollRectTransform.sizeDelta.y);
            }
        }
    }
    #endregion
    #region ITEMS
    public GameObject buttonPrefab;
    public RectTransform buttonParent;

    string[] items = new string[20];
    string[] mainMenu = { "ATTACK", "SPECIAL", "ITEMS", "SKILLS" };

    void CreateStringData(string[] _items)
    {
        for(int i = 0; i < _items.Length; i++)
        {
            if(i< 10)
            _items[i] = "0" + (char)i + "-" + (char)Mathf.FloorToInt(Random.Range(0,1000));
            else
                _items[i] = (char)i + "-" + (char)Mathf.FloorToInt(Random.Range(0, 1000));
        }
    }
    void DestroyMenuItems()
    {
      foreach(RectTransform t in buttonParent)
        {
            Destroy(t.gameObject);
        }
    }

    void AddMenuItems(string[] _items, GameObject _buttonParent)
    {
        DestroyMenuItems();
        for(int i = 0; i < _items.Length; i++)
        {
            GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
            Button b = g.GetComponent<Button>();
            g.GetComponentInChildren<Text>().text = _items[i];
        }
    }

    #endregion

    #region SmoothStep
    Vector2 standardLocation;
    Vector2 targetLocation;
    Vector2 target;
    bool isStandard;

    Vector2 SmoothStep(bool _isStandard)
    {
        if (_isStandard)
        {
            isStandard = false;
            return targetLocation;
        }
         else
            isStandard = true;
            return standardLocation;
    }

    #endregion

    void Start()
    {
        //Button Items_______________________________
        CreateStringData(items);
        //___________________________________________

        //SmoothStep_________________________________
        standardLocation = new Vector2(scrollRectTransform.anchoredPosition.x, scrollRectTransform.anchoredPosition.y);
        targetLocation = new Vector2(-500, standardLocation.y);
        target = standardLocation;
        isStandard = true;
    }

    void Update () {

        //WIDTH
        //___________________________________________
        if (Input.GetMouseButtonDown(0) && !isLarger)
            isLarger = true;
        else
        if (Input.GetMouseButtonDown(0) && isLarger)
            isLarger = false;

        ScaleUpScrollRect(isLarger);
        //___________________________________________


        //Button Items_______________________________

        if (Input.GetMouseButtonDown(1))
        {
            AddMenuItems(items, buttonParent.gameObject);
        }

        if (Input.GetMouseButtonDown(2))
        {
            AddMenuItems(mainMenu, buttonParent.gameObject);
        }

        //___________________________________________
        if(Input.GetKeyDown(KeyCode.Space))
        target = SmoothStep(isStandard);

        scrollRectTransform.anchoredPosition = Vector2.Lerp(scrollRectTransform.anchoredPosition, target, Time.deltaTime *20);
         
    }


}
