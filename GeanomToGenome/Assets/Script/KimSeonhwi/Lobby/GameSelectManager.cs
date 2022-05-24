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
        if (gvm.gameValues[gvm.gameNumber].trainingSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].trainingSceneName);
    }

    public void LeagueGameLoad()
    {
        if (gvm.gameValues[gvm.gameNumber].leagueSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gvm.gameValues[gvm.gameNumber].leagueSceneName);
    }
}
