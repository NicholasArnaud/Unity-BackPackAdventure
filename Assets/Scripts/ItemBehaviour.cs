using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item itemConfig;
    private Item _runtimeItem;

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
