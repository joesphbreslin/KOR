using UnityEngine;

public class TBC_Friend : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public Friend friend;

    public void TBC_Friend_Init()
    {
        this.gameObject.name = friend.friendTitle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = friend.friendMenuSprite as Sprite;
    }
}

