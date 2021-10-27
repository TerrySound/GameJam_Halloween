using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSFX : MonoBehaviour
{
    public void FootstepsSFX() 
    {
        AkSoundEngine.PostEvent("Footsteps", gameObject);
    }
}
