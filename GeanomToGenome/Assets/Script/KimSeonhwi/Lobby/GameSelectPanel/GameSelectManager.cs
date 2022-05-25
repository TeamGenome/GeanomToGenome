using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 선택된 게임을 시작하도록 합니다.
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
            case 0: // 자동차 게임
                Debug.Log("selected genomNumber = " + gvm.genomNumber);
                UserDataManager.selectedGenomBool.genom = UserDataManager.userData.carGenoms[gvm.genomNumber].gl;
                break;
            case 1: // 드라군 게임
                break;
		}
        if (gvm.gameValues[gvm.gameNumber].trainingSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].trainingSceneName);
    }

    public void LeagueGameLoad()
    {
        switch (gvm.gameNumber)
        {
            case 0: // 자동차 게임
                UserDataManager.selectedGenomBool.genom = UserDataManager.userData.carGenoms[gvm.genomNumber].gl;
                break;
            case 1: // 드라군 게임
                break;
        }
        if (gvm.gameValues[gvm.gameNumber].leagueSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].leagueSceneName);
    }
    
    public void GameStart() // gvm.gameMode가 0이라면 훈련, 1이라면 대회 참가
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
