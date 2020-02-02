using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class Vector3Clip : LerpToTargetClip
    {
        [SerializeField]
        private Vector3Behaviour _template = new Vector3Behaviour();

        public Vector3Behaviour template
        {
            get => _template;
            set => _template = value;
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            template.startTime = startTime;
            template.endTime = endTime;

            var playable = ScriptPlayable<Vector3Behaviour>.Create(graph, template);
            return playable;
        }
    }
}