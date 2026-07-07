using UnityEngine;

public class RigFollowBot : MonoBehaviour
{
    public Transform botHead;

    void LateUpdate()
    {
        transform.position = new Vector3(
            botHead.position.x,
            0f,
            botHead.position.z
        );
        transform.rotation = Quaternion.identity;
    }
}