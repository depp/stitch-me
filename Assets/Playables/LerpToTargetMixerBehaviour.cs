using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class LerpToTargetMixerBehaviour : PlayableBehaviour
    {
        
        private double _currentTime;

        protected double currentTime
        {
            get => _currentTime;
            set => _currentTime = value;
        }
        
        
        // Utility vars - specified here to prevent garbage collection
        private int _inputCount;

        protected int inputCount
        {
            get => _inputCount;
            set => _inputCount = value;
        }

        private float _inputWeight;

        protected float inputWeight
        {
            get => _inputWeight;
            set => _inputWeight = value;
        }
        
        private float _percentageComplete;

        protected float percentageComplete
        {
            get => _percentageComplete;
            set => _percentageComplete = value;
        }
        
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            base.PrepareFrame(playable, info);
            currentTime = playable.GetGraph().GetRootPlayable(0).GetTime();
        }
    }
}