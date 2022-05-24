using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ӿ� ���� ������ �ش� ������ ���� ���� �����ϴ� �̱��水ü�Դϴ�.
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
