using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class BindingUIToolkitInventario : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] UIToolkitEnRuntimeInventario target;
    [SerializeField] VisualTreeAsset itemsBuilder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = document.rootVisualElement;

        foreach (var item in target.miInventario)
        {
            var itemElement = itemsBuilder.Instantiate();
            itemElement.Q<Label>().text = item.nombreItem;
            itemElement.Q<Image>().sprite = item.imagen;
            root.Q("inventoryContainer").Add(itemElement);
        }

    }


}
