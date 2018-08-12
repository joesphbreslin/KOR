using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Types;

public class TBC_MenuLogic : MonoBehaviour {

    //global variables for Targeting IEnumerator
    public Item selectedItem;
    public Specials selectedSpecial;
    TBC_Character targetCharacter;
    TBC_Character attackingCharacter;
    public Vector3 arrowOffset;
    public GameObject arrow;

    TBC_Order tBC_Order;
    TBC_Manager tBC_Manager;
    TBC_Targeting tBC_Targeting;

    public GameObject buttonPrefab;
    public GameObject target;
    public float attackTime = 2f;
    string[] menuTexts = { "Attack", "Special", "Skill", "Item" };
    public RectTransform buttonParent;
    public float targetOffsetX = 1;
    public float speed = 1f;
    #region Targeting
    //Targeting variables
    bool selected = false, targeting = false;
    int targetIndex = 0;
    GameObject traumaObj;
    //Targeting functions
    void SelectTargetInput()
    {
        Navigation();
        if (Input.GetKeyDown(KeyCode.A))
        {
            selected = true;
            targeting = false;
        }
    }
    void Navigation()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (targetIndex <= 0)
            {
                targetIndex = tBC_Order.lCharacters.Count - 1;
            }
            else
            {
                targetIndex--;
            }
            arrow.transform.position = tBC_Order.lCharacters[targetIndex].transform.position + arrowOffset;
            Debug.Log(tBC_Order.lCharacters[targetIndex].name);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (targetIndex != tBC_Order.lCharacters.Count - 1)
            {
                targetIndex++;
            }
            else
            {
                targetIndex = 0;
            }
            arrow.transform.position = tBC_Order.lCharacters[targetIndex].transform.position + arrowOffset;
            Debug.Log(tBC_Order.lCharacters[targetIndex].name);
        }
        arrow.transform.position = tBC_Order.lCharacters[targetIndex].transform.position + arrowOffset;

    }
    #endregion
    #region WIDTH
    public RectTransform menuRectTransform;
    public float mod = 1f;

    Vector2 standardLocation;
    Vector2 targetLocation;
    Vector2 smoothTarget;

    Vector2 singleCol;
    Vector2 doubleCol;

  

    public float offScreenXSubtractModifier = -300;

    void MenuSizeDecrease(bool _isSingleCol)
    {
        if (!_isSingleCol)
        {
            menuRectTransform.sizeDelta = doubleCol;
        }
        else
        {
            menuRectTransform.sizeDelta = singleCol;
        }
    }

    void ScaleUpScrollRect(bool _isSingleCol)
    {
        if (!_isSingleCol)
        {
            while (menuRectTransform.sizeDelta.x < 240)
            {
                menuRectTransform.sizeDelta = new Vector3(menuRectTransform.sizeDelta.x + mod, menuRectTransform.sizeDelta.y);
            }
        }
        else
        {
            while (menuRectTransform.sizeDelta.x > 120)
            {
                menuRectTransform.sizeDelta = new Vector3(menuRectTransform.sizeDelta.x - mod, menuRectTransform.sizeDelta.y);
            }
        }
    }
    #endregion
    #region START
    private void Start()
    {     
        tBC_Order = GetComponent<TBC_Order>();
        tBC_Manager = GetComponent<TBC_Manager>();

        tBC_Targeting = GetComponent<TBC_Targeting>();
        standardLocation = new Vector2(menuRectTransform.anchoredPosition.x, menuRectTransform.anchoredPosition.y);
        targetLocation = new Vector2(menuRectTransform.anchoredPosition.x - offScreenXSubtractModifier, menuRectTransform.anchoredPosition.y);
        smoothTarget = standardLocation;
        traumaObj = GameObject.FindGameObjectWithTag("Manager");

        singleCol = menuRectTransform.sizeDelta;
        doubleCol = new Vector2(menuRectTransform.sizeDelta.x + menuRectTransform.sizeDelta.x, menuRectTransform.sizeDelta.y);

        Menu();
    }
    #endregion

    
    private void Update()
    {
        SelectTargetInput();
        menuRectTransform.anchoredPosition = Vector2.Lerp(menuRectTransform.anchoredPosition, smoothTarget, Time.deltaTime * 10);
    }


    public void Menu()
    {
        //Menu Buttons, text and Event + event index
        arrow.SetActive(false);
        DestroyButtonObjects();                             //Destroy exisiting buttons
        smoothTarget = OffScreenTargetPosition(false);      //Move Menu Onto the screen
        MenuSizeDecrease(true);                             //Scale to singleCol       
        #region AddAllMenuButtonsAssignButtonText&Events
        for (int i = 0; i < menuTexts.Length; i++) {        
            GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
            Button b = g.GetComponent<Button>();
            Text text = g.GetComponentInChildren<Text>();
            text.text = menuTexts[i];
            #region delegates
            switch (i)
            {
                case 0:

                    b.onClick.AddListener(delegate { StartCoroutine(Targeting("ATTACK")); });                 
                    break;
                case 1:
                    b.onClick.AddListener(delegate { SpecialButton(); });
                    break;
                case 2:
                    //b.onClick.AddListener(delegate {  });
                    break;
                case 3:
                    b.onClick.AddListener(delegate { ItemButton(); });
                    break;
                default:
                    break;
            }
            #endregion
        }
        #endregion            
    }

    public void DeathCheck()
    {
        if (targetCharacter.hitPoints <= 0)
        {
            Debug.Log(target + " has been eliminated");
            tBC_Order.lCharacters.Remove(tBC_Order.lCharacters[targetIndex]);
            Destroy(target);
        }
        
    }

    public IEnumerator Targeting(string eventType)
    {

        arrow.SetActive(true);

        yield return new WaitForSeconds(0);

        if (!selected)
        {
            arrow.SetActive(true);
            smoothTarget = OffScreenTargetPosition(true);
            targeting = true;
            StartCoroutine(Targeting(eventType));
        }
        else
        {
            arrow.SetActive(false);
            selected = false;
            target = tBC_Order.lCharacters[targetIndex];
            targetCharacter = target.GetComponent<TBC_Character>();
            attackingCharacter = tBC_Order.lCharacters[tBC_Manager.turnOrderIndex].GetComponent<TBC_Character>();
            switch (eventType)
            {
                case "ATTACK":
                        StartCoroutine(MoveTowards("ATTACK"));
                    break;
                case "SPECIAL":
                    Special();
                    break;
                case "SKILL":
                    Skill();
                    break;
                case "ITEM":
                    Item();
                    break;
                default:
                    break;
            }
           // DeathCheck();    
            StartCoroutine(tBC_Manager.NextPlayer(2f));
            Menu();

        }
    }

    public void SpecialButton() {

        DestroyButtonObjects();
        smoothTarget = OffScreenTargetPosition(false);
        MenuSizeDecrease(false);
        Specials[] specials = tBC_Order.lCharacters[tBC_Manager.turnOrderIndex].GetComponent<TBC_Character>().specials;

        if (specials.Length != 0)
        {
            foreach (Specials s in specials)
            {
                GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
                Button b = g.GetComponent<Button>();
                Text text = g.GetComponentInChildren<Text>();
                text.text = s.name;
                //SwitchButtonHandler(0);}
                b.onClick.AddListener(delegate { AssignSelectedSpecial(s); StartCoroutine(Targeting("SPECIAL")); });
            }
        }
        else
            Menu();
    } 
    public void SkillButton() {
        //foreach Skill in current character, Display Skills
        //Each Skill has same output but different variables inform output function. 
    }
    public void ItemButton() {
        DestroyButtonObjects();
        smoothTarget = OffScreenTargetPosition(false);
        MenuSizeDecrease(false);
        foreach (Inventory._Item i in Inventory._instance.items)
        {
            GameObject g = Instantiate(buttonPrefab, buttonParent.transform, false) as GameObject;
            Button b = g.GetComponent<Button>();
            Text text = g.GetComponentInChildren<Text>();
            text.text = i.item.name + "\t\t " + i.Amount;
            //SwitchButtonHandler(0);}
            b.onClick.AddListener(delegate { AssignSelectedItem(i.item); StartCoroutine(Targeting("ITEM")); });
        }
    }

    //Action Logic TODO Pass in charact, Item and special paramaters
    public void Attack()
    {
        targetCharacter.hitPoints -= attackingCharacter.attack;
        tBC_Order.lCharacters[tBC_Manager.turnOrderIndex].GetComponent<TBC_Character>().animator.SetTrigger("Attack");
        Debug.Log(attackingCharacter.name + " is attacking " + targetCharacter.name);

        traumaObj.GetComponent<Trauma>().trauma = .7f;
    }

    public IEnumerator MoveTowards(string eventType)
    {        
        yield return new WaitForSeconds(0);
        float step = speed * Time.deltaTime;
        Vector2 moveTowardsTarget = attackingCharacter.GetComponent<TBC_Character>().characterType == ECharacterType.ENEMY ? new Vector2(targetCharacter.transform.position.x + targetOffsetX, targetCharacter.transform.position.y) : new Vector2(targetCharacter.transform.position.x - targetOffsetX, targetCharacter.transform.position.y);

        if (Vector2.Distance(attackingCharacter.transform.position, moveTowardsTarget) > float.Epsilon)
        {
            attackingCharacter.transform.position = Vector3.MoveTowards(attackingCharacter.transform.position, moveTowardsTarget, step);
            StartCoroutine(MoveTowards(eventType));
        }
        else
        {
            if (eventType == "ATTACK")
                Attack();
            yield return new WaitForSeconds(1);
            StartCoroutine(MoveBack());
        }
    }

    public IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(0);

        float step = speed * Time.deltaTime;
        Vector2 moveTowardsTarget = attackingCharacter.GetComponent<TBC_Character>().characterType == ECharacterType.ENEMY ? new Vector2(targetCharacter.transform.position.x - targetOffsetX, targetCharacter.transform.position.y) : new Vector2(targetCharacter.transform.position.x + targetOffsetX, targetCharacter.transform.position.y);
        if (Vector2.Distance(attackingCharacter.transform.position, attackingCharacter.GetComponent<TBC_Character>().returnPos) > float.Epsilon)
        {
            attackingCharacter.transform.position = Vector3.MoveTowards(attackingCharacter.transform.position, attackingCharacter.GetComponent<TBC_Character>().returnPos, step);
            StartCoroutine(MoveBack());
        }
    }

    public void Special()
    {
        GameObject g = Instantiate(selectedSpecial.particleSystem, transform, false) as GameObject;
        g.transform.position = new Vector3(targetCharacter.transform.position.x, targetCharacter.transform.position.y + 1, targetCharacter.transform.position.z);
        Debug.Log(attackingCharacter.name + " is using " + selectedSpecial.name + " on " + targetCharacter.name);
    }
    public void Skill()
    {

    }
    public void Item()
    {
        GameObject g = Instantiate(selectedItem.particleSystem, transform, false) as GameObject;
        g.transform.position = new Vector3(targetCharacter.transform.position.x, targetCharacter.transform.position.y + 1, targetCharacter.transform.position.z);
        Debug.Log(attackingCharacter.name + " is using " + selectedItem.name + " on " + targetCharacter.name);
    }

    void DestroyButtonObjects()
    {
        foreach (RectTransform t in buttonParent)
        {
            Destroy(t.gameObject);
        }
    }

    Vector2 OffScreenTargetPosition(bool _isStandard)
    {
        if (_isStandard)
        {
            return targetLocation;          
        }
        else
        {
            return standardLocation;
        }
    }

    //Update global variables
    void AssignSelectedSpecial(Specials _s)
    {
        selectedSpecial = _s;
    }
    void AssignSelectedItem(Item _i)
    {
        selectedItem = _i;
    }

}
