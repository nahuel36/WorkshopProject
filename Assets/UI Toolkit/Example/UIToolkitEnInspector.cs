using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIToolkitEnInspector : MonoBehaviour
{
    public AssetReference AssetReference;
    public string titulo = "Hello World!";
    public int numero = 42;
    public List<MiListaEnInspector> miLista = new List<MiListaEnInspector>();

    private void Start()
    {
       AsyncOperationHandle handle =  AssetReference.LoadAssetAsync<GameObject>();

    }
}

[System.Serializable]
public class MiListaEnInspector
{
    public string nombre;
    public int valor;
    public List<MiListaDentroDeListaEnInspector> miListaDentroDeLista = new List<MiListaDentroDeListaEnInspector>();
}

[System.Serializable]
public class  MiListaDentroDeListaEnInspector
{
    public string subNombre;
}