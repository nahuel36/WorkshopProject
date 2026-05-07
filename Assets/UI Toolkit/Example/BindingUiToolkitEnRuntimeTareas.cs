using UnityEngine;
using UnityEngine.UIElements;

public class BindingUiToolkitEnRuntimeListaTareas : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] UIToolkitEnRuntimeListaTareas target;
    [SerializeField] VisualTreeAsset itemsBuilder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

            itemElement.Q<Toggle>().value = target.listaTareas[index].terminada;


            element.Add(itemElement);

        };

        

        listView.onAdd += (lv) =>
        {
            target.listaTareas.Add(new MiTarea() { nombreTarea = "Nueva tarea", terminada = false });

            listView.RefreshItems();
        };

        
        listView.RefreshItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
