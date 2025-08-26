using UnityEngine;
using System.IO;


[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public Quaternion rotation; 
}

public class SaveSystem : MonoBehaviour
{

    public Transform playerTransform;

    private string _savePath;

    void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
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
            Debug.LogError("Riferimento al Player non impostato nel SaveSystem!");
            return;
        }


        PlayerData data = new PlayerData();


        data.position = playerTransform.position;
        data.rotation = playerTransform.rotation;


        string json = JsonUtility.ToJson(data, true); 


        File.WriteAllText(_savePath, json);

        Debug.Log("Dati del player salvati in: " + _savePath);
    }

    public void LoadPlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Riferimento al Player non impostato nel SaveSystem!");
            return;
        }

        if (File.Exists(_savePath))
        {

            string json = File.ReadAllText(_savePath);


            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerTransform.position = data.position;
            playerTransform.rotation = data.rotation;

            Debug.Log("Dati del player caricati!");
        }
        else
        {
            Debug.LogWarning("Nessun file di salvataggio trovato in: " + _savePath);
        }
    }
}