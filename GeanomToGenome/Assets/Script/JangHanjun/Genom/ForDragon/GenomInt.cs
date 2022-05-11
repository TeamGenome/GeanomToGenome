using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GenomInt : MonoBehaviour
{
    public event Action<List<int>> ReachToEndEvent;
    public List<int> GenomList = new List<int>();

    public void InitGenom(int genomLength)
    {
        GenomList.Clear();
        for(int i = 0; i < genomLength; i++)
        {
            GenomList.Add(UnityEngine.Random.Range(90, 181));
        }
    }

    public void ReplaceGenom(List<int> newGenom)
    {
        int genomLength = newGenom.Count;

        for(int i = 0; i < genomLength; i++)
        {
            GenomList[i] = newGenom[i];
        }
    }
}
