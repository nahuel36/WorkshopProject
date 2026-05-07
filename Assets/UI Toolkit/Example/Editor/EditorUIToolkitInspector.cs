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

        InspectorElement.FillDefaultInspector(root, serializedObject, this);

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);



        return root;
    }
    
}

