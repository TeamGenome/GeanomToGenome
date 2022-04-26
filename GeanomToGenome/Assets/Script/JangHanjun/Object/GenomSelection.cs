using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GenomSelection : MonoBehaviour
{
    public event Action<int> inputGenomEvent;
    InputField inputField;
    private void Start()
    {
        inputField = GetComponent<InputField>();
    }
    public void EndInputEvent()
    {
        int index;
        if(int.TryParse(inputField.text, out index))
        {
            inputGenomEvent?.Invoke(index);
        }
    }
}
