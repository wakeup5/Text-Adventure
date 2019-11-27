using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.75f, 0.1f, 0.75f)]
[TrackClipType(typeof(FadeAnimationClip))]
[TrackBindingType(typeof(TextMesh))]
public class FadeAnimationTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<FadeAnimationMixerBehaviour>.Create (graph, inputCount);
    }
}
