using UnityEngine;
using System.IO;    
using Newtonsoft.Json;  

[System.Serializable]
public class PlayerData2
{

    public string playerName { get; set; }
    public int score { get; set; }
    public Vector3 position { get; set; }
    public Quaternion rotation { get; set; }
}

public class SaveSystem2 : MonoBehaviour
{
    public Transform playerTransform;
    private string savePath;


    private JsonSerializerSettings jsonSettings;

    void Awake()
    {

        savePath = Path.Combine(Application.persistentDataPath, "playerData_newtonsoft.json");


        jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented, 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SavePlayer();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();
        }
    }

    public void SavePlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Riferimento al Player non impostato!");
            return;
        }


        PlayerData2 data = new PlayerData2
        {
            playerName = "Salvo",
            score = 100,
            position = playerTransform.position,
            rotation = playerTransform.rotation
        };

        string json = JsonConvert.SerializeObject(data, jsonSettings);


        File.WriteAllText(savePath, json);

        Debug.Log("Dati salvati con Newtonsoft in: " + savePath);
    }

    public void LoadPlayer()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("Nessun file di salvataggio trovato!");
            return;
        }


        string json = File.ReadAllText(savePath);


        PlayerData2 data = JsonConvert.DeserializeObject<PlayerData2>(json);


        playerTransform.position = data.position;
        playerTransform.rotation = data.rotation;

        Debug.Log("Dati caricati! Nome Player: " + data.playerName + ", Punti: " + data.score);
    }
}