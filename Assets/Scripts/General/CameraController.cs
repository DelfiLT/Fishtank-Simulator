using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera sideCam;
    [SerializeField] CinemachineVirtualCamera topCam;

    private void Awake()
    {
        FoodToggler.onToggleActivated += ChangeCamera;
    }

    private void Start() => SideView();

    void ChangeCamera()
    {
        if (FoodToggler.Instance.foodGrabbed) { TopView(); }
        else { SideView(); }
    }

    void SideView()
    {
        sideCam.Priority = 20;
        topCam.Priority = 10;
    }

    void TopView()
    {
        topCam.Priority = 20;
        sideCam.Priority = 10;
    }
}
