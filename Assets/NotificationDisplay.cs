using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationDisplay : MonoBehaviour
{
    SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        DisableNotification();
    }


    public void DisplayNewSprite(Sprite newSprite)
    {
        spriteRend.sprite = newSprite;
    }

    public void DisableNotification()
    {
        spriteRend.sprite = null;
    }
}
