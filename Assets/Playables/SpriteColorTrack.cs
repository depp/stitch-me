using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    [TrackColor(0.6981132f, 0f, 0.1065063f)]
    [TrackClipType(typeof(ColorClip))]
    [TrackBindingType(typeof(SpriteRenderer))]
    public class SpriteColorTrack : LerpToTargetTrack
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            StoreClipProperties(go);
            ScriptPlayable<SpriteColorMixerBehaviour> trackPlayable = ScriptPlayable<SpriteColorMixerBehaviour>.Create(graph, inputCount);
            SpriteColorMixerBehaviour behaviour = trackPlayable.GetBehaviour();

            return trackPlayable;
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            //var comp = director.GetGenericBinding(this) as SpriteRenderer;
            //if (comp == null)
            //    return;
            //var so = new UnityEditor.SerializedObject(comp);
            //var iter = so.GetIterator();
            //while (iter.NextVisible(true)) {
            //    if (iter.hasVisibleChildren)
            //        continue;
            //    Debug.Log(iter.propertyPath);
            //    driver.AddFromName<SpriteRenderer>(comp.gameObject, iter.propertyPath);
            //}

            SpriteRenderer trackBinding = director.GetGenericBinding(this) as SpriteRenderer;
            if (trackBinding == null)
                return;

            driver.AddFromName<SpriteRenderer>(trackBinding.gameObject, "m_Color");
#endif
            base.GatherProperties(director, driver);
        }
    }
}