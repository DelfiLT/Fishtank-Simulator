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

        if (hp <= 0)
        {
            hp = 0;
            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
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
        hp = hp + ((maxHp * 20) / 100);
        //xp = xp + ((maxXp * 20) / 100);
        xp = maxXp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Eat();
            Destroy(collision.gameObject);
        }
    }
}