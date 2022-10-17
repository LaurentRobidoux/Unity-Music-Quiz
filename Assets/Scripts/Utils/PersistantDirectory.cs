using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PersistantDirectory
{
    public string folderName;

    public string DataPath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, folderName);
        }
    }

    public string BuildPath(string filename)
    {
        return Path.Combine(DataPath, filename);
    }

    public void CreateDirectory()
    {
        Directory.CreateDirectory(DataPath);
    }
}