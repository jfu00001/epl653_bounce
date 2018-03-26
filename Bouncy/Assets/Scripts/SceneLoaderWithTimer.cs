using UnityEngine;
using System.Collections;

public class SceneLoaderWithTimer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel(1);
    }
}