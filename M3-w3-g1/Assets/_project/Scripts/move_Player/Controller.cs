using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private movement _Move;
    private BulletPlController f;
    private float Horizontal;
    private float Vertical;
    private Vector2 input;

    GameObject a;

    private void Awake()
    {
        _Move = GetComponent<movement>();
        f= GetComponent<BulletPlController>();
    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        input = new Vector2(Horizontal, Vertical);

        _Move.SetInputNormalize(input);
       
       
    }
}
