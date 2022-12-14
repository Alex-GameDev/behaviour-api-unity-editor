using System.Collections.Generic;
using BehaviourAPI.Runtime.Core;
using System.Linq;

namespace BehaviourAPI.Runtime.BehaviourTrees
{
    /// <summary>
    /// BTNode type that has multiple children and executes them according to certain conditions.
    /// </summary>
    public abstract class CompositeNode : BTNode
    {
        public sealed override int MaxOutputConnections => -1;
        List<BTNode> m_childNodes;
        BTNode m_currentChildNode => m_childNodes[m_currentChildIndex];
        int m_currentChildIndex;
        bool m_newChildSelected;

        public override void Initialize(Context context)
        {
            base.Initialize(context);
            m_childNodes = new List<BTNode>();
            OutputConnections.ForEach(conn => m_childNodes.Add(conn.TargetNode as BTNode));
            GetChildNodes().ToList().ForEach(node => m_childNodes.Add(node as BTNode));
        }

        public override void Start()
        {
            base.Start();
            InitializeList();
            m_currentChildNode.Start();
        }

        public override Status UpdateStatus()
        {
            if (m_newChildSelected)
            {
                m_currentChildNode.Start();
                m_newChildSelected = false;
            }
            var status = m_currentChildNode.Status;
            m_currentChildNode.Update();
            Status = GetModifiedChildStatus(status);
            return Status;
        }

        protected bool TryGoToNextChild()
        {
            m_currentChildIndex++;
            m_newChildSelected = true;
            return m_currentChildIndex < m_childNodes.Count;
        }

        protected abstract Status GetModifiedChildStatus(Status currentChildStatus);

        protected virtual void InitializeList()
        {
            m_currentChildIndex = 0;
        }

        protected List<BTNode> GetChilds() => m_childNodes;

    }
}