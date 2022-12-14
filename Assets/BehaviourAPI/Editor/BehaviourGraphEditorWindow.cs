using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BehaviourAPI.Editor
{
    using Runtime.Core;
    public class BehaviourGraphEditorWindow : EditorWindow
    {
        public static BehaviourEngine Graph;
        /// <summary>
        /// Edit an existing graph.
        /// </summary>
        public static void OpenGraph(BehaviourEngine graph)
        {
            Graph = graph;
            BehaviourGraphEditorWindow wnd = GetWindow<BehaviourGraphEditorWindow>();
            wnd.titleContent = new GUIContent($"GraphEditor ({graph.GetType().Name})");
        }

        /// <summary>
        /// Create a new behaviour graph.
        /// </summary>
        [MenuItem("BehaviourAPI/EditorWindow")]
        public static void CreateGraph()
        {

        }

        public void CreateGUI()
        {
            AddVisualElements();
            AddStyles();
        }

        private void AddVisualElements()
        {
            BehaviourGraphView behaviourGraphView = new BehaviourGraphView(Graph, this);
            behaviourGraphView.StretchToParentSize();

            rootVisualElement.Add(behaviourGraphView);

            ElementInspector inspector = new ElementInspector();
            behaviourGraphView.SetElementInspector(inspector);
            rootVisualElement.Add(inspector);

            behaviourGraphView.DrawGraph();
        }

        private void AddStyles()
        {
            StyleSheet styleSheet = VisualSettings.GetOrCreateSettings().VariablesStylesheet;
            rootVisualElement.styleSheets.Add(styleSheet);
        }
    }

}