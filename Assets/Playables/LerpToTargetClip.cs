using System;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    [Serializable]
    public abstract class LerpToTargetClip : PlayableAsset, ITimelineClipAsset {
        
        private double _startTime;

        public double startTime
        {
            get => _startTime;
            set => _startTime = value;
        }
        
        private double _endTime;
        
        public double endTime
        {
            get => _endTime;
            set => _endTime = value;
        }
        
        public override double duration => 1d;

        public ClipCaps clipCaps => ClipCaps.None;
    }
}