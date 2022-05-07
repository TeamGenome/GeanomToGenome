using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenomManagerBool : GenomManager<bool>
{
    private void Start()
    {
        // find all genoms and save to list
        subjects.AddRange(FindObjectsOfType<Genom<bool>>());
        MakeGenoms();

        // generationUpdateEvent += FindObjectOfType<InGameUI<bool>>().SetGenerationUI;
    }

    public override void MakeGenoms()
    {
        for(int i = 0; i < subjects.Count; i++)
        {
            subjects[i].InitGenom(genomLength);
        }
    }

    [ContextMenu("test selection")]
    public void test()
    {
        base.Selection(0);
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
        // generationUpdateEvent?.Invoke(generation, dominantGenoms[0]);
    }

    
}
