using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenomList<T>
{
    public List<T> gl;
    public GenomList(List<T> _gl)
    {
        gl = _gl;
    }
}
