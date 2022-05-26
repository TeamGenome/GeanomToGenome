using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 게임에 대한 변수와 해당 게임을 위한 씬을 보관하는 싱글톤객체입니다.
/// </summary>
public class GameValueManager : MonoBehaviour
{
    public static GameValueManager instance;
    public int gameNumber;
    public int gameMode; // 0 : 훈련모드 , 1 : 트레이닝모드
    public int genomNumber;
    public InputField inputField;
    public List<GameValue> gameValues;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void GenomValueChange()
	{
        genomNumber = int.Parse(inputField.text);
	}

}
