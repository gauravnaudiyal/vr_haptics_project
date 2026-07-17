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

    [Header("Haptics")]
    public TactSuitController tactSuitController;

    void Awake()
    {
        Instance = this;

        if (botTransform != null)
            botSpawnRotation = botTransform.rotation;

        SetCondition(ConditionType.A_VisualAudio1PP);
    }

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) SetCondition(ConditionType.A_VisualAudio1PP);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) SetCondition(ConditionType.B_Combined1PP);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) SetCondition(ConditionType.C_VisualAudio3PP);
        if (Keyboard.current.digit4Key.wasPressedThisFrame) SetCondition(ConditionType.D_Control);
    }

    public void SetCondition(ConditionType condition)
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

        ResetBot();

        Debug.Log($"Condition set: {condition} | Haptics:{HapticsEnabled} Audio:{AudioEnabled} 1PP:{FirstPerson}");
    }

    void ResetBot()
    {
        if (botTransform == null) return;

        botTransform.position = botSpawnPosition;
        botTransform.rotation = botSpawnRotation;
    }
}