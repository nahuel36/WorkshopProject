using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
public class UIToolkitEnRuntimeVida : MonoBehaviour
{
    public string nombrePJ = "Pedro";
    public int vida = 42;
    public static event Action OnVidaChanged;

    public void QuitarVida() {
        vida -= 10;
        OnVidaChanged?.Invoke();
    }

}