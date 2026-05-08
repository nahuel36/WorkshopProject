using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    public ScriptableArma _arma;
    public TMPro.TextMeshProUGUI _textMeshPro;

    public void Start()
    {
        _arma.duracionActual = _arma.duracion;
    }

    // Update is called once per frame
    public void Atacar()
    {
        if(_arma.duracionActual <= 0)
        {
            _textMeshPro.text = "El arma " + _arma.nombre + " se ha roto y no puede ser usada.";
            return;
        }

        _textMeshPro.text = "Atacando con " + _arma.nombre + " causando " + _arma.danio + " de daño, tu arma durará " + _arma.duracionActual + " veces mas.";
        _arma.duracionActual--; // es necesario usar una variable distinta porque sino, los datos quedaran guardados en el scriptable object
    }
}
