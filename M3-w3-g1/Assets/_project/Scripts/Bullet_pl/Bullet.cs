using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Vector2 direction;

    public void SetUp(Vector2 direction)
    {
        this.direction= direction;
        
    }

    private void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(collision.gameObject);
            
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * (speed * Time.fixedDeltaTime));
    }
}
