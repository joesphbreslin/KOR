using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_Enemy : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public Enemy enemy;

	// Update is called once per frame
	public void TBC_Enemy_Init() {
        this.gameObject.name = enemy.enemyTitle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemy.enemyMenuSprite as Sprite;		
	}
}
