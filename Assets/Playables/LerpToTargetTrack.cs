using System;
using UnityEngine;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    [Serializable]
    public class LerpToTargetTrack : TrackAsset
    {
        public void StoreClipProperties(GameObject directorObject)
        {
            foreach (var clip in GetClips()) {
                var myAsset = clip.asset as LerpToTargetClip;
                if (myAsset) {
                    myAsset.startTime = clip.start;
                    myAsset.endTime = clip.end;
                }
            }
        }
    }
}