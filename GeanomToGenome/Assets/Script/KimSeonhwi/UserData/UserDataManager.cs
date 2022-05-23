using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public const string DATA_FILE_NAME = "/UserData.json";
    public static UserData userData;
    public static GenomBool selectedGenomBool;
    public static GenomInt selectedGenomInt;

    private void Start()
    {
        LoadUserData();
    }
    public static void LoadUserData()
    {
        if (!File.Exists(Application.persistentDataPath + DATA_FILE_NAME))
        {
            Debug.Log("No saved data");
            userData = new UserData();
            return;
        }
        FileStream fs = new FileStream(string.Format("{0}{1}", Application.persistentDataPath, DATA_FILE_NAME), FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);
        fs.Close();

        string jsonData = Encoding.UTF8.GetString(data);
        userData = JsonUtility.FromJson<UserData>(jsonData);
        return;
    }

    public static void SaveUserData()
    {
        string jsonData = JsonUtility.ToJson(userData);
        FileStream fs = new FileStream(string.Format("{0}{1}", Application.persistentDataPath, DATA_FILE_NAME), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fs.Write(data, 0, data.Length);
        fs.Close();
    }
}
