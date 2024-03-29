using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TargetSwitcherMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Targetable trackBinding = playerData as Targetable;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
			
			if (inputWeight < 1f)
			{
				continue;
			}

            ScriptPlayable<TargetSwitcherBehaviour> inputPlayable = (ScriptPlayable<TargetSwitcherBehaviour>)playable.GetInput(i);
            TargetSwitcherBehaviour input = inputPlayable.GetBehaviour ();

			// Use the above variables to process each frame of this playable.
			trackBinding.Target = input.Target;
		}
    }
}
