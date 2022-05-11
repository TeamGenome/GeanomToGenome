using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 유전자를 가지는 클래스는 이 클래스를 상속받아야 합니다.
///</summary>
///<remarks>
/// Monobehaviour을 가지고 있으며 유전자 자료형에 맞게 인자를 넘겨주면 됩니다.
///</remarks>
public abstract class Genom<T> : MonoBehaviour
{
    public List<T> genom;

    ///<summary>
    /// 유전자를 초기화 합니다.
    ///</summary>
    ///<param name="genomLength">만들 유전자의 길이</param>
    public abstract void InitGenom(int genomLength);

    ///<summary>
    /// 유전자를 교체 합니다.
    ///</summary>
    ///<param name="newGenom">교체할 유전자</param>
    public virtual void ReplaceGenom(List<T> newGenom)
    {
        for(int i = 0; i < newGenom.Count; i++)
        {
            genom[i] = newGenom[i];
        }
    }

}
