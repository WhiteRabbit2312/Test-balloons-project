using UnityEngine;
using System.IO;
using UnityEngine;

public class DeleteJson : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerdata.json");
    }
    
    public void DeleteJsonFile()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
