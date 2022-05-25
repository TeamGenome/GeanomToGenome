using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private const int carGameGenomSize = 9;
    private const int dragoonGameGenomSize = 9;
    public GenomBool saleGenomBool;
    public GenomInt saleGenomInt;
    private void Start()
    {
        InitalizeShop();
    }
    void InitalizeShop()
    {
        UnityEngine.Random.InitState(DateTime.Now.Day); // �Ϸ翡 �� ���� �Ź��� �ٲ�
        saleGenomBool.InitGenom(carGameGenomSize);
        saleGenomInt.InitGenom(dragoonGameGenomSize);
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }
    public void BuyNewGenom()
    {
        GenomList<bool> gl = new GenomList<bool>(saleGenomBool.genom);
        UserDataManager.userData.carGenoms.Add(gl);
    }
}
