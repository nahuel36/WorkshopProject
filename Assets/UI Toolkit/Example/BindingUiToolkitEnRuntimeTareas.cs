using UnityEngine;
using UnityEngine.UIElements;

public class BindingUiToolkitEnRuntimeListaTareas : MonoBehaviour
{
    [SerializeField] UIDocument _document;
    [SerializeField] UIToolkitEnRuntimeListaTareas _target;
    [SerializeField] VisualTreeAsset _itemsBuilder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        var root = _document.rootVisualElement;

        var listView = root.Q<VisualElement>().Q<ListView>();
        listView.itemsSource = _target.listaTareas;

        // CREAR ELEMENTO VISUAL
        listView.makeItem = () => new Label();

        // BINDEAR DATOS
        listView.bindItem = (element, index) =>
        {
            element.Clear();
            VisualElement itemElement = _itemsBuilder.Instantiate();
            itemElement.Q<TextField>().value = _target.listaTareas[index].nombreTarea;

            itemElement.Q<TextField>().RegisterValueChangedCallback(evt =>
            {
                _target.listaTareas[index].nombreTarea = evt.newValue;
            });

            itemElement.Q<Toggle>().value = _target.listaTareas[index].terminada;

            itemElement.Q<Toggle>().RegisterValueChangedCallback(evt =>
            {
                _target.listaTareas[index].terminada = evt.newValue;
            });

            element.Add(itemElement);

        };

        

        listView.onAdd += (lv) =>
        {
            _target.listaTareas.Add(new MiTarea() { nombreTarea = "Nueva tarea", terminada = false });

            listView.RefreshItems();
        };

        
        listView.RefreshItems();
    }

}
