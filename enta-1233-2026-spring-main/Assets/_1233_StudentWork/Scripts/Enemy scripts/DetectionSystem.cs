using UnityEngine;

/// <summary>
///     Handles detection logic including range and line-of-sight checks.
/// </summary>
public class DetectionSystem : MonoBehaviour
{
    [SerializeField] private Transform _eyeposition;
    [SerializeField] private float _detectionRange = 15f;
    [SerializeField] private float _fieldOfView = 120f;
    [SerializeField] private LayerMask _obstrucitonMask;

    public float DetectionRange => _detectionRange;

    private void Awake()
    {
        if (_eyeposition == null) _eyeposition = transform;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);

        // Draw FOV cone
        var leftDir:Vector3 = Quaternion.Euler(0, -_fieldOfView / 2, 0) * transform.forward;
        var rightDir:Vector3 = Quaternion.Euler(0, _fieldOfView / 2, 0) * transform.forward;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(from: transform.position, direction: leftDir * _detectionRange);
        Gizmos.DrawRay(from: transform.position, direction: rightDir * _detectionRange);
    }

    public bool IsTargetInDetectionRange(Transform target)
    {
        if (target == null) return false;
        return Vector3.Distance(transform.position, target.position) <= _detectionRange;
    }

    public bool HasLineOfSight(Transform target)
    {
        if (target == null) return false;

        var directionToTarget:Vector3 = (target.position - _eyeposition.position).normalized;
        var distanceToTarget:float = Vector3.Distance(_eyeposition.position, target.position);

        // Check if target is within FOV
        if (Physics.Raycast(origin: _eyeposition.position, directionToTarget,
            out var hit, distanceToTarget, _obstructionMask))
            // If we hit something other than the target
            // (or a child of the target), then LOS is blocked
            if (hit.transform != target && !hit.transform.IsChildOf(target))
                return false;

        return true;
    }
}
