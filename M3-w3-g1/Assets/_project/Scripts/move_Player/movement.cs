using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Vector2 _input;

    public void SetInputNormalize(Vector2 input)
    {
        float lengthVect = input.magnitude;
        if (lengthVect > 1)
        {
            input /= lengthVect; //Mathf.Sqrt(lengthVect);
        }
        _input = input;

    }

    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_input!=Vector2.zero)
        {
            _rb.MovePosition(_rb.position + _input * (speed * Time.deltaTime));
        }
        
    }
}
