using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform direction;
    public float projSpeed;

    void Start()
    {
        transform.LookAt(direction);
    }

    void Update()
    {
        
    }

    public void Proj()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.transform.position, projSpeed * Time.deltaTime);
        if (transform.position == direction.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
