using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Backpack Loader", menuName = "GameState/Loaders/BackPack Loader", order = 1)]
public class BackPackLoader : ScriptableObject
{

    private static BackPackLoader instance;
    public static BackPackLoader Instance
    {
        get
        {
            if (!instance)
                instance = Resources.FindObjectsOfTypeAll<BackPackLoader>().FirstOrDefault();
            if (!instance)
                instance = CreateInstance<BackPackLoader>();
            return instance;
        }

    }

    public Backpack LoadBackPack(string filename)
    {
        var path = Application.dataPath + "/Streaming Assets/" + filename + ".json";
        var json = System.IO.File.ReadAllText(path);
        var backpack = CreateInstance<Backpack>();
        JsonUtility.FromJsonOverwrite(json, backpack);
        return backpack;
    }
}
