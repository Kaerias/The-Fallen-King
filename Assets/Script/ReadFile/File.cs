using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class File : MonoBehaviour
{

    int[] data = new int[2];

    public void WriteFile(int level, int score)
    {
        string path = "Assets/Resources/Data.txt";

        string[] lines = System.IO.File.ReadAllLines(path);
        string allString = "";
        if (lines[0] != null && lines[1] != null)
        {
            if (level != -1)
                lines[0] = level.ToString();
            if (score != -1)
                lines[1] = score.ToString();
        }
        for (int i = 0; i < lines.Length; i++)
        {
            allString += lines[i] + "\n";
        }
        System.IO.File.WriteAllText(path, allString);


        //Re-import the file to update the reference in the editor
        TextAsset asset = Resources.Load<TextAsset>("Data");
    }

    public void ReadFile()
    {
        string path = "Assets/Resources/Data.txt";

        string[] lines = System.IO.File.ReadAllLines(path);
        if (lines[0] != null && lines[1] != null)
        {
            data[0] = int.Parse(lines[0]);
            data[1] = int.Parse(lines[1]);
        }
    }

    public int GetScore()
    {
        return data[1];
    }

    public int GetScene()
    {
        return data[0];
    }
}
