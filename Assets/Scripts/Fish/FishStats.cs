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

    public delegate void DeathEvent();
    public static DeathEvent deathEvent;

    private void Awake()
    {
        age = PlayerPrefs.GetFloat("FishAge");
        hpTime = PlayerPrefs.GetFloat("TimeScale") / 10;
        ageTime = PlayerPrefs.GetFloat("TimeScale") / 100;

        flock = GameObject.FindGameObjectWithTag("Flock").GetComponent<Flock>();
    }

    private void FixedUpdate()
    {
        ManageHealth();
        ManageAge();
    }

    public void ManageHealth()
    {
        if (hp <= maxHp && hp >= 0)
        {
            hp -= Time.deltaTime * hpTime + ((hp * 0.01f) / 100) * age;
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

    public void Die()
    {
        deathEvent?.Invoke();
        FlockUnit flockUnit = this.GetComponent<FlockUnit>();
        List<FlockUnit> allUnitsList = new List<FlockUnit>(flock.allUnits);
        allUnitsList.Remove(flockUnit);
        flock.allUnits = allUnitsList.ToArray();
        Destroy(gameObject);
    }

    public void ManageAge()
    {
        if (age <= maxAge)
        {
            age += Time.deltaTime * ageTime;
        }
    }

    public void Eat()
    {
        hp = hp + ((maxHp * 40) / 100);
        xp = xp + ((maxXp * 30) / 100);
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