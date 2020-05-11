using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Shrink : MonoBehaviour
{
    public float ShrinkRatio;

    public float ShrinkTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.localScale *= ShrinkRatio;
        StartCoroutine(ShrinkTime(other.gameObject));
    }

    IEnumerator ShrinkTime(GameObject Target)
    {
        yield return new WaitForSeconds(ShrinkTimer);
        Target.transform.localScale /= ShrinkRatio;
    }
}
