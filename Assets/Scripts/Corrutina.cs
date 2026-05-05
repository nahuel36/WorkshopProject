using UnityEngine;
using System.Collections;
public class Corrutina : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        textMeshPro.text = "3";
        yield return new WaitForSeconds(1f);
        textMeshPro.text = "2";
        yield return new WaitForSeconds(1f);
        textMeshPro.text = "1";
        yield return new WaitForSeconds(1f);
        textMeshPro.text = "Go!";
    }
}
