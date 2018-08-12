using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_Order : MonoBehaviour {

    public GameObject[] characters;
    public List<GameObject> lCharacters = new List<GameObject>();   

    public void PopulateList()
    {
        characters = GameObject.FindGameObjectsWithTag("TBC_Character");
        SortArray(characters); 
        for(int i = 0; i < characters.Length; i++)
        {
            lCharacters.Add(characters[i]);
            lCharacters.Reverse();
        }
        //DEBUG
        //PrintListAgility();
    }

    void SortArray(GameObject[] _characters)
    {
        int n = _characters.Length;
        for (int i = 0; i < n; i++)
        {
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (_characters[j].GetComponent<TBC_Character>().character.agility < _characters[min_idx].GetComponent<TBC_Character>().character.agility)
                    min_idx = j;

                GameObject temp = _characters[min_idx];
                _characters[min_idx] = _characters[i];
                _characters[i] = temp;
            }
        }

    }

    #region DEBUG
    void PrintListAgility()
    {
        for(int i = 0; i < lCharacters.Count; i++)
        {
            Debug.Log(lCharacters[i].GetComponent<TBC_Character>().character.agility);
        }
    }

    #endregion

}
