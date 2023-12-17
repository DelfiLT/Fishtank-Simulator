using UnityEngine;

public class FoodBoxManager : MonoBehaviour
{
    [SerializeField] GameObject foodBox;

    private void Awake() => FoodToggler.onToggleActivated += Enable;

    void Enable() => foodBox.SetActive(true);

    private void FixedUpdate()
    {
        foodBox.transform.position = new Vector3(MousePosition.Instance.worldPosition.x, 4.3f, MousePosition.Instance.worldPosition.z);
    }
}
