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
        private string path = Application.dataPath + "/Scripts/Persistencia/datos.txt";

        public void CargarDatos()
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            sr.Close();

            InformacionAGuardar info = JsonConvert.DeserializeObject<InformacionAGuardar>(json);

            string jsonDatos = JsonConvert.SerializeObject(info.datos);

            SHA256 sha = SHA256.Create();
            string hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(jsonDatos))).Replace("-", "").ToLower();
            
            if(hash == info.hash)
            {
                datosContainer.informacionAGuardar = info;
                Debug.Log("Datos cargados correctamente desde: " + path);
            }
            else
            {
                Debug.LogError("Error al cargar los datos: el hash no coincide.");
            }
        }

}
