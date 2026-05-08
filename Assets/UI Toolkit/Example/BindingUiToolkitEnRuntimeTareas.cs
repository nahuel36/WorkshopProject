using UnityEngine;
using UnityEngine.UIElements;

public class BindingUiToolkitEnRuntimeListaTareas : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] UIToolkitEnRuntimeListaTareas target;
    [SerializeField] VisualTreeAsset itemsBuilder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        var root = document.rootVisualElement;

        var listView = root.Q<VisualElement>().Q<ListView>();
        listView.itemsSource = target.listaTareas;

        // CREAR ELEMENTO VISUAL
        listView.makeItem = () => new Label();

        // BINDEAR DATOS
        listView.bindItem = (element, index) =>
        {
            element.Clear();
            VisualElement itemElement = itemsBuilder.Instantiate();
            itemElement.Q<TextField>().value = target.listaTareas[index].nombreTarea;

            itemElement.Q<TextField>().RegisterValueChangedCallback(evt =>
            {
                target.listaTareas[index].nombreTarea = evt.newValue;
            });

            itemElement.Q<Toggle>().value = target.listaTareas[index].terminada;

            itemElement.Q<Toggle>().RegisterValueChangedCallback(evt =>
            {
                target.listaTareas[index].terminada = evt.newValue;
            });

            element.Add(itemElement);

        };

        

        listView.onAdd += (lv) =>
        {
            target.listaTareas.Add(new MiTarea() { nombreTarea = "Nueva tarea", terminada = false });

            listView.RefreshItems();
        };

        
        listView.RefreshItems();
    }

}
