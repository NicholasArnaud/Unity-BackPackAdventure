using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackBehaviour : MonoBehaviour
{
    public Backpack BackpackConfig;
    public List<Item> Invetory;
    public int Capacity;
    private void Start()
    {
        BackpackConfig = Instantiate(BackpackConfig);
        Invetory = BackpackConfig.CurrentBackPack;
    }

    public void AddToPack(Item item)
    {
        if (Invetory.Count <= Capacity)
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
