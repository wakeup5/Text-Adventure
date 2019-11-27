using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0f, 0.5f, 1f)]
[TrackClipType(typeof(TargetSwitcherClip))]
[TrackBindingType(typeof(Targetable))]
public class TargetSwitcherTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<TargetSwitcherMixerBehaviour>.Create (graph, inputCount);
    }
}
