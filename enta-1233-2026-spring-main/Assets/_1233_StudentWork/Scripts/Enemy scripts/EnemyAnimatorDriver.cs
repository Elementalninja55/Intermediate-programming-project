using UnityEngine;

/// <summary>
///     Centralizes animation calls for enemies.
///     Provides a clean API for other components to trigger animations
/// </summary>
public class EnemyAnimatorDriver : MonoBehaviour
{
    // Cached hashes for performance
    private static readonly int SpeedHash = Animator.StringToHash(name: "Speed");
    private static readonly int IsMovingHash = Animator.StringToHash(name: "IsMoving");
    private static readonly int AttackTriggerHash = Animator.StringToHash(name: "Attack");
    private static readonly int HitTriggerHash = Animator.StringToHash(name: "Hit");
    private static readonly int DieTriggerHash = Animator.StringToHash(name: "Die");
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        if (_animator == null)
            _animator = GetComponentInChildren<Animator>();
    }

    public void SetSpeed(float speed)
    {
        if (_animator == null) return;
        _animator.SetFloat(id:SpeedHash, speed);
        _animator.SetBool(id:IsMovingHash, speed > 0.1f);
    }

    public void TriggerAttack()
    {
        if (_animator == null) return;
        _animator.SetTrigger(id:AttackTriggerHash);
    }

    public void TriggerHit()
    {
        if (_animator == null) return;
        _animator.SetTrigger(id:HitTriggerHash);
    }

    public void TriggerDie()
    { 
        if (_animator == null) return;
        _animator.SetTrigger(id:DieTriggerHash);
    }
}
