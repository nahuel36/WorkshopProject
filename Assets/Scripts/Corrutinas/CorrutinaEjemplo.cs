using UnityEngine;
using System.Collections;
public class CorrutinaEjemplo : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        _textMeshPro.text = "3";
        yield return new WaitForSeconds(1f);
        _textMeshPro.text = "2";
        yield return new WaitForSeconds(1f);
        _textMeshPro.text = "1";
        yield return new WaitForSeconds(1f);
        _textMeshPro.text = "Go!";
    }
}
