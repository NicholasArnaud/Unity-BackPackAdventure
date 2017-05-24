using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Backpack Saver", menuName = "GameState/Savers/BackPack Saver", order = 1)]
public class BackPackSaver : ScriptableObject
{
    private static BackPackSaver instance;
    public static BackPackSaver Instance
    {
        get
        {
            if (!instance)
                instance = Resources.FindObjectsOfTypeAll<BackPackSaver>().FirstOrDefault();
            if (!instance)
                instance = CreateInstance<BackPackSaver>();
            return instance;
        }
    }

    public void SaveBackPack(Backpack backpack, string filename)
    {        
        var path1 = Application.persistentDataPath + filename + ".json";
        var json = JsonUtility.ToJson(backpack, true);
        Debug.Log("Save Successful");
        System.IO.File.WriteAllText(path1, json);
    }

    public void TestIt()
    {
       Debug.Log("singleton is up");
    }
}
