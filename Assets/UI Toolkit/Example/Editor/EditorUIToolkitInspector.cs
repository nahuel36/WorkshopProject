using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(UIToolkitEnInspector))]
public class EditorUIToolkitInspector : Editor
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    public override VisualElement CreateInspectorGUI()
    {   
        // Each editor window contains a root VisualElement object
        VisualElement root = new VisualElement();

        // Pone los campos por defecto de la clase en el inspector
        InspectorElement.FillDefaultInspector(root, serializedObject, this);

        // Instantiate UXML
        VisualElement fromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(fromUXML);



        return root;
    }
    
}

