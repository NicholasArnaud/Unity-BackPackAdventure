using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "DropTable")]
public class DropTable : ScriptableObject
{
    public List<ItemDrop> ItemDrops;
    public float randomRoll;    

    [Serializable]
    public class ItemDrop
    {
        public Item item;
        [Range(0f, 1f)]public float chanceToDrop;
    }
    
    public List<Item> GetDrops()
    {
        randomRoll = UnityEngine.Random.Range(0f, 1f);
        List<Item> items = new List<Item>();
        foreach (var item in ItemDrops)
        {
            if (item.chanceToDrop > randomRoll)
            {
                items.Add(item.item);                
                Debug.Log("Item " + item.item +" Spawned");               
            }
        }                
        return items;        
    }
}

[CustomEditor(typeof(DropTable))]
public class LootTableEditor : Editor
{
    string labelInfo;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var dropTable = target as DropTable;
        if (GUILayout.Button("Randomize"))
        {
            foreach (var item in dropTable.GetDrops())
            {
                labelInfo += item.name + "\n";
            }            
        }
        GUILayout.Label(labelInfo);
    }
}