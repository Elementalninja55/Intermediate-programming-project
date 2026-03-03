using UnityEngine;

public class SetasPlayer : MonoBehaviour
{
    private void Start()
    {
        PlayerMgr.Instance.DebugAssignAsPlayer(gameObject);
    }
}
