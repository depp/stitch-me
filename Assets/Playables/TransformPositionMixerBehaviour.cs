using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class TransformPositionMixerBehaviour : LerpToTargetMixerBehaviour
    {
        Transform trackBinding;
        ScriptPlayable<Vector3Behaviour> inputPlayable;
        Vector3Behaviour input;
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            trackBinding = playerData as Transform;

            if (!trackBinding) {
                return;
            }

            inputCount = playable.GetInputCount ();
            
            for (int i = 0; i < inputCount; i++)
            {
                inputWeight = playable.GetInputWeight(i);
                inputPlayable = (ScriptPlayable<Vector3Behaviour>)playable.GetInput(i);
                input = inputPlayable.GetBehaviour ();
               
                if(inputWeight >= 1f) {
                    percentageComplete = (float)(inputPlayable.GetTime() / inputPlayable.GetDuration());
                    trackBinding.localPosition = Vector3.Lerp(input.initialValue, input.targetValue, input.easingFunction(0f, 1f, percentageComplete));
                } else {
                    if(currentTime >= input.endTime) {
                        trackBinding.localPosition = input.targetValue;
                    } else if (i == 0 && currentTime <= input.startTime) {
                        trackBinding.localPosition = input.initialValue;
                    }
                }
            }
        }
    }
}