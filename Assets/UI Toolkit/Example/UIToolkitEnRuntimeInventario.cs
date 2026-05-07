using System.Collections.Generic;
using UnityEngine;

public class UIToolkitEnRuntimeInventario : MonoBehaviour
{
    public List<MiInventario> miInventario = new List<MiInventario>();
}

[System.Serializable]
public class MiInventario
{
    public string nombreItem;
    public Sprite imagen;
}

