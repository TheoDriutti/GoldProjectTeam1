using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public float EnlargeScale;
    public float DebuffTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.localScale *= EnlargeScale;
        StartCoroutine(DebuffClock(collision.gameObject));
    }

    IEnumerator DebuffClock(GameObject Target)
    {
        yield return new WaitForSeconds(DebuffTime);
        Target.transform.localScale /= EnlargeScale;
    }

}
