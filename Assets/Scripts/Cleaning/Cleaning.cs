using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleaning : MonoBehaviour
{
    [SerializeField] private float dirt;
    [SerializeField] private float dirtTime;
    public Button cleanButton;
    public bool maxDirt;

    void Awake()
    {
        if (PlayerPrefs.GetInt("CleaningToggle") == 0)
        {
            this.enabled = false;
        }
    }

    void Start()
    {
        dirt = 0;
        dirtTime = PlayerPrefs.GetFloat("TimeScale") / 10;

        cleanButton.onClick.AddListener(() =>
        {
            CleanFishtank();
        });
    }

    private void Update()
    {
        ManageDirt();
    }

    public void ManageDirt()
    {
        if (dirt <= 8)
        {
            dirt += Time.deltaTime * dirtTime;
        }

        if (dirt < 2)
        {
            //pecera limpia
        }
        if (dirt > 2 && dirt < 4)
        {
            //pecera un poco sucia
        }
        if (dirt > 4 && dirt < 6)
        {
            //pecera muy sucia
        }
        if (dirt > 6 && dirt <= 8)
        {
            maxDirt = true;
            //pecera muy sucia
        }
    }

    public void CleanFishtank() 
    { 
        //animacion de limpiar
        dirt = 0; 
        maxDirt = false;
    }
}
