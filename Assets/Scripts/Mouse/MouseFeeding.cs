using System.Collections;
using UnityEngine;

public class MouseFeeding : MouseState
{
    public override void ClickAction()
    {
        StartCoroutine(SpawnFood());
    }
    IEnumerator SpawnFood()
    {
        for (int i = 0; i < (Random.Range(3, 7)); i++)
        {
            GameObject food = FoodPool.Instance.GetPooledFood();

            float randomX = Random.Range(0, 3);
            float randomY = Random.Range(0, 3);

            if (food != null)
            {
                Vector3 spawnPosition = new Vector3(MousePosition.Instance.worldPosition.x + randomX, MousePosition.Instance.worldPosition.y + randomY, MousePosition.Instance.worldPosition.z);
                food.transform.position = spawnPosition;
                food.SetActive(true);
            }
            yield return null;
        }
    }
}
