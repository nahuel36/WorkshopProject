using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class BindingUIToolkitInventario : MonoBehaviour
{
    [SerializeField] UIDocument _document;
    [SerializeField] UIToolkitEnRuntimeInventario _target;
    [SerializeField] VisualTreeAsset _itemsBuilder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        var root = _document.rootVisualElement;

        foreach (var item in _target.miInventario)
        {
            var itemElement = _itemsBuilder.Instantiate();
            itemElement.Q<Label>().text = item.nombreItem;
            itemElement.Q<Image>().sprite = item.imagen;
            root.Q("inventoryContainer").Add(itemElement);
        }
    }

}
