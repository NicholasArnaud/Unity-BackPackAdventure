using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;               // Change

public class BackpackBehaviour : MonoBehaviour
{
    // Change ______________________________________________________________________
    [System.Serializable]
    public class OnBackPackChange : UnityEvent
    {
    }
    public OnBackPackChange onBackPackChange;

    [System.Serializable]
    public class OnBackPackChangeDup : UnityEvent
    {
    }

    public OnBackPackChangeDup onBackPackChangeDup;



    public Backpack BackpackConfig;
    public List<Item> Invetory;
    public GameObject ItemPrefab;

    private int _capacity;

    private void Awake()
    {
        onBackPackChangeDup.AddListener(AddToPack());
        onBackPackChange.AddListener(PlaceItem);
    }

    private void Start()
    {
        _capacity = BackpackConfig.Capacity;
        BackpackConfig = Instantiate(BackpackConfig);
        Invetory = BackpackConfig.Inventory;
    }
    // End of changes ______________________________________________________________________

    public void AddToPack(Item item)
    {
        if (Invetory.Count <= _capacity)
            Invetory.Add(item);
    }

    public void PlaceItem()
    {
        if(Invetory.Count == 0)
            return;
        
        var position = this.transform.position;
        position.x++;        
        var newItem = Instantiate(ItemPrefab, position, Quaternion.identity);
        newItem.GetComponent<ItemBehaviour>().itemConfig = Invetory[0];
        newItem.name = Invetory[0].name + "(Clone)";
        Invetory.RemoveAt(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Invetory.Count == 0)
                return;
            Invetory.RemoveAt(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            var position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaceItem();
        }
    }

   
}
