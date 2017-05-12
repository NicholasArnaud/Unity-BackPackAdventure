using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackBehaviour : MonoBehaviour
{
    public Backpack BackpackConfig;
    public List<Item> Invetory;
    private int _capacity;

    private void Start()
    {
        _capacity = BackpackConfig.Capacity;
        BackpackConfig = Instantiate(BackpackConfig);
        Invetory = BackpackConfig.Inventory;
    }

    public void AddToPack(Item item)
    {
        if (Invetory.Count <= _capacity)
            Invetory.Add(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invetory.RemoveAt(0);
        }
    }
}
