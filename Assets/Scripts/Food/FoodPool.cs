using System.Collections.Generic;
using UnityEngine;

public class FoodPool : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] List<GameObject> pooledFood;

    [SerializeField] int poolSize;

    public static FoodPool Instance { get; private set; }

    private void Awake() 
    {
        Singleton();
        CreatePool(); 
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }

    void CreatePool()
    {
        pooledFood = new List<GameObject>();
        GameObject foodInstance;

        for (int i = 0; i < poolSize; i++)
        {
            foodInstance = Instantiate(foodPrefab);
            foodInstance.SetActive(false);
            pooledFood.Add(foodInstance);
        }
    }

    public GameObject GetPooledFood()
    {
        for (int i = 0; i < poolSize; i++) { if (!pooledFood[i].activeInHierarchy) { return pooledFood[i]; } }
        return null;
    }
}
