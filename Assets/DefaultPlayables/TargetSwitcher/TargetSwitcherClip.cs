using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TargetSwitcherClip : PlayableAsset, ITimelineClipAsset
{
    public TargetSwitcherBehaviour template = new TargetSwitcherBehaviour ();
    public ExposedReference<Transform> Target;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TargetSwitcherBehaviour>.Create (graph, template);
        TargetSwitcherBehaviour clone = playable.GetBehaviour ();
        clone.Target = Target.Resolve (graph.GetResolver ());
        return playable;
    }
}
