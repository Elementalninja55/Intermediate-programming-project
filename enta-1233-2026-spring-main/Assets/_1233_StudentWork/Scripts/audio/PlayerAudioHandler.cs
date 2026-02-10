using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepSource;

    [SerializeField] private AudioSource _jumpSource;

    [SerializeField] private AudioSource _landSource;

    public void PlayFootstep()
    {
        _footstepSource?.Play();
    }

    public void PlayJump()
    {
        _jumpSource?.Play();
    }

    public void PlayLand()
    {
        _landSource?.Play();
    }

}
