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
    [SerializeField] private bool canMove;
    [SerializeField] private Vector3 originPos;

    private void Awake()
    {
        carRB = this.GetComponent<Rigidbody>();
        genom = this.GetComponent<Genom>();
        
        FindObjectOfType<GenomManager>().crossoverEvent += SetMovingState;
    }

    private void Start()
    {
        this.originPos = this.transform.position;
    }
    
    void Update()
    {
        if(!canMove)    return;

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
        for(int i = 0; i < genom.GenomList.Count; i++)
        {
            if (genom.GenomList[i])
            {
                carRB.AddRelativeForce(Vector3.forward * moveSpeed);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                for(int j = 1; j <= 90; j++)
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

    private void SetMovingState(bool canMove)
    {
        this.canMove = canMove;
        if(!canMove)
        {
            // todo : should reposition object
            this.transform.position = originPos;
            this.transform.rotation = Quaternion.identity;
        }
    }
}
