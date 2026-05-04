using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 0f;
    public float fixedY = 0f;

    void Start()
    {
        fixedY = transform.position.y; // lock Y position
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                player.position.x + offsetX,
                fixedY,
                transform.position.z
            );
        }
    }
}