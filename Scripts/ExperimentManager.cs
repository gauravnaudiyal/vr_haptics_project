using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ConditionType { A_VisualAudio1PP, B_Combined1PP, C_VisualAudio3PP, D_Control }

public class ExperimentManager : MonoBehaviour
{
    public static ExperimentManager Instance;

    public ConditionType CurrentCondition;

    public bool HapticsEnabled { get; private set; }
    public bool AudioEnabled { get; private set; }
    public bool FirstPerson { get; private set; }

    [Header("Bot Reset")]
    public Transform botTransform;
    public Vector3 botSpawnPosition = new Vector3(0.1f, 0.06999993f, -100.5f);
    public Quaternion botSpawnRotation;
    public float idleYOffset = 1f;

    [Header("Haptics")]
    public TactSuitController tactSuitController;

    [Header("Countdown")]
    public float countdownDuration = 5f;
    public AudioSource countdownAudioSource;
    public AudioClip countdownClip;

    [Header("Playback")]
    public Animator conditionAnimator;
    public PathWalker pathWalker;
    public AudioSource footstepAudioSource;

    private Coroutine countdownRoutine;
    private bool isTransitioning;

    void Awake()
    {
        Instance = this;

        if (botTransform != null)
            botSpawnRotation = botTransform.rotation;
    }

    void Start()
    {
        RequestCondition(ConditionType.A_VisualAudio1PP);
    }

    void Update()
    {
        if (isTransitioning) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame) RequestCondition(ConditionType.A_VisualAudio1PP);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) RequestCondition(ConditionType.B_Combined1PP);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) RequestCondition(ConditionType.C_VisualAudio3PP);
        if (Keyboard.current.digit4Key.wasPressedThisFrame) RequestCondition(ConditionType.D_Control);
    }

    public void RequestCondition(ConditionType condition)
    {
        if (countdownRoutine != null)
            StopCoroutine(countdownRoutine);

        FirstPerson = GetFirstPersonForCondition(condition);

        countdownRoutine = StartCoroutine(CountdownThenSetCondition(condition));
    }

    bool GetFirstPersonForCondition(ConditionType condition)
    {
        switch (condition)
        {
            case ConditionType.A_VisualAudio1PP: return true;
            case ConditionType.B_Combined1PP: return true;
            case ConditionType.C_VisualAudio3PP: return false;
            case ConditionType.D_Control: return true;
        }
        return true;
    }

    IEnumerator CountdownThenSetCondition(ConditionType condition)
    {
        isTransitioning = true;

        StopPlaybackAndReset();
        ResetBot();

        if (countdownAudioSource != null && countdownClip != null)
            countdownAudioSource.PlayOneShot(countdownClip);

        yield return new WaitForSeconds(countdownDuration);

        ApplyCondition(condition);
        StartPlayback();

        isTransitioning = false;
    }

    void ApplyCondition(ConditionType condition)
    {
        CurrentCondition = condition;

        switch (condition)
        {
            case ConditionType.A_VisualAudio1PP:
                HapticsEnabled = false;
                AudioEnabled = true;
                FirstPerson = true;
                break;
            case ConditionType.B_Combined1PP:
                HapticsEnabled = true;
                AudioEnabled = true;
                FirstPerson = true;
                break;
            case ConditionType.C_VisualAudio3PP:
                HapticsEnabled = true;
                AudioEnabled = true;
                FirstPerson = false;
                break;
            case ConditionType.D_Control:
                HapticsEnabled = false;
                AudioEnabled = false;
                FirstPerson = true;
                break;
        }

        if (tactSuitController != null)
            tactSuitController.SetHapticsActive(HapticsEnabled);

        Debug.Log($"Condition set: {condition} | Haptics:{HapticsEnabled} Audio:{AudioEnabled} 1PP:{FirstPerson}");
    }

    void StopPlaybackAndReset()
    {
        if (conditionAnimator != null)
            conditionAnimator.Play("Idle", 0, 0f);

        if (pathWalker != null)
        {
            pathWalker.IsPaused = true;
            pathWalker.ResetPosition();
        }

        if (footstepAudioSource != null)
            footstepAudioSource.Stop();

        if (countdownAudioSource != null)
            countdownAudioSource.Stop();

        if (botTransform != null)
        {
            Vector3 pos = botTransform.position;
            pos.y = botSpawnPosition.y + idleYOffset;
            botTransform.position = pos;
        }
    }

    void StartPlayback()
    {
        if (conditionAnimator != null)
            conditionAnimator.Play("mixamo_com", 0, 0f);

        if (pathWalker != null)
            pathWalker.IsPaused = false;
    }

    void ResetBot()
    {
        if (botTransform == null) return;

        botTransform.position = botSpawnPosition;
        botTransform.rotation = botSpawnRotation;
    }
}