using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjLauncher : MonoBehaviour
{
    public GameObject proj;
    public float projRepTime;

    void Start()
    {
        StartCoroutine(RepeatProj());
    }

    IEnumerator RepeatProj()
    {
        yield return new WaitForSeconds(projRepTime);
        GameObject bullet = Instantiate(proj, transform.position, transform.rotation);
        bullet.transform.parent = transform;
        StartCoroutine(RepeatProj());
    }
}
