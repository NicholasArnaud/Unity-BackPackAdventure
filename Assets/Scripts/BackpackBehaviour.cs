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
    }
}
