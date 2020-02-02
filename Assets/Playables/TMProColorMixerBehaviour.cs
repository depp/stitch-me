using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class TMProColorMixerBehaviour : LerpToTargetMixerBehaviour
    {
        private TMP_Text _trackBinding;

        private TMP_Text trackBinding
        {
            get => _trackBinding;
            set => _trackBinding = value;
        }

        private ScriptPlayable<ColorBehaviour> _inputPlayable;

        private ScriptPlayable<ColorBehaviour> inputPlayable
        {
            get => _inputPlayable;
            set => _inputPlayable = value;
        }

        private ColorBehaviour _input;

        private ColorBehaviour input
        {
            get => _input;
            set => _input = value;
        }
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            trackBinding = playerData as TMP_Text;

            if (trackBinding == null || trackBinding.gameObject.active == false)
                return;
            
            inputCount = playable.GetInputCount();
            

            for (int i = 0; i < inputCount; i++)
            {
                inputWeight = playable.GetInputWeight(i);
                inputPlayable = (ScriptPlayable<ColorBehaviour>)playable.GetInput(i);
                input = inputPlayable.GetBehaviour ();

                if (inputWeight >= 1f) {
                    percentageComplete = (float)(inputPlayable.GetTime() / inputPlayable.GetDuration());
                    trackBinding.color = Color.Lerp(input.initialValue, input.targetValue, input.easingFunction(0f, 1f, percentageComplete));
                }
                else {
                    if(currentTime >= input.endTime) {
                        trackBinding.color = input.targetValue;
                    } else if (i == 0 && currentTime <= input.startTime) {
                        trackBinding.color = input.initialValue;
                    }
                }
            }
        }
    }
}