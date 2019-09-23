using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Item Reference")]
public class PlayerItem : ScriptableSingleton<PlayerItem>
{
    [SerializeField]
    private Item item;
    public Item CurrentItem
    {
        get { return item; }
        set
        {
            if (item == null)
                item = value;
        }
    }

    public bool ChangeItem(Item newItem)
    {
        if (item != null)
            return false;

        CurrentItem = newItem;
        return true;
    }

    public Item bucketItem;

    public void DestroyItem()
    {
        item = null;
    }
}
