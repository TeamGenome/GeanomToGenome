using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerMoney;
    public int Money
    {
        get { return playerMoney; }
        set { playerMoney += value; }
    }
}
