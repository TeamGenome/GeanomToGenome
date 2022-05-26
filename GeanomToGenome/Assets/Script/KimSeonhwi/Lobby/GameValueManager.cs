using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ӿ� ���� ������ �ش� ������ ���� ���� �����ϴ� �̱��水ü�Դϴ�.
/// </summary>
public class GameValueManager : MonoBehaviour
{
    public static GameValueManager instance;
    public int gameNumber;
    public int gameMode; // 0 : �Ʒø�� , 1 : Ʈ���̴׸��
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
