using System;
using UnityEngine;

/// <summary>
/// A singleton for communicating with the player object when it exists
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr>
{
    [SerializeField] private GameObject _playerPrefab;
    /*
    public override void Awake() {
        base.Awake();
    }*/
    
    /// <summary>
    /// This script should be attached to the player object
    /// Meant for single-player games where accessing the player object quickly is convenient
    /// </summary>
    public GameObject PlayerObject { get; private set; }

    public bool HasSpawnedPlayer => PlayerObject != null;

    public void SpawnPlayer(Vector3 position, Quaternion rotation)
    {
        if (PlayerObject)
        {
            Debug.LogError("Player already spawned!");
            return;
        }

        PlayerObject = Instantiate(_playerPrefab, position, rotation);
        Debug.Log("Player spawned");
    }

    public void Move()
    {
        throw new NotImplementedException("Player does not have a controller");
    }
    
    /// <summary>
    /// Handles the player using the pause input action
    /// TODO move to player input handler separate from player controller
    /// </summary>
    public void PauseInput()
    {
        // Run pause from game manager
        GameMgr.Instance.PauseGameToggle();
    }

    public void DebugAssignAsPlayer(GameObject existingPlayer)
    {
        PlayerObject = existingPlayer;
    }
}