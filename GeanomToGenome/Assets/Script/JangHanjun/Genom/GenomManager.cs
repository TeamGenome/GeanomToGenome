using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
유전 알고리즘에서 각 연산들을 진행해 주는 클래스입니다.

1. 초기화 (init)
    - 이 기능의 경우 각 Genom 클래스에서 하는 기능입니다.
    - 이때 
2. 선택 (selection)
    - 상위 4개의 Genom을 받는 기능입니다.
3. 교차 (crossover)
    - 상위 4개의 Genom을 받은 뒤 
4. 변이 (mutation)
5. 교체 (replace)
6. 반복

*/
public class GenomManager : MonoBehaviour
{
    public GameObject GenomPrefab;
    public int genomLength;
    public float distanceBetweenObjects;
    List<Genom> subjects = new List<Genom>();
    List<List<bool>> dominantGenoms = new List<List<bool>>();

    void Start()
    {
        MakeGenoms();
    }

    private void MakeGenoms()
    {
        Vector3 position = new Vector3(0, 0, 0);

        for(int xPos = 0; xPos < 8; xPos++)
        {
            position.x = xPos * distanceBetweenObjects;
            for(int zPos = 0; zPos < 8; zPos++)
            {
                subjects.Add(Instantiate(GenomPrefab, position, Quaternion.identity).GetComponent<Genom>());
                subjects[subjects.Count - 1].InitGenom(genomLength);
                position.z += distanceBetweenObjects;
            }
            position.z = 0;
        }
    }

    public void Selection(List<List<bool>> inputFour)
    {
        dominantGenoms = inputFour;
    }

    private void Crossover()
    {   
        // 상위 4개의 객체는 살려 둡니다.
        for(int i = 0; i < 4; i++)
        {
            subjects[i].ReplaceGenom(dominantGenoms[i]);
        }


        // 4개로 60개의 유전자를 바꿔야 합니다.
        for(int i = 4; i < 64; i++)
        {
            subjects[i].ReplaceGenom(newGenom());
        }
    }

    private List<bool> newGenom()
    {
        List<bool> newGeneration = new List<bool>(genomLength);

        // select parent
        int father = Random.Range(1, 5);
        int mother = Random.Range(1, 5);

        for(int i = 0; i < genomLength; i++)
        {
            // random genom
            if(Random.value > 0.5f)
                newGeneration[i] = dominantGenoms[father][i];
            else
                newGeneration[i] = dominantGenoms[mother][i];
        }

        return newGeneration;
    }
}
