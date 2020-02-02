using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [Serializable]
    public class LerpToTargetBehaviour : PlayableBehaviour
    {
        [SerializeField]
        [FormerlySerializedAs("ease")]
        private EasingFunction.Ease _ease = EasingFunction.Ease.EaseInOutQuad;

        public EasingFunction.Ease ease
        {
            get => _ease;
            set => _ease = value;
        }

        [HideInInspector]
        private double _startTime;

        public double startTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        [HideInInspector]
        private double _endTime;

        public double endTime
        {
            get => _endTime;
            set => _endTime = value;
        }

        [HideInInspector]
        private EasingFunction.Function _easingFunction;

        public EasingFunction.Function easingFunction
        {
            get => _easingFunction;
            set => _easingFunction = value;
        }
        
        public override void OnGraphStart(Playable playable)
        {
            base.OnGraphStart(playable);
            easingFunction = EasingFunction.GetEasingFunction(ease);
        }
    }
}