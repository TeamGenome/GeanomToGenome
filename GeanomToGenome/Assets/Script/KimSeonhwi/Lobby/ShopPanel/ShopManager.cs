using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private const int carGameGenomSize = 9;
    private const int dragoonGameGenomSize = 9;
    [SerializeField]
    private Text genomData;
    [SerializeField]
    private Text money;
    private GameValueManager gvm;
    public GenomBool saleGenomBool;
    public GenomInt saleGenomInt;
    private void Start()
    {
        gvm = GameValueManager.instance;
        InitalizeShop();
    }
    void InitalizeShop()
    {
        UnityEngine.Random.InitState(DateTime.Now.Day); // 하루에 한 번씩 매물이 바뀜
        saleGenomBool.InitGenom(carGameGenomSize);
        saleGenomInt.InitGenom(dragoonGameGenomSize);
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    public void OpenShop()
    {
        genomData.text = "";
        money.text = UserDataManager.userData.money.ToString() + " 원";
        switch (gvm.gameNumber)
        {
            case 0:
                foreach(var genom in saleGenomBool.genom)
                {
                    genomData.text += genom + " ";
                }
                break;
            case 1:
                //foreach (var genom in saleGenomInt.genom)
                //{
                //    genomData.text += genom;
                //}
                break;
            default:
                break;
        }
    }

    public void BuyNewGenom()
    {
        switch(gvm.gameNumber)
        {
            case 0:
                GenomList<bool> gl = new GenomList<bool>(saleGenomBool.genom);
                UserDataManager.userData.carGenoms.Add(gl);
                UserDataManager.SaveUserData();
                break;
            case 1:
                //GenomList<int> gl = new GenomList<int>(saleGenomint.genom);
                //UserDataManager.userData.dragoonGenoms.Add(gl);
                //UserDataManager.userData.dragoonGenomBuyTime = now;
                break;
            default:
                break;
        }
    }
}
