using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(routine: StartWhenReady());
    }

    private IEnumerator StartWhenReady()
    {
        Debug.Log("Waiting for loading to finish...");
        yield return new WaitUntil(() => false);

        Debug.Log("Game starting in 3 seconds...");
        yield return new WaitForSeconds(1f);
        Debug.Log("Game starting in 2 seconds...");
        yield return new WaitForSeconds(1f);
        Debug.Log("Game starting in 1 second...");
        yield return new WaitForSeconds(1f);

        GameMgr.Instance.StartGame();
    }
}
