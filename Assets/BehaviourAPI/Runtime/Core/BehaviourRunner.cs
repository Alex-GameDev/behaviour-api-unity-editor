using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BehaviourAPI.Runtime.Core
{
    /// <summary>
    /// Component that executes a behavior graph using itself as a context.
    /// </summary>
    public class BehaviourRunner : MonoBehaviour
    {
        public BehaviourEngine RootGraph;

        private void Awake()
        {
            RootGraph.Initialize();
        }

        private void Start()
        {
            RootGraph.Start();
        }

        private void Update()
        {
            RootGraph.Update();
        }
    }
}
