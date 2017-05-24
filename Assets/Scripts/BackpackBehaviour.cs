using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackBehaviour : MonoBehaviour
{

    [SerializeField]
    AddItem AdditionalItem = new AddItem();

    public Backpack BackpackConfig;
    public List<Item> Inventory;
    public GameObject ItemPrefab;
    public Text ChosenItemText;
    public Text ItemsInPackText;
    public Text SaveText;

    private int _capacity;
    private int saveNum;

    private void Start()
    {
        saveNum = 0;
        _capacity = BackpackConfig.Capacity;
        BackpackConfig = Instantiate(BackpackConfig);
        Inventory = BackpackConfig.Inventory;
    }

    public void AddToPack(Item item)
    {
        if (Inventory.Count <= _capacity)
        {
            AdditionalItem.Invoke(item);
            Inventory.Add(item);
        }
    }

    public void PlaceItem()
    {
        if(Inventory.Count == 0)
            return;
        
        var position = this.transform.position;
        position.x++;        
        var newItem = Instantiate(ItemPrefab, position, Quaternion.identity);
        newItem.GetComponent<ItemBehaviour>().itemConfig = Inventory[0];
        newItem.name = Inventory[0].name + "(Clone)";
        Inventory.RemoveAt(0);
        ItemsInPackText.text = "Items:";
        foreach (var item in Inventory)
        {
            AdditionalItem.Invoke(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Inventory.Count == 0)
                return;
            Inventory.RemoveAt(0);
            ItemsInPackText.text = "Items:";
            foreach (var item in Inventory)
            {
                AdditionalItem.Invoke(item);
            }
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            saveNum += 1;
            Backpack saveBackpack = ScriptableObject.CreateInstance<Backpack>();
            saveBackpack.Inventory = Inventory;
            BackPackSaver.Instance.SaveBackPack(saveBackpack, "Current Backpack");
            SaveText.text = "Saved " + saveNum;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Inventory = BackPackLoader.Instance.LoadBackPack("Current Backpack").Inventory;
            ItemsInPackText.text = "Items:";
            foreach (var item in Inventory)
            {
                AdditionalItem.Invoke(item);
            }
        }
    }

    public void ItemPicked(Item item)
    {
        ChosenItemText.text = item.name + "\n";
    }

    public void ItemInPackText(Item item)
    {
        ItemsInPackText.text += item.name + "\n";
    }
   
}
