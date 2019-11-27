using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class FadeAnimationMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
		TextMesh trackBinding = playerData as TextMesh;

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

            ScriptPlayable<FadeAnimationBehaviour> inputPlayable = (ScriptPlayable<FadeAnimationBehaviour>)playable.GetInput(i);

			FadeAnimationBehaviour input = inputPlayable.GetBehaviour ();

			// Use the above variables to process each frame of this playable.
			double w = inputPlayable.GetTime() / inputPlayable.GetDuration();

			Color color = trackBinding.color;
			color.a = input.Alpha.Evaluate((float)w);
			trackBinding.color = color;
		}
    }
}
