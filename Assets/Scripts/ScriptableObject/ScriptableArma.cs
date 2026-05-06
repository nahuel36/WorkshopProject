using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableArma", menuName = "Scriptable Objects/ScriptableArma")]
public class ScriptableArma : ScriptableObject
{
    public string nombre;
    public int danio;
    public int duracion;
    [HideInInspector] public int duracionActual;
}
