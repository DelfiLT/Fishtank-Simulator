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
    public GameObject water;
    public Material cleanWater;
    public Material littleBitDirtyWater;
    public Material dirtyWater;
    public Material veryDirtyWater;
    public Animator sponge;

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
            water.GetComponent<Renderer>().material = cleanWater;
        }
        if (dirt > 2 && dirt < 4)
        {
            water.GetComponent<Renderer>().material = littleBitDirtyWater;
        }
        if (dirt > 4 && dirt < 6)
        {
            water.GetComponent<Renderer>().material = dirtyWater;
        }
        if (dirt > 6 && dirt <= 8)
        {
            maxDirt = true;
            water.GetComponent<Renderer>().material = veryDirtyWater;
        }
    }

    public void CleanFishtank() 
    {
        sponge.SetTrigger("Clean");
        dirt = 0; 
        maxDirt = false;
    }
} 
