using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private float _roatationSpeed = 5f;
    [SerializeField] private bool _useSmoothing = true;

    public void FacePosition(Vector3 position)
    {
        var direction:Vector3 = (position - transform.position).normalized;
        direction.y = 0; // Keep rotation on Y axis only

        if (direction.sqrMagnitude < 0.001f) return;

        var targetRotation:Quaternion = Quaternion.LookRotation(direction);

        if (_useSmoothing)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, f:_rotationSpeed * Time.deltaTime);
        else
            transform.rotation = targetRotation;
    }

    public void FaceDirection(Vector3 direction)
    {
        direction.y = 0;
        if (direction.sqrMagnitude < 0.001f) return;
        
        var targetRotation:Quaternion = Quaternion.LookRotation(direction);

        if (_useSmoothing)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, f:_rotationSpeed * Time.deltaTime);
        else
            transform.rotation = targetRotation;
    }
}
