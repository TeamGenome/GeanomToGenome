using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Genom : MonoBehaviour
{
    public event Action<List<bool>> ReachToEndEvent;
    public List<bool> GenomList = new List<bool>();
    private bool finished = false;

    public void InitGenom(int genomLength)
    {
        GenomList.Clear();
        for(int i = 0; i < genomLength; i++)
        {
            GenomList.Add(UnityEngine.Random.value > 0.5f);
        }
    }

    public void ReplaceGenom(List<bool> newGenom)
    {
        int genomLength = newGenom.Count;

        for(int i = 0; i < genomLength; i++)
        {
            GenomList[i] = newGenom[i];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(finished)    return;

        if(other.CompareTag("EndPoint"))
        {
            finished = true;
            Debug.Log(this.name + " Reach to goal");
            if(ReachToEndEvent != null)
                ReachToEndEvent(this.GenomList);
        }
    }

}
