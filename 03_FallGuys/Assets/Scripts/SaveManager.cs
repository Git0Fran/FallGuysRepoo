using System.Xml.Serialization;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    static SaveManager instance = null;
    public static SaveManager Instance { get { return instance; } }

    private GameData gameData = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }



    private string GetFullFileName()
    {
        return Application.persistentDataPath + "/game.save";
    }


    public GameData GetGameData()
    {
        if (gameData == null)
        {
            gameData = new GameData();
        }
        return gameData;
    }


    public void SetGameData(GameData data)
    {
        gameData = data;
    }

    public void Save()
    {
        if (gameData != null)
        {
            string dataJson = JsonUtility.ToJson(gameData, true);
            File.WriteAllText(GetFullFileName(), dataJson);
        }
    }

    public void Load()
    {
        string filePath = GetFullFileName();
        if (File.Exists(filePath))
        { 
            string dataJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataJson);
        }
    }

}
