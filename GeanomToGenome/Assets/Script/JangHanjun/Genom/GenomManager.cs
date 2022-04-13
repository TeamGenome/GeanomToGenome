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
    [SerializeField] private GameObject GenomPrefab;
    [SerializeField] private GameObject TrackTest;
    [SerializeField] private int genomLength;
    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private List<Genom> subjects = new List<Genom>();
    private List<List<bool>> dominantGenoms = new List<List<bool>>(4);
    private List<bool> newGeneration = new List<bool>();

    void Start()
    {
        newGeneration.Capacity = genomLength;
        
        MakeGenoms();
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
                subjects.Add(Instantiate(GenomPrefab, position, Quaternion.identity).GetComponent<Genom>());
                subjects[subjects.Count - 1].InitGenom(genomLength);
                subjects[subjects.Count - 1].ReachToEndEvent += Selection;
                subjects[subjects.Count - 1].name = "car" + (subjects.Count);

                // edit instantiate position
                position.z += distanceBetweenObjects;
            }
            position.z = 0;
        }
    }

    public void Selection(List<bool> inputFour)
    {
        if(TempStatic.instance.nowGwnerating)       return;

        dominantGenoms.Add(inputFour);

        if(dominantGenoms.Count == 4)
        {
            for(int i = 0; i < genomLength; i++){
                Debug.Log(dominantGenoms[0][i]);
            }
            Crossover();
        }
    }

    private void Crossover()
    {   
        Debug.Log("다음 세대의 64개 유전자 생성");
        TempStatic.instance.nowGwnerating = true;

        // 상위 4개의 객체는 살려 둡니다.
        for(int i = 0; i < 4; i++)
        {
            subjects[i].ReplaceGenom(dominantGenoms[i]);
        }


        // 4개로 60개의 유전자를 바꿔야 합니다.
        for(int i = 4; i < 64; i++)
        {
            Debug.Log("replace : " + subjects[i].name);
            //! TODO : Here have Error
            // GenerateNewGenom();
            subjects[i].ReplaceGenom(newGeneration);
        }

        // clear dominant list
        dominantGenoms.Clear();
        TempStatic.instance.nowGwnerating = false;
    }

    private List<bool> GenerateNewGenom()
    {
        // select parent
        int father = Random.Range(0, 4);
        int mother = Random.Range(0, 4);
        for(int i = 0; i < genomLength; i++)
        {
            // random genom
            if(Random.value > 0.5f)
            {
                newGeneration[i] = dominantGenoms[father][i];
                continue;
            }
            else
            {
                newGeneration[i] = dominantGenoms[mother][i];
                continue;
            }
        }

        Debug.Log(newGeneration.Count);
        return newGeneration;
    }
}
