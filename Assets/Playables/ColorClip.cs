using System;
using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    [Serializable]
    public class ColorClip : LerpToTargetClip
    {
        [SerializeField]
        private ColorBehaviour _template = new ColorBehaviour();

        public ColorBehaviour template
        {
            get => _template;
            set => _template = value;
        }
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            template.startTime = startTime;
            template.endTime = endTime;

            var playable = ScriptPlayable<ColorBehaviour>.Create(graph, template);
            return playable;
        }
    }
}