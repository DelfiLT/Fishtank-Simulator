using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sex
{
    Female,
    Male,
}

public class FishReproduction : MonoBehaviour
{
    [Header("Fish Reproduction")]
    public Sex sex;
    [SerializeField] private bool canReproduce = false;

    private FishStats fishStats;

    private void Start()
    {
        sex = (Sex)Random.Range(0, 2);
        fishStats = gameObject.GetComponentInParent<FishStats>();
    }

    private void FixedUpdate()
    {
        ManageXP();
    }

    public void ManageXP()
    {
        if (fishStats.xp >= fishStats.maxXp)
        {
            fishStats.xp = fishStats.maxXp;
            canReproduce = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish") && canReproduce)
        {
            Sex collisionSex = other.gameObject.GetComponent<FishReproduction>().sex;

            if (collisionSex != sex)
            {
                Debug.Log("Tener hijo");
                canReproduce = false;
                fishStats.xp = 0;
            }
        }
    }
}