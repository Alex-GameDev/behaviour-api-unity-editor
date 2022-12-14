using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private void OnEnable()
        {
            RootGraph.Initialize(new Context(this));
        }

        private void Start()
        {
            RootGraph.Start();
        }

        private void Update()
        {
            RootGraph.Update();
        }

        private void OnDisable()
        {
            Debug.Log("Reseting");
            RootGraph.Reset();
        }

        [TaskMethod]
        public Status ActionStatus()
        {
            return Status.Sucess;
        }

        [TaskMethod]
        public float ActionStatus1()
        {
            return 2f;
        }

        [TaskMethod]
        public void ActionStatus2()
        {
            var t = Status.Failure;
        }

        [TaskMethod]
        public Status ActionStatus3(float b, float c)
        {
            return Status.Failure;
        }
    }
}
