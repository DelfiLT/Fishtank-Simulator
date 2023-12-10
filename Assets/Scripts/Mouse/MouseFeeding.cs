using System.Collections;
using UnityEngine;

public class MouseFeeding : MouseState
{
    public override void OnClick() => StartCoroutine(SpawnFood());

    IEnumerator SpawnFood()
    {
        for (int i = 0; i < (Random.Range(3, 7)); i++)
        {
            GameObject food = FoodPool.Instance.GetPooledFood();

            float randomX = Random.Range(-1, 1);
            float randomZ = Random.Range(-1, 1);

            if (food != null)
            {
                Vector3 spawnPosition = new Vector3(MousePosition.Instance.worldPosition.x + randomX, MousePosition.Instance.worldPosition.y, MousePosition.Instance.worldPosition.z + randomZ);
                food.transform.position = spawnPosition;
                food.SetActive(true);
            }
            yield return null;
        }
    }
}
