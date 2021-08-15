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

    public void Jump(Vector2 direction) 
    {
        _rigidbody.AddForce(direction * (_force - _rigidbody.velocity.y));
    }

}
