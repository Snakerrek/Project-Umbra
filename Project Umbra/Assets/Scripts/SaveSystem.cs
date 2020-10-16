using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class SaveSystem
{
    public static void SaveData (GameController gameController)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameController);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/game.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not dound in " + path);
            return null;
        }
    }

}
