using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_AddPlayer : MonoBehaviour {

    public Vector2 position;
    GameObject playerOBJ;
	
	public void Init() {
        playerOBJ = Instantiate(Resources.Load("Player\\PlayerOBJ"),this.transform) as GameObject;
        playerOBJ.transform.position = position;
        Debug.Log(playerOBJ.name);
        TBC_Player tbc_player = playerOBJ.GetComponent<TBC_Player>();
        tbc_player.TBC_Player_Init();
    }
	
	
}
