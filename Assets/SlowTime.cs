using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float SlowStrenght;
    public float SlowDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Time.timeScale = SlowStrenght;
            StartCoroutine(SlowTimer());
        }
    }

    IEnumerator SlowTimer()
    {
        yield return new WaitForSecondsRealtime(SlowDuration);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
