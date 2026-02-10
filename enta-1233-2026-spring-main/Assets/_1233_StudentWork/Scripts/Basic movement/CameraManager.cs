using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    private CinemachineCamera[] cameras;

    public CameraManager(CinemachineCamera[] cameras)
    {
        this.cameras = cameras;
    }

    public CinemachineCamera virtualCameraOne;
    public CinemachineCamera virtualCameraTwo;

    public CinemachineCamera startCamera;
    private CinemachineCamera currentCam;

    private void Start()
    {
        currentCam = startCamera;
        for (int i = 0; i <cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }
    
    public void SwitchCamera(CinemachineCamera newCam)
    {
        currentCam = newCam;

        currentCam.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }
}
