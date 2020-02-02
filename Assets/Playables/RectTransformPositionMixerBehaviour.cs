using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class RectTransformPositionMixerBehaviour : LerpToTargetMixerBehaviour
    {
        RectTransform trackBinding;
        ScriptPlayable<Vector3Behaviour> inputPlayable;
        Vector3Behaviour input;
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            trackBinding = playerData as RectTransform;

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
                    trackBinding.anchoredPosition3D = Vector3.Lerp(input.initialValue, input.targetValue, input.easingFunction(0f, 1f, percentageComplete));
                } else {
                    if(currentTime >= input.endTime) {
                        trackBinding.anchoredPosition3D = input.targetValue;
                    } else if (i == 0 && currentTime <= input.startTime) {
                        trackBinding.anchoredPosition3D = input.initialValue;
                    }
                }
            }
        }
    }
}