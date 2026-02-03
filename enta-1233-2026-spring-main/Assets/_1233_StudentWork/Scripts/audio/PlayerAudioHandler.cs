using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepSource;

    [SerializeField] private AudioSource _jumpSource;

    public void PlayFootstep()
    {
        _footstepSource?.Play();
    }

    public void PlayJump()
    {
        _jumpSource?.Play();
    }

}
