using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public UserData() 
    { 
        Debug.Log("Create UserData");
        carGenoms = new List<GenomList<bool>>();
        dragoonGenoms = new List<GenomList<int>>();
        //carGenomBuyTime = DateTime.MinValue;
        //dragoonGenomBuyTime = DateTime.MinValue;
        money = 500;
    }
    public List<GenomList<bool>> carGenoms;
    public List<GenomList<int>> dragoonGenoms;
    //public DateTime carGenomBuyTime;
    //public DateTime dragoonGenomBuyTime;
    public int money;
}
