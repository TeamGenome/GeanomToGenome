using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Moving : MonoBehaviour
{
    public List<bool> genomList = new List<bool>();
    public Rigidbody carRB;

    public float moveSpeed;
    public bool isMoving;

    private void Awake()
    {
        carRB = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        for(int i = 0; i < genomList.Count; i++)
        {
            genomList[i] = (Random.value > 0.5f);
        }
    }
    // Update is called once per frame
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
        foreach(var genom in genomList)
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
                carRB.transform.rotation = Quaternion.Euler(0, Mathf.Round(carRB.transform.rotation.eulerAngles.y), 0); // 반올림으로 정확히 90도 각도로 변경
                yield return new WaitForSeconds(0.01f);
            }
        }
        isMoving = false;
    }
}
