using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.VR.WSA;

public class ItemBehaviour : MonoBehaviour
{
    [System.Serializable]
    public class OnItemChange : UnityEvent<Collider2D>
    { }

    public Item itemConfig;
    private Item _runtimeItem;
    public OnItemChange onItemChange;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _runtimeItem = itemConfig;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "backpack")
        {
            other.GetComponent<BackpackBehaviour>().AddToPack(_runtimeItem);
            Destroy(gameObject);
        }
    }
}
