using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
public class GuardaDatos : MonoBehaviour
{
    public DatosContainer datosContainer;
    private string _path = Application.dataPath + "/Scripts/Persistencia/datos.txt";

    public void GuardarDatos()
    {
        ////// CALCULO EL HASH DEL JSON DE DATOS Y LO GUARDO EN EL OBJETO InformacionAGuardar
        SHA256 sha = SHA256.Create();
        string json = JsonConvert.SerializeObject(datosContainer.informacionAGuardar.datos);
        datosContainer.informacionAGuardar.hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(json))).Replace("-", "").ToLower();

        ////MODO AVANZADO
        //byte[] key = Encoding.UTF8.GetBytes(SystemInfo.deviceUniqueIdentifier);
        //HMACSHA256 hmac = new HMACSHA256(key);
        //string jsonDatos = JsonConvert.SerializeObject(datosContainer.informacionAGuardar.datos);
        //datosContainer.informacionAGuardar.hash = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(jsonDatos))).Replace("-", "").ToLower();


        ///// SERIALIZO EL OBJETO InformacionAGuardar A JSON Y LO GUARDO EN EL ARCHIVO
        string jsonfinal = JsonConvert.SerializeObject(datosContainer.informacionAGuardar);

        StreamWriter writer = new StreamWriter(_path);
        writer.Write(jsonfinal);
        writer.Close();

        Debug.Log("Datos guardados en: " + _path);
    }
}
