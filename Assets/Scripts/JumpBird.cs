using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpBird : MonoBehaviour
{

    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetForce(float force) 
    {
        _force = force;
    }

    public void Jump() 
    {
        _rigidbody.AddForce(Vector2.up * (_force - _rigidbody.velocity.y));
    }

}
