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

	private void Start()
	{
		gvm = GameValueManager.instance;
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
		switch (gvm.gameNumber)
		{
			case 0:
				for (int i = 0; i < UserDataManager.userData.carGenoms[_value].gl.Count; i++)
				{
					genomData.text += UserDataManager.userData.carGenoms[_value].gl[i] + " ";
				}
				break;
			case 1:
				for (int i = 0; i < UserDataManager.userData.dragoonGenoms[_value].gl.Count; i++)
				{
					genomData.text += UserDataManager.userData.dragoonGenoms[_value].gl[i] + " ";
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
}
