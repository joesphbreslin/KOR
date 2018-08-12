using UnityEngine;
using Types;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour {

    #region Variables
    //Player Stats
    public float playerHealth, playerXp;
    static public EArea area;
    #endregion

    #region Singleton
    private static Manager _instance;

    public static Manager Instance
    {
        get
        {
            if (_instance != null)
            {
                GameObject go = new GameObject("Manager");
                go.AddComponent<Manager>();
                //go.AddComponent<Inventory>(); //TEST
            }
            return _instance;
        }
            
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }
    #endregion

    public void SavePlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        PlayerData data = new PlayerData();

        data.health = playerHealth;
        data.experience = playerXp;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadPlayerData()
    {
        if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerHealth = data.health;
            playerXp = data.experience;

        }
    }
}

//TODO see if ican persist scriptable object by saving and loading.

[Serializable]
class PlayerData
{
    public float health;
    public float experience;
}
