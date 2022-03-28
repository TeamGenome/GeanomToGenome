using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genom : MonoBehaviour
{
    private List<bool> GenomList = new List<bool>();

    public void InitGenom(int genomLength)
    {
        for(int i = 0; i < genomLength; i++)
        {
            GenomList.Add(Random.value > 0.5f);
        }
    }

    public void ReplaceGenom(List<bool> newGenom)
    {
        GenomList = newGenom;
    }

}
