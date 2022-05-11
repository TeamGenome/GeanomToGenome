using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenomManagerInt : MonoBehaviour
{
    public event Action<bool> crossoverEvent;
    public event Action<int, List<int>> generationUpdateEvent;
    [SerializeField] private GameObject GenomPrefab;
    [SerializeField] private GameObject TrackTest;
    [SerializeField] private int genomLength;
    [SerializeField] private float distanceBetweenObjects;
    private int generation;
    [SerializeField] private List<GenomInt> subjects = new List<GenomInt>();
    private List<List<int>> dominantGenoms = new List<List<int>>(4);
    [SerializeField] private List<int> dominantIndex = new List<int>(4);
    [SerializeField] private List<int> newGeneration = new List<int>();

    void Start()
    {
        FindObjectOfType<GenomSelection>().inputGenomEvent += Selection;
        MakeGenoms();
        
        crossoverEvent?.Invoke(true);
    }

    private void MakeGenoms()
    {
        Debug.Log("Initialize first 64 Genoms");

        Vector3 position = new Vector3(0, 0, 0);

        for(int xPos = 0; xPos < 8; xPos++)
        {
            position.x = xPos * distanceBetweenObjects;
            for(int zPos = 0; zPos < 8; zPos++)
            {
                // instantiate track
                Instantiate(TrackTest, position, Quaternion.identity);

                // instantiate object which have genom
                subjects.Add(Instantiate(GenomPrefab, position, Quaternion.identity).GetComponent<GenomInt>());
                subjects[subjects.Count - 1].InitGenom(genomLength);
                subjects[subjects.Count - 1].name = "car" + (subjects.Count);


                // edit instantiate position
                position.z += distanceBetweenObjects;
            }
            position.z = 0;
        }
    }

    public void Selection(int genomIndex)
    {
        if(genomIndex < 0 || genomIndex >= subjects.Count)
            return;

        if(dominantIndex.Contains(genomIndex))  
        {
            Debug.Log("duplicated!");
            return;
        }
            
        dominantIndex.Add(genomIndex);   
        dominantGenoms.Add(subjects[genomIndex-1].GenomList);

        if(dominantGenoms.Count == 4)
        {
            Crossover();
        }
    }

    private void Crossover()
    {   
        crossoverEvent?.Invoke(false);
        Debug.Log("다음 세대의 64개 유전자 생성");

        // deliver dominant 4 Genoms to next Generation
        for(int i = 0; i < 4; i++)
        {
            subjects[i].ReplaceGenom(dominantGenoms[i]);
        }


        // make other genoms by crossover(+mutation)
        for(int i = 4; i < 64; i++)
        {
            GenerateNewGenom();
            subjects[i].ReplaceGenom(newGeneration);
        }


        Debug.Log("교배 끝");
        crossoverEvent?.Invoke(true);
        generation++;
        generationUpdateEvent?.Invoke(generation, dominantGenoms[0]);

        // clear dominant list
        dominantGenoms.Clear();
        dominantIndex.Clear();
    }

    private void GenerateNewGenom()
    {
        newGeneration.Clear();
        // select parent
        int father = UnityEngine.Random.Range(0, 4);
        int mother = UnityEngine.Random.Range(0, 4);


        for(int i = 0; i < genomLength; i++)
        {
            // random genom
            if(UnityEngine.Random.value > 0.5f)
            {
                newGeneration.Add(dominantGenoms[father][i]);
            }
            else
            {
                newGeneration.Add(dominantGenoms[mother][i]);
            }
            // mutation
            if(UnityEngine.Random.value < 0.1f)
                newGeneration[i] = UnityEngine.Random.Range(90, 181);
        }
    }

}
