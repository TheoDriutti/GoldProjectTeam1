/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjHolder : MonoBehaviour
{
    public float timeBtwProj;
    public Transform endPoint;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(LaunchProj());


    }

    
    IEnumerator LaunchProj()
    {
        yield return new WaitForSeconds(timeBtwProj);
        Instantiate(projectile, transform.position, Quaternion.identity);
        StartCoroutine(LaunchProj());

    }


}
*/