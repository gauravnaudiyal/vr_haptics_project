using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    public Transform cameraOffset;      // XR Origin's "Camera Offset"
    public Camera mainCamera;            // XR Origin's "Main Camera"

    public Vector3 firstPersonOffset = new Vector3(0f, 1.6f, 0f);
    public Vector3 thirdPersonOffset = new Vector3(0f, 2.2f, -4.0f);

    void Update()
    {
        bool fpp = ExperimentManager.Instance.FirstPerson;

        cameraOffset.localPosition = fpp ? firstPersonOffset : thirdPersonOffset;

        int avatarLayerBit = 1 << LayerMask.NameToLayer("AvatarBody");

        if (fpp)
            mainCamera.cullingMask &= ~avatarLayerBit;   // hide avatar body
        else
            mainCamera.cullingMask |= avatarLayerBit;    // show avatar body
    }
}