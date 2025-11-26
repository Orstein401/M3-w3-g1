using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletPlController : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float fireRange;

    [SerializeField] private Bullet BulletPrefab;
    private float LastimeShot;



    public GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 player = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        float distance;
        float min = fireRange;

        GameObject NearEnemy = null;
        foreach (GameObject enemy in enemys)
        {
            
            distance = Vector2.Distance(enemy.transform.position, player);
            
            if (distance<min)
            {
               NearEnemy = enemy;
               min= distance;
            }

           

        }
        
        return NearEnemy;

       
        //for (int i = 0; i < enemys.Length; i++)
        //{
        //    float enemX = enemys[i].transform.position.x;
        //    float enemY = enemys[i].transform.position.y;

        //    Vector2 EnemVect = new Vector2(enemX, enemY);

        //    if (i != enemys.Length - 1)
        //    {
        //        float enem2X = enemys[i + 1].transform.position.x;
        //        float enem2Y = enemys[i + 1].transform.position.y;
        //    }


        //    Vector2 Enem2Vect = new Vector2(enemX, enemY);


        //    float distanza1 = Vector2.Distance(EnemVect, player);
        //    float distanza2 = Vector2.Distance(Enem2Vect, player);

        //    if (distanza1 < distanza2)
        //    {
        //        Debug.Log("il secondo è più vicino");
        //    }
        //    else
        //    {
        //        Debug.Log("il primo è più vicino");
        //    }



        //}
    }

    public void Shoot()
    {
        GameObject CloseEnemy = FindNearestEnemy();    
        
        if (CloseEnemy)
        {
            Vector2 direction = CloseEnemy.transform.position - gameObject.transform.position;
            direction.Normalize();
            Bullet bullet = Instantiate(BulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.SetUp(direction);
        }
    }

    private void Update()
    {
        if(Time.time- LastimeShot> fireRate)
        {
            LastimeShot = Time.time;
            Shoot();
        }
    }
}