using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
public class GuardaDatos : MonoBehaviour
{
    public DatosContainer datosContainer;
    private string path = Application.dataPath + "/Scripts/Persistencia/datos.txt";

    public void GuardarDatos()
    {
        SHA256 sha = SHA256.Create();
        string json = JsonConvert.SerializeObject(datosContainer.informacionAGuardar.datos);
        datosContainer.informacionAGuardar.hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(json))).Replace("-", "").ToLower();
        string jsonfinal = JsonConvert.SerializeObject(datosContainer.informacionAGuardar);

        StreamWriter writer = new StreamWriter(path);
        writer.Write(jsonfinal);
        writer.Close();
        Debug.Log("Datos guardados en: " + path);
    }
}
