using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [SerializeField] float slowDuration =  3f;
    [SerializeField] float slowScale = 0.5f;

    IEnumerator Start()
    {
        FindObjectOfType<GameStatus>().SetGameSpeed(slowScale);
        yield return new WaitForSecondsRealtime(slowDuration);
        FindObjectOfType<GameStatus>().SetGameSpeed(1);
        Destroy(gameObject);
    }
   
}
