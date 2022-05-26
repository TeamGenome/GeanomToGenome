using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> genoms;
	[SerializeField]
	private Text genomData;
	private GameValueManager gvm;

	// �����ڸ� ������ �� �ϰ������� ȣ���� �Լ��� ��� ��������Ʈ
	private delegate void GenomDeleteDelegate();
	private GenomDeleteDelegate gdd;
	private void Start()
	{
		gvm = GameValueManager.instance;
		gdd += CloseStorage;
		gdd += ShowStorage;
	}

	public void ShowStorage()
	{
		switch(gvm.gameNumber)
		{
			case 0:
				for(int i = 0; i < UserDataManager.userData.carGenoms.Count; i++)
				{
					genoms[i].SetActive(true);
				}
				break;
			case 1:
				for(int i = 0; i < UserDataManager.userData.dragoonGenoms.Count; i++)
				{
					genoms[i].SetActive(true);
				}
				break;
			default:
				return;
		}
	}

	public void ShowGenomInfo(int _value)
    {
		genomData.text = "";
		gvm.genomNumber = _value;
		switch (gvm.gameNumber)
		{
			case 0:
				for (int i = 0; i < UserDataManager.userData.carGenoms[gvm.genomNumber].gl.Count; i++)
				{
					genomData.text += UserDataManager.userData.carGenoms[gvm.genomNumber].gl[i] + " ";
				}
				break;
			case 1:
				for (int i = 0; i < UserDataManager.userData.dragoonGenoms[gvm.genomNumber].gl.Count; i++)
				{
					genomData.text += UserDataManager.userData.dragoonGenoms[gvm.genomNumber].gl[i] + " ";
				}
				break;
			default:
				return;
		}
	}

	public void CloseStorage()
	{
		foreach(var genom in genoms)
		{
			genom.SetActive(false);
		}
	}

	public void DeleteGenom()
    {
		switch (gvm.gameNumber)
		{
			case 0:
				UserDataManager.userData.carGenoms.RemoveAt(gvm.genomNumber);
				UserDataManager.SaveUserData();
				break;
			case 1:
				UserDataManager.userData.dragoonGenoms.RemoveAt(gvm.genomNumber);
				UserDataManager.SaveUserData();
				break;
			default:
				return;
		}
		gdd();
	}
}
