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
    [SerializeField] private List<GameObject> genoms;
    [SerializeField] private Text genomData;
    [SerializeField] private Button startButton;
    private GameObject selectedGenom;
    private GameObject checkMark;
    private GameValueManager gvm;
    
    private void Start()
    {
        gvm = GameValueManager.instance;
        selectedGenom = null;
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

    // ������ ����Ʈ �ʱ�ȭ
    public void GenomsListInitial()
    {
        startButton.interactable = true;
        switch (gvm.gameNumber)
        {
            case 0:
                if (UserDataManager.userData.carGenoms.Count == 0)
                    startButton.interactable = false;
                for (int i = 0; i < UserDataManager.userData.carGenoms.Count; i++)
                {
                    genoms[i].SetActive(true);
                }
                break;
            case 1:
                if (UserDataManager.userData.dragoonGenoms.Count == 0)
                    startButton.interactable = false;
                for (int i = 0; i < UserDataManager.userData.dragoonGenoms.Count; i++)
                {
                    genoms[i].SetActive(true);
                }
                break;
            default:
                return;
        }
    }

    // ������ ����Ʈ�� ����
    public void CloseGenomList()
    {
        foreach (var genom in genoms)
        {
            genom.SetActive(false);
        }
    }
    
    // ���� ���� �� �����ڸ� ����
    public void GenomSelect(int _val)
    {
        gvm.genomNumber = _val;

        if (selectedGenom != null)
        {
            checkMark = selectedGenom.transform.GetChild(0).gameObject;
            checkMark.SetActive(false);
        }
        selectedGenom = genoms[_val];
        checkMark = selectedGenom.transform.GetChild(0).gameObject;
        checkMark.SetActive(true);

        genomData.text = "";
        switch (gvm.gameNumber)
        {
            case 0:
                foreach(var genom in UserDataManager.userData.carGenoms[_val].gl)
                {
                    genomData.text += genom + " ";
                }
                break;
            case 1:
                foreach (var genom in UserDataManager.userData.dragoonGenoms[_val].gl)
                {
                    genomData.text += genom + " ";
                }
                break;
            default:
                return;
        }
    }
}
