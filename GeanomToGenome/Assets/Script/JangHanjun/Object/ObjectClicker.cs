using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    Ray ray;
    RaycastHit rayHit;
    void Update()
    {
        if(!Input.GetMouseButtonDown(0))    return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rayHit, 500.0f))
        {
            if(rayHit.transform != null)
                Debug.Log(rayHit.transform.name);
        }
    }
}
