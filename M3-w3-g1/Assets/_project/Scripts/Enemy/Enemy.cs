using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private movement Player;


    private void Awake()
    {
        Player = FindAnyObjectByType<movement>();

    }

    public void EnemyMovement()
    {
        if (Player != null)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        EnemyMovement();
    }
}
