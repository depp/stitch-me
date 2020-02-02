using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    [TrackColor(0.1981132f, 0.5f, 0.1065063f)]
    [TrackClipType(typeof(Vector3Clip))]
    [TrackBindingType(typeof(RectTransform))]
    public class RectTransformPositionTrack : LerpToTargetTrack
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            StoreClipProperties(go);
            ScriptPlayable<RectTransformPositionMixerBehaviour> trackPlayable = ScriptPlayable<RectTransformPositionMixerBehaviour>.Create(graph, inputCount);
            RectTransformPositionMixerBehaviour behaviour = trackPlayable.GetBehaviour();

            return trackPlayable;
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            var comp = director.GetGenericBinding(this) as RectTransform;
            if (comp == null)
                return;

            driver.AddFromName<RectTransform>(comp.gameObject, "m_AnchoredPosition.x");
            driver.AddFromName<RectTransform>(comp.gameObject, "m_AnchoredPosition.y");
            driver.AddFromName<RectTransform>(comp.gameObject, "m_LocalPosition.x");
            driver.AddFromName<RectTransform>(comp.gameObject, "m_LocalPosition.y");
            driver.AddFromName<RectTransform>(comp.gameObject, "m_LocalPosition.z");

            //var so = new UnityEditor.SerializedObject(comp);
            //var iter = so.GetIterator();
            //while (iter.NextVisible(true)) {
            //    if (iter.hasVisibleChildren)
            //        continue;
            //    driver.AddFromName<RectTransform>(comp.gameObject, iter.propertyPath);
            //}
#endif
            base.GatherProperties(director, driver);
        }
    }
}