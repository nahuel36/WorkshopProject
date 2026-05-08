using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class CargaDatos : MonoBehaviour
{
    public DatosContainer datosContainer;
    private string _path = Application.dataPath + "/Scripts/Persistencia/datos.txt";

    public void CargarDatos()
    {
        //////// ABRO EL ARCHIVO Y LEO EL CONTENIDO
        StreamReader sr = new StreamReader(_path);
        string json = sr.ReadToEnd();
        sr.Close();

        /////// DESERIALIZO EL JSON A UN OBJETO DE TIPO InformacionAGuardar
        InformacionAGuardar info = JsonConvert.DeserializeObject<InformacionAGuardar>(json);

        ////// CALCULO EL HASH DEL JSON DE DATOS Y LO COMPARO CON EL HASH GUARDADO
        string jsonDatos = JsonConvert.SerializeObject(info.datos);

        //// MODO SIMPLIFICADO
        SHA256 sha = SHA256.Create();
        string hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(jsonDatos))).Replace("-", "").ToLower();

        ///// MODO AVANZADO
        //byte[] key = Encoding.UTF8.GetBytes(SystemInfo.deviceUniqueIdentifier);
        //HMACSHA256 hmac = new HMACSHA256(key);
        //string hash = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(jsonDatos))).Replace("-", "").ToLower();

        if (hash == info.hash)
        {
            datosContainer.informacionAGuardar = info;
            Debug.Log("Datos cargados correctamente desde: " + _path);
        }
        else
        {
            Debug.LogError("Error al cargar los datos: el hash no coincide.");
        }
    }

}
