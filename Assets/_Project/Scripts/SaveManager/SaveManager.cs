using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public DataContainer data;
    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        savePath = Application.persistentDataPath + "/SaveFile.json";

        if (File.Exists(savePath))
            LoadFile();
        else
            data = new DataContainer(); //se il file non esiste resta null, allora creiamo un data in awake
    }

    public void SaveFile()
    {
        if (data == null)
            return;

        string jsonText = JsonConvert.SerializeObject(data);
        File.WriteAllText(savePath, jsonText);
        Debug.Log($"La posizione di {data} sono stati salvati in {savePath}");
    }

    private void LoadFile()
    {
        string jsonText = File.ReadAllText(savePath);
        DataContainer loadedData = JsonConvert.DeserializeObject<DataContainer>(jsonText);
        data = loadedData;
        Debug.Log($"{data} e' stato caricato");
    }
}