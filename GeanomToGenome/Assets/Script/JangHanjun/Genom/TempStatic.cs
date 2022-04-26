using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStatic : MonoBehaviour
{
    public static TempStatic instance;
    public bool nowGwnerating;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
