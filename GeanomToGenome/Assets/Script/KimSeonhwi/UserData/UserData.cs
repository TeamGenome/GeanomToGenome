using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public UserData() 
    { 
        Debug.Log("Create UserData");
        carGenoms = new List<GenomList<bool>>();
        dragoonGenoms = new List<GenomList<int>>();
        money = 0;
    }
    public List<GenomList<bool>> carGenoms;
    public List<GenomList<int>> dragoonGenoms;
    public int money;
}
