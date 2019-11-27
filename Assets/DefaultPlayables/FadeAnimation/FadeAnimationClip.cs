using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class FadeAnimationClip : PlayableAsset, ITimelineClipAsset
{
    public FadeAnimationBehaviour template = new FadeAnimationBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<FadeAnimationBehaviour>.Create (graph, template);
        FadeAnimationBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
