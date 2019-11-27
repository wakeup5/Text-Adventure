using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class FadeAnimationBehaviour : PlayableBehaviour
{
    public AnimationCurve Alpha;

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
