using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Transform target;
    Vector3 direction;
    public float projSpeed;

    void Start()
    {
        direction = target.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, projSpeed * Time.deltaTime);
        if (transform.position == direction)
        {
            //Destroy(gameObject);
        }
    }
}
