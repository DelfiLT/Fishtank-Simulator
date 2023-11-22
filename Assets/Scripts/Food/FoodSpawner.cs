using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] FoodToggler toggler;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && toggler.feeding)
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        GameObject food = FoodPool.Instance.GetPooledFood();

        if(food != null)
        {
            food.transform.position = MousePosition.Instance.worldPosition;
            food.SetActive(true);
        }
    }
}
