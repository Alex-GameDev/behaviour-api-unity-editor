using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace BehaviourAPI.Editor
{
    public class NodeView : UnityEditor.Experimental.GraphView.Node
    {
        public NodeView() : base(AssetDatabase.GetAssetPath(VisualSettings.GetOrCreateSettings().NodeLayout))
        {
            SetUp();
        }

        private void SetUp()
        {

        }
    }
}