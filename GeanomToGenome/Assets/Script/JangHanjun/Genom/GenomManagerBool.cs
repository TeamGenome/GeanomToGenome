using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenomManagerBool : GenomManager<bool>
{
    [Header("생성할 프리팹")]
    [SerializeField] private GameObject boolCarPrefab;
    [SerializeField] private GameObject carTrack;
    private void Start()
    {
        base.InitScene();

        MakeGenoms();

        CrossoverEvent(true);
    }

    public override void MakeGenoms()
    {
        // generate position
        Vector3 position = new Vector3(0, 0, 0);

        for(int xPos = 0; xPos < 8; xPos++)
        {
            position.x = xPos * 50f;
            for(int zPos = 0; zPos < 8; zPos++)
            {
                // instantiate object which have genom car and track
                subjects.Add(Instantiate(boolCarPrefab, position, Quaternion.identity).GetComponentInChildren<GenomBool>());
                subjects[subjects.Count - 1].transform.parent.GetComponentInChildren<TextMeshPro>().text = (subjects.Count - 1).ToString();
                subjects[subjects.Count - 1].InitGenom(genomLength);
                subjects[subjects.Count - 1].transform.parent.name = "car" + (subjects.Count-1);


                // edit instantiate position
                position.z += 50f;
            }
            position.z = 0;
        }

    }

    protected override void SetMostDominantGenomString(int genomIndex)
    {
        base.SetMostDominantGenomString(genomIndex);
        
        for(int i = 1; i <= genomLength; i++)
        {
            mostDominantGenom.Append(subjects[genomIndex].genom[i-1] ? 1 : 0);
            if(i%4 == 0)
                mostDominantGenom.Append(" | ");
        }
    }

    public override void GenerateNewGenom()
    {
        newGenom.Clear();

        // select parent
        int father = UnityEngine.Random.Range(0, 4);
        int mother = UnityEngine.Random.Range(0, 4);

        for(int i = 0; i < genomLength; i++)
        {
            // random genom
            if(UnityEngine.Random.value > 0.5f)
            {
                newGenom.Add(dominantGenoms[father][i]);
            }
            else
            {
                newGenom.Add(dominantGenoms[mother][i]);
            }
            // mutation
            if(UnityEngine.Random.value < 0.1f)
                newGenom[i] = !newGenom[i];
        }
    }

    public override void GenUpdate()
    {
        Debug.Log("generation update");
        generation++;

        hud.SetGenerationUI(generation, mostDominantGenom);
        Debug.Log(mostDominantGenom.ToString());
    }   

    public override void FinalSelection(int genomIndex)
    {
        Debug.Log($"{genomIndex} selected");
        UserDataManager.selectedGenomBool = (GenomBool)subjects[genomIndex];
        GenomList<bool> savedGenom = new GenomList<bool>(subjects[genomIndex].genom);
        UserDataManager.userData.carGenoms.Add(savedGenom);
        UserDataManager.SaveUserData();
    }
}
