using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    public ScriptableArma arma;
    public TMPro.TextMeshProUGUI textMeshPro;

    public void Start()
    {
        arma.duracionActual = arma.duracion;
    }

    // Update is called once per frame
    public void Atacar()
    {
        if(arma.duracionActual <= 0)
        {
            textMeshPro.text = "El arma " + arma.nombre + " se ha roto y no puede ser usada.";
            return;
        }

        textMeshPro.text = "Atacando con " + arma.nombre + " causando " + arma.danio + " de daño, tu arma durará " + arma.duracionActual + " veces mas.";
        arma.duracionActual--; // es necesario usar una variable distinta porque sino, los datos quedaran guardados en el scriptable object
    }
}
