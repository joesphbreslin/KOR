using System.Collections;
using UnityEngine;

public class TBC_Targeting : MonoBehaviour {

    //what to who when 
    //This script is used for targeting character for damage or health.
    TBC_Order tBC_Order;

    public Vector2 normalScale = new Vector2(1, 1);
    public Vector2 largerScale = new Vector2(2, 2);

    public bool targeting = false;
    public int targetIndex = 0;
    public bool selected = false;

    private void Start()
    {
        tBC_Order = GetComponent<TBC_Order>();
    }

    public GameObject Target()
    {
        return tBC_Order.lCharacters[targetIndex];
    }

    void CharacterScaleDebug()
    {
        for (int i = 0; i < tBC_Order.lCharacters.Count; i++)
        {
            if (i == targetIndex)
            {
                tBC_Order.lCharacters[i].transform.localScale = largerScale;
            }
            else
            {
                tBC_Order.lCharacters[i].transform.localScale = normalScale;
            }
        }
        Debug.Log(targetIndex);
    }

    void CharacterScaleNormalize()
    {
        for (int i = 0; i < tBC_Order.lCharacters.Count; i++)
        {
            tBC_Order.lCharacters[i].transform.localScale = normalScale;
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
        }
    }

    private void Update()
    {
        if (targeting)
        {
            Navigation();
            CharacterScaleDebug();
            if (Input.GetKeyDown(KeyCode.A))
            {
                selected = true;
                targeting = false;
            }
        }
        else
        {
            CharacterScaleNormalize(); // replace eventually with functional solution
        }
    }

}
