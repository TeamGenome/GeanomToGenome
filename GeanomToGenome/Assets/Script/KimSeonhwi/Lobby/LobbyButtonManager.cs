using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �κ� �ִ� ��ư��ȣ�ۿ��� �����մϴ�.
/// </summary>
public class LobbyButtonManager : MonoBehaviour
{

    public void OpenPanel(GameObject _openPanel)
    {
        if(!_openPanel.activeSelf)
            _openPanel.SetActive(true);
    }

    public void ClosePanel(GameObject _closePanel)
    {
        if(_closePanel.activeSelf)
            _closePanel.SetActive(false);
    }

    public void GameSelect(int _gameNumber)
    {
        GameValueManager.instance.gameNumber = _gameNumber;
    }

    public void GameModeSelect(int _gameMode)
	{
        GameValueManager.instance.gameMode = _gameMode;
	}
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
