using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private const int genomBoolSize = 9;
    private const int genomIntSize = 9;
    public GenomBool saleGenomBool;
    public GenomInt saleGenomInt;

    void InitalizeShop()
    {
        UnityEngine.Random.InitState(DateTime.Now.Day);
        for(int i = 0; i < genomBoolSize; i++)
        {
            saleGenomBool.genom.Add(UnityEngine.Random.value > 0.5f);
        }

        for(int i = 0; i < genomIntSize; i++)
        {

        }
    }
    void BuyNewGenom()
    {
        
    }
}
