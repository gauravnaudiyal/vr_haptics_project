using UnityEngine;
using Bhaptics.SDK2;

public class TactSuitController : MonoBehaviour
{
    [Header("Vest Pattern Keys")]
    public string leftOscillationKey = "leftoscillation";
    public string rightOscillationKey = "rightoscillation";

    private bool hapticsActive = false;

    void Start()
    {
        if (!BhapticsLibrary.IsBhapticsAvailable(true))
        {
            Debug.LogWarning("bHaptics device not detected. TactSuit vest haptics will be skipped.");
        }
    }

    public void SetHapticsActive(bool active)
    {
        hapticsActive = active;
        if (!active)
        {
            BhapticsLibrary.StopByEventId(leftOscillationKey);
            BhapticsLibrary.StopByEventId(rightOscillationKey);
        }
    }

    public void PlayLeftStep()
    {
        if (!hapticsActive) return;
        BhapticsLibrary.Play(leftOscillationKey);
    }

    public void PlayRightStep()
    {
        if (!hapticsActive) return;
        BhapticsLibrary.Play(rightOscillationKey);
    }
}