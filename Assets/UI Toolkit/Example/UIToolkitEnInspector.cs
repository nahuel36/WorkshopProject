using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class UIToolkitEnInspector : MonoBehaviour
{
    public string titulo = "Hello World!";
    public int numero = 42;
    public List<MiListaEnInspector> miLista = new List<MiListaEnInspector>();
}

[System.Serializable]
public class MiListaEnInspector
{
    public string nombre;
    public int valor;
}