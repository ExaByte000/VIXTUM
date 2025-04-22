using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float topLimit;
    [SerializeField] private float bottomLimit;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, topLimit, bottomLimit),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new(leftLimit, topLimit), new(rightLimit, topLimit));
        Gizmos.DrawLine(new(leftLimit, bottomLimit), new(rightLimit, bottomLimit));
        Gizmos.DrawLine(new(leftLimit, topLimit), new(leftLimit, bottomLimit));
        Gizmos.DrawLine(new(rightLimit, topLimit), new(rightLimit, bottomLimit));
    }
}
