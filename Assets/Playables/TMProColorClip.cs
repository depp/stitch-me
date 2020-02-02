using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class TMProColorClip : LerpToTargetClip
    {
        [SerializeField]
        private TMProColorBehaviour _template = new TMProColorBehaviour();

        public TMProColorBehaviour template
        {
            get => _template;
            set => _template = value;
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            template.startTime = startTime;
            template.endTime = endTime;

            var playable = ScriptPlayable<TMProColorBehaviour>.Create(graph, template);
            return playable;
        }
    }
}