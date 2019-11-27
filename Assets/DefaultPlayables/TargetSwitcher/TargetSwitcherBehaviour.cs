using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TargetSwitcherBehaviour : PlayableBehaviour
{
    public Transform Target;

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
