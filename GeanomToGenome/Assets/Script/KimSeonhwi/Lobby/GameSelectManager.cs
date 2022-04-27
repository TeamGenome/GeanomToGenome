using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectManager : MonoBehaviour
{
    public static int gameNumber;

    [SerializeField] private Text gameSelectText;
    [SerializeField] private List<GameValue> gameValues;

    public void InitialGameSelectPanel()
    {
        gameSelectText.text = gameValues[gameNumber].gameName;
    }

    public void TrainingGameLoad()
    {
        if (gameValues[gameNumber].trainingSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gameValues[gameNumber].trainingSceneName);
    }

    public void LeagueGameLoad()
    {
        if (gameValues[gameNumber].leagueSceneName != string.Empty)
            LoadingSceneManager.LoadScene(gameValues[gameNumber].leagueSceneName);
    }
}
