using UnityEngine;

public class TBC_Player : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public Player player;

    // Update is called once per frame
    public void TBC_Player_Init()
    {
        this.gameObject.name = player.playerTitle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player.playerMenuSprite as Sprite;
    }
}
