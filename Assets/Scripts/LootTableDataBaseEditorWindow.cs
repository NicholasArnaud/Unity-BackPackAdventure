using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

#if UNITY_EDITOR
//Work teacher worked on in front of class
public class LootTableDataBaseEditorWindow : EditorWindow
{
    private GUIStyle Header = new GUIStyle();
    private static string path;
    public List<DropTable> tables;
    public List<string> allFiles;


    [MenuItem("Tools/LootTableDataBase")]
    private static void Init()
    {
        var window = GetWindow(typeof(LootTableDataBaseEditorWindow));       
        window.Show();
    }

    public void Populate()
    {
        tables = new List<DropTable>();
        allFiles = new List<string>();
        path = Application.dataPath + "/Resources/Tables/";
        allFiles.AddRange(Directory.GetFiles(path, "*.asset"));
        foreach (var file in allFiles)
        {
            var relpath = file.Substring(path.Length - "Assets/Resources/Tables/".Length);
            var table = AssetDatabase.LoadAssetAtPath<DropTable>(relpath);
            tables.Add(table);
        }
    }

    private void OnGUI()
    {
        Populate();
        Header.alignment = TextAnchor.UpperCenter;
        Header.fontStyle = FontStyle.BoldAndItalic;
        Header.fontSize = 25;
        Header.normal.textColor = Color.cyan;
        GUILayout.Label("Loot Database", Header);
        GUILayout.Space(25);
        if (GUILayout.Button("This is a Button"))
        {}
        foreach (var file in allFiles)
            EditorGUILayout.TextField("Table File:: ", file);
    }
}
#endif