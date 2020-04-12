using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animation GivenAnimation;

    public void PlayGivenAnimationClip(string AnimationName)
    {
        GivenAnimation.Play(AnimationName);
    }
}
