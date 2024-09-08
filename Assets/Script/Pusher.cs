using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class Pusher : MonoBehaviour
{
    [SerializeField] float _pushForce;
    private Rigidbody _rigidbody;

    public void Push()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.AddForce(transform.forward * _pushForce, ForceMode.Impulse);        
    }
}
