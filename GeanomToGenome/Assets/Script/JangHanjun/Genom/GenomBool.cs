using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomBool : Genom<bool>
{
    public override void InitGenom(int genomLength)
    {
        for(int i = 0; i < genomLength; i++)
            genom.Add(UnityEngine.Random.value > 0.5f);
    }

    
}
