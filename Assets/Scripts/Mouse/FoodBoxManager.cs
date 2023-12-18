using UnityEngine;

public class FoodBoxManager : MonoBehaviour
{
    [SerializeField] GameObject foodBox;

    private void Awake() => FoodToggler.onToggleActivated += Toggle;

    private void OnDisable()
    {
        FoodToggler.onToggleActivated -= Toggle;
    }

    void Toggle()
    {

        if (FoodToggler.Instance.foodGrabbed)
        {
            foodBox.SetActive(true);
        }
        else
        {
            foodBox.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        foodBox.transform.position = new Vector3(MousePosition.Instance.worldPosition.x, 4.3f, MousePosition.Instance.worldPosition.z);
    }
}
