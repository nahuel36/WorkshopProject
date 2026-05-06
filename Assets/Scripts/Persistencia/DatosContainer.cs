using UnityEngine;
using System.Collections.Generic;
public class DatosContainer : MonoBehaviour
{
    public InformacionAGuardar informacionAGuardar;
}

[System.Serializable]
public class InformacionAGuardar
{
    public List<Dato> datos;
    public string hash = "555";
}

[System.Serializable]
public class Dato
{
    public string appellido;
    public string nombre;
    public int edad;
    public long dni;
}