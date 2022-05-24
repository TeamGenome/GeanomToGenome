using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 게임에 대한 변수와 해당 게임을 위한 씬을 보관하는 싱글톤객체입니다.
/// </summary>
public class GameValueManager : MonoBehaviour
{
    public static GameValueManager instance;
    public int gameNumber;
    public List<GameValue> gameValues;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }
}
