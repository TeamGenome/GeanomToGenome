using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���õ� ������ �����ϵ��� �մϴ�.
/// </summary>
public class GameSelectManager : MonoBehaviour
{
    [SerializeField] private Text gameSelectText;
    private GameValueManager gvm;

    private void Start()
    {
        gvm = GameValueManager.instance;
    }

    public void InitialGameSelectPanel()
    {
        gameSelectText.text = gvm.gameValues[gvm.gameNumber].gameName;
    }

    public void TrainingGameLoad()
    {
        switch(gvm.gameNumber)
		{
            case 0: // �ڵ��� ����
                Debug.Log("selected genomNumber = " + gvm.genomNumber);
                UserDataManager.selectedGenomBool.genom = UserDataManager.userData.carGenoms[gvm.genomNumber].gl;
                break;
            case 1: // ��� ����
                break;
		}
        if (gvm.gameValues[gvm.gameNumber].trainingSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].trainingSceneName);
    }

    public void LeagueGameLoad()
    {
        switch (gvm.gameNumber)
        {
            case 0: // �ڵ��� ����
                UserDataManager.selectedGenomBool.genom = UserDataManager.userData.carGenoms[gvm.genomNumber].gl;
                break;
            case 1: // ��� ����
                break;
        }
        if (gvm.gameValues[gvm.gameNumber].leagueSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].leagueSceneName);
    }
    
    public void GameStart() // gvm.gameMode�� 0�̶�� �Ʒ�, 1�̶�� ��ȸ ����
    {
        switch(gvm.gameMode)
		{
            case 0:
                TrainingGameLoad();
                break;
            case 1:
                LeagueGameLoad();
                break;
            default:
                return;
		}
    }
}
