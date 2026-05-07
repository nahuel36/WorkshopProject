using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UIToolkitEnRuntimeListaTareas : MonoBehaviour
{
    public List<MiTarea> listaTareas;
}

[System.Serializable]
public class MiTarea
{
    public string nombreTarea;
    public bool terminada;
}