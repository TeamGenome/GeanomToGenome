using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomManagerBool : GenomManager<bool>
{
    private void Start()
    {
        // TODO : 순서 복잡하게 되는것 수정
        // find all genoms and save to list
        // subjects.AddRange(FindObjectsOfType<Genom<bool>>());

        FindObjectOfType<GenomSelection>().inputGenomEvent += Selection;

        MakeGenoms();

        // TODO : 
        hud = FindObjectOfType<InGameHud>();

        // generationUpdateEvent += FindObjectOfType<InGameUI<bool>>().SetGenerationUI;
    }

    public override void MakeGenoms()
    {
        for(int i = 0; i < subjects.Count; i++)
        {
            subjects[i].InitGenom(genomLength);
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
        // subjects[genomIndex].genom;
    }
}
