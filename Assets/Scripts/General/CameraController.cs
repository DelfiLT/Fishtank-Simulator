using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject sideCam;
    [SerializeField] GameObject topCam;

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
        topCam.SetActive(false);
        sideCam.SetActive(true);
    }

    void TopView()
    {
        sideCam.SetActive(false);
        topCam.SetActive(true);
    }
}
