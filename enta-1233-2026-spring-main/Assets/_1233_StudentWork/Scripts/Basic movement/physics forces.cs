using UnityEngine;

public class physicsforces : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _force;
    [SerializeField] private bool _continuous;
    [SerializeField] private ForceMode _forcemode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(_force, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
