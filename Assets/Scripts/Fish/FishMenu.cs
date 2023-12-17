using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMenu : MonoBehaviour
{
    public Sex sex;
    public GameObject male;
    public GameObject female;

    private void Awake()
    {
        sex = (Sex)Random.Range(0, 2);
        if (sex == Sex.Female)
        {
            female.SetActive(true);
            male.SetActive(false);
        }
        else
        {
            female.SetActive(false);
            male.SetActive(true);
        }
    }
}
