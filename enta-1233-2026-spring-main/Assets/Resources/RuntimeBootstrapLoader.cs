using UnityEngine;

/// <summary>
/// Creates the Game Globals object once
/// regardless of where the game is loaded from
/// </summary>

public static class RuntimeBoostrapLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (GlobalsMgr.Instance)
            return;

        var prefab = Resources.Load<GameObject>(path: "GameGlobals");
        Object.Instantiate(prefab);
    }
}
