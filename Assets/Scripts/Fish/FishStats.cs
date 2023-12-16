using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class FishStats : MonoBehaviour
{
    [Header("Fish HP")]
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float hpTime;

    [Header("Fish XP")]
    [SerializeField] public float xp;
    [SerializeField] public float maxXp;

    [Header("Fish AGE")]
    [SerializeField] private float age;
    [SerializeField] private float maxAge;
    [SerializeField] private float ageTime;

    private Flock flock;
    private Cleaning cleaning;

    public delegate void DeathEvent();
    public static DeathEvent deathEvent;

    public delegate void OlderAgeEvent();
    public static OlderAgeEvent olderAgeEvent;

    public delegate void YoungestAgeEvent();
    public static YoungestAgeEvent youngestAgeEvent;

    private void Awake()
    {
        youngestAgeEvent?.Invoke();

        age = PlayerPrefs.GetFloat("FishAge");
        hpTime = PlayerPrefs.GetFloat("TimeScale") / 10;
        ageTime = PlayerPrefs.GetFloat("TimeScale") / 100;

        flock = GameObject.FindGameObjectWithTag("Flock").GetComponent<Flock>();
        cleaning = GameObject.FindGameObjectWithTag("Cleaning").GetComponent<Cleaning>();
    }

    private void FixedUpdate()
    {
        ManageHealth();
        ManageAge();
    }

    public void ManageHealth()
    {
        if (hp <= maxHp && hp >= 0 && !cleaning.maxDirt)
        {
            hp -= Time.deltaTime * hpTime + ((hp * 0.01f) / 100) * age;
        } 
        else
        {
            hp -= Time.deltaTime * hpTime * 1.5f + ((hp * 0.01f) / 100) * age;
        }

        if(hp > maxHp)
        {
            hp = maxHp;
        }

        if (hp <= 0)
        {
            hp = 0;
            if (hp == 0)
            {
                Die();
            }
        }
    }

    public void ManageAge()
    {
        if (age <= maxAge)
        {
            age += Time.deltaTime * ageTime;

            if(age > PlayerPrefs.GetFloat("AgeRecord")) 
            {
                olderAgeEvent?.Invoke();
                PlayerPrefs.SetFloat("AgeRecord", age);
            }

            GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
            foreach (GameObject fish in fishes)
            {
                float fishAge = fish.GetComponent<FishStats>().age;
                if (age < fishAge)
                {
                    youngestAgeEvent?.Invoke();
                    PlayerPrefs.SetFloat("YoungestAge", age);
                }
            }
        }

        if(age <= 5)
        {
            //tamaño chiquito
        }
        if(age > 5 && age <= 10)
        {
            //tamaño mediano
        }
        if(age > 10 && age <= 15)
        {
            //tamaño grande
        }
    }

    public void Eat()
    {
        hp = hp + ((maxHp * 40) / 100);
        xp = xp + ((maxXp * 30) / 100);
    }

    public void Die()
    {
        //animacion de muerte
        deathEvent?.Invoke();
        FlockUnit flockUnit = this.GetComponent<FlockUnit>();
        List<FlockUnit> allUnitsList = new List<FlockUnit>(flock.allUnits);
        allUnitsList.Remove(flockUnit);
        flock.allUnits = allUnitsList.ToArray();
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Eat();
            collision.gameObject.SetActive(false);
        }
    }
}