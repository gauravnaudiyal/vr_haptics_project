using UnityEngine;
using Bhaptics.SDK2;

public class FootstepAudio : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public TactSuitController tactSuitController;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LeftFootStep()
    {
        if (ExperimentManager.Instance.AudioEnabled) PlayStepSound();
        if (ExperimentManager.Instance.HapticsEnabled)
        {
            BhapticsLibrary.Play("footstepleft");
            if (tactSuitController != null) tactSuitController.PlayLeftStep();
        }
    }

    public void RightFootStep()
    {
        if (ExperimentManager.Instance.AudioEnabled) PlayStepSound();
        if (ExperimentManager.Instance.HapticsEnabled)
        {
            BhapticsLibrary.Play("footstepright");
            if (tactSuitController != null) tactSuitController.PlayRightStep();
        }
    }

    void PlayStepSound()
    {
        if (footstepSounds.Length == 0) return;
        AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}