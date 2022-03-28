using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Moving : MonoBehaviour
{
    private Genom genom;
    // public List<bool> genomList = new List<bool>();
    public Rigidbody carRB;

    public float moveSpeed;
    public bool isMoving;

    private void Awake()
    {
        carRB = this.GetComponent<Rigidbody>();
        genom = this.GetComponent<Genom>();
    }

    private void Start()
    {
        //? Genom 클래스 포함을 통해 구성
        // for(int i = 0; i < genomList.Count; i++)
        // {
        //     genomList[i] = (Random.value > 0.5f);
        // }
        genom.InitGenom(8);
    }
    
    void Update()
    {
        if (!isMoving)
        {
            Moving();
        }
    }

    public void Moving()
    {
        isMoving = true;
        StartCoroutine(MoveCoroutine());
    }

    public IEnumerator MoveCoroutine()
    {
        foreach(var genom in genom.GenomList)
        {
            if (genom)
            {
                carRB.AddRelativeForce(Vector3.forward * moveSpeed);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                for(int i = 1; i <= 90; i++)
                {
                    carRB.transform.Rotate(0, 1, 0);
                    yield return new WaitForSeconds(0.005f);
                }
                carRB.transform.rotation = Quaternion.Euler(0, Mathf.Round(carRB.transform.rotation.eulerAngles.y), 0); // �ݿø����� ��Ȯ�� 90�� ������ ����
                yield return new WaitForSeconds(0.01f);
            }
        }
        isMoving = false;
    }
}
