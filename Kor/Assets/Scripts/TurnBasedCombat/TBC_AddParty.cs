using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_AddParty : MonoBehaviour {

    List<GameObject> partyList = new List<GameObject>();

    [Header("Max Array Size is 4")]
    public Vector2[] partyPositions;
    string[] partyNames;
    TBC_Queue tBC_Queue;

    public void Init(string[] _partyNames)
    {
        tBC_Queue = GetComponent<TBC_Queue>();
        partyNames = _partyNames;
        AddFriendToList(partyList, partyNames);
        AssignPartyToPositions(partyPositions, partyList);
        //TODO Add initialisation for Party
    }

    void AddFriendToList(List<GameObject> _partyList, string[] _partyNames)
    {
        for(int i = 0; i < _partyNames.Length; i++)
        {

            GameObject friend = Instantiate(Resources.Load("Friends\\FriendObj"), this.transform) as GameObject;
            TBC_Friend tbc_Friend = friend.GetComponent<TBC_Friend>();
            tbc_Friend.friend = Resources.Load("Friends\\" + _partyNames[i]) as Friend;
            tbc_Friend.TBC_Friend_Init();
            _partyList.Add(friend);
            tBC_Queue.AddTurnOrder(friend);


        }

    }

    void AssignPartyToPositions(Vector2[] _partyPositions, List<GameObject> _partyList)
    {
       for(int i = 0; i < _partyList.Count; i++)
        {
            _partyList[i].transform.position = _partyPositions[i];
        }
    }


}
