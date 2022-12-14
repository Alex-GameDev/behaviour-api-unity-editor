using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourAPI.Runtime.UtilitySystems
{

    /// <summary>
    /// Utility element that handle multiple <see cref="UtilityElement"/> itself and
    /// returns the maximum utility if its best candidate utility is higher than the threshold.
    /// </summary>
    public class UtilityBucket : UtilityElement
    {
        public override string Name => "Utility Action";
        public override string Description => "Utility element that choose between multiple Utility elements.";
        public override Type ChildType => typeof(UtilityElement);
        public override int MaxOutputConnections => -1;
        [Range(0f, 1f)] public float UtilityThreshold = .3f;
        [Range(0f, 1f)] public float inertia = .3f;
        List<UtilityElement> m_utilityCandidates;
        UtilityElement m_currentBestAction;

        protected override float ComputeUtility()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            m_currentBestAction.Update();
        }
    }
}
