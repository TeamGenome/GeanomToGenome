using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData : MonoBehaviour
{
    public UserData() 
    { 
        Debug.Log("Create UserData");
        genoms = new List<string>();
        money = 0;
    }
    public List<string> genoms;
    public int money;
}
