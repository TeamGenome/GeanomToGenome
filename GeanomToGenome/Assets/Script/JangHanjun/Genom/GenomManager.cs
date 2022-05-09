using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///<summary>
/// 해당 씬의 게놈 관리자는 해당 클래스를 상속받아야 합니다.
///</summary>
///<remarks>
/// Monobehaviour을 가지고 있으며 유전자 자료형에 맞게 인자를 넘겨주면 됩니다.
///</remarks>
public abstract class GenomManager<T> : MonoBehaviour
{
    public event Action<int, List<T>> generationUpdateEvent;
    [Header("유전자 설정")]
    [Tooltip("이번 씬에서 설정할 유전자의 길이")]
    public int genomLength;
    [Tooltip("현재 세대")]
    public int generation;

    [Tooltip("이번 씬의 자식들")]
    [SerializeField] protected List<Genom<T>> subjects = new List<Genom<T>>();
    protected List<List<T>> dominantGenoms = new List<List<T>>();
    [SerializeField] protected List<int> dominantIndex = new List<int>();  
    protected List<T> newGenom = new List<T>();

    public abstract void MakeGenoms();


    ///<summary>
    /// 사용자가 선택한 유전자의 인덱스를 받아오는 함수입니다.
    ///</summary>
    ///<param name="genomIndex">유전자 인덱스</param>
    public virtual void Selection(int genomIndex)
    {
        if(genomIndex < 0 || genomIndex >= subjects.Count)
            return;
        
        if(dominantIndex.Contains(genomIndex))  
        {
            Debug.Log("duplicated!");
            return;
        }
            
        dominantIndex.Add(genomIndex);   
        dominantGenoms.Add(subjects[genomIndex].genom);

        if(dominantGenoms.Count == 4)
        {
            Crossover();
        }
    }



    ///<summary>
    /// Selection에서 4개의 유전자를 저장하면 자동으로 불리는 함수입니다.
    ///</summary>
    public virtual void Crossover()
    {
        Debug.Log("다음 세대의 64개 유전자 생성");

        // deliver dominant 4 Genoms to next Generation
        for(int i = 0; i < 4; i++)
        {
            subjects[i].ReplaceGenom(dominantGenoms[i]);
        }


        // make other genoms by crossover(+mutation)
        for(int i = 4; i < subjects.Count; i++)
        {
            GenerateNewGenom();
            subjects[i].ReplaceGenom(newGenom);
        }

        generation++;
        GenUpdate();

        // clear dominant list
        dominantGenoms.Clear();
        dominantIndex.Clear();
    }


    ///<summary>
    /// Crossover 에서 유전자를 만드는데 사용할 함수입니다.
    ///</summary>
    public abstract void GenerateNewGenom();

    ///<summary>
    /// 세대가 업데이트 되면 불릴 함수입니다.
    ///</summary>
    public abstract void GenUpdate();
}
