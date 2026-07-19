using UnityEngine;

public class PathWalker : MonoBehaviour
{
    public float walkSpeed = 1.4f;
    public float resetDistance = 23f;

    public bool IsPaused = true; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (IsPaused) return;

        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

        if (transform.position.z - startPosition.z >= resetDistance)
        {
            transform.position = startPosition;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}