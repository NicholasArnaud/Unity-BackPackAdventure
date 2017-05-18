using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour
{
    AddItem AdditionalItem = new AddItem();
    public Item itemConfig;
    private Item _runtimeItem;
    public Text ItemPicked;

    private void Start()
    {
        _runtimeItem = itemConfig;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "backpack")
        {
            AdditionalItem.Invoke(_runtimeItem);
            other.GetComponent<BackpackBehaviour>().AddToPack(_runtimeItem);
            Destroy(gameObject);
        }
    }
}
