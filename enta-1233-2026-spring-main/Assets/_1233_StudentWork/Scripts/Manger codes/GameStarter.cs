using System.Collections;
using UnityEngine;

private IEnumerator StartWhenReady()
{
    Debug.Log("GameStarter: Requesting level load");
    LevelMgr.Instance.LoadCurrentlevel();

    Debug.Log("GameStarter: waiting for level to finish loading...");
    yield return new WaitUntil(() => LevelMgr.Instance.IsLevelLoaded);

    Debug.Log("GameStarter: Spawning player");
    PlayerSpawnPoint spawnPoint = PlayerSpawnPoint.Instance;
    if (spawnPoint == null)
        Debug.LogError("GameStarter: No spawn point found!");
    else
        PlayerMgr.Instance.SpawnPlayer(
            spawnPoint.transform.position,
            spawnPoint.transform.rotation);

    Debug.Log("GameStarter: Waiting for player spawn...");

    Debug.Log("Game starting in 3 seconds...");
    yield return new WaitForSeconds(1f);
}
