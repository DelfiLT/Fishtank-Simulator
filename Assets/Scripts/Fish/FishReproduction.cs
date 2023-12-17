using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private FlockUnit flockUnitPrefab;

    public FlockUnit unit { get; set; }
    private FishStats fishStats;
    private Flock flock;

    public delegate void BornEvent();
    public static BornEvent bornEvent;

    private void Start()
    {
        sex = (Sex)Random.Range(0, 2);
        if(sex == Sex.Female)
        {
            //textura hembra
        } else
        {
            //textura macho
        }

        fishStats = gameObject.GetComponentInParent<FishStats>();
        flock = GameObject.FindGameObjectWithTag("Flock").GetComponent<Flock>();
        flockUnitPrefab = flock.flockUnitPrefab;
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

    private void NewUnit()
    {
        //particula nacimiento
        bornEvent?.Invoke();
        FlockUnit unit = Instantiate(flockUnitPrefab, transform.position, Quaternion.identity);
        flock.AddUnit(unit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish") && canReproduce)
        {
            canReproduce = false;
            Sex collisionSex = other.gameObject.GetComponent<FishReproduction>().sex;

            if (collisionSex != sex)
            {
                if(PlayerPrefs.GetInt("ActualFishQuantity") < 50)
                {
                    NewUnit();
                }
                fishStats.xp = 0;
            }
        }
    }
}