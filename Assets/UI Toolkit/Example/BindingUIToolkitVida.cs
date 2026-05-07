using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System;
public class BindingUIToolkitVida : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] UIToolkitEnRuntimeVida target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = document.rootVisualElement;

        root.Q<ProgressBar>().value = target.vida;

        var fill = root.Q<ProgressBar>().Q(className: "unity-progress-bar__progress");
        fill.style.backgroundColor = Color.green;


        root.Q<ProgressBar>().RegisterValueChangedCallback(value => {
            var fill = root.Q<ProgressBar>().Q(className: "unity-progress-bar__progress");
            fill.style.backgroundColor = Color.Lerp(Color.red, Color.green, (float)target.vida / 100f);
        });

        UIToolkitEnRuntimeVida.OnVidaChanged += () => {
            root.Q<ProgressBar>().value = target.vida;
        };

        root.Q<Label>().text = target.nombrePJ;

    }

}
