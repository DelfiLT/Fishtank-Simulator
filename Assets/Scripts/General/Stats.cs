using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [Header("In Game Stats")]
    public TextMeshProUGUI initialFishValue;
    public TextMeshProUGUI deathsValue;
    public TextMeshProUGUI bornsValue;
    public TextMeshProUGUI olderAgeValue;
    public TextMeshProUGUI youngestAgeValue;

    [Header("Final Stats")]
    public TextMeshProUGUI finalInitialFishes;
    public TextMeshProUGUI finalFishes;
    public TextMeshProUGUI finalDeaths;
    public TextMeshProUGUI finalBorns;
    public TextMeshProUGUI finalOlderAge;
    public TextMeshProUGUI finalYoungestAge;
    public Button endSimulationButton;
    public GameObject finalStatsWindow;

    private int deathsCounter;
    private int bornsCounter;
    public GameObject[] fishes;

    private void Start()
    {
        initialFishValue.text = PlayerPrefs.GetInt("FishQuantity").ToString();

        endSimulationButton.onClick.AddListener(() =>
        {
            OnSimulationEnded();
        });
    }

    void DeathCounter()
    {
        deathsCounter++;
        deathsValue.text = deathsCounter.ToString();
    }

    void BornCounter()
    {
        bornsCounter++;
        bornsValue.text = bornsCounter.ToString();
    }

    public void OnSimulationEnded()
    {
        fishes = GameObject.FindGameObjectsWithTag("Fish");

        foreach (GameObject fish in fishes) 
        { 
            fish.GetComponent<FishStats>().enabled = false;
            fish.GetComponent<FishReproduction>().enabled = false;
        }

        int allFishes = fishes.Length;

        finalStatsWindow.SetActive(true);

        finalInitialFishes.text = "Initial Fishes " + PlayerPrefs.GetInt("FishQuantity").ToString();
        finalFishes.text = "Final Fishes " + allFishes.ToString();
        finalDeaths.text = "Death Fishes " + deathsCounter.ToString();
        finalBorns.text = "Born Fishes " + bornsCounter.ToString();
    }


    private void OnEnable()
    {
        FishStats.deathEvent += DeathCounter;
        FishReproduction.bornEvent += BornCounter;
    }

    private void OnDisable()
    {
        FishStats.deathEvent -= DeathCounter;
        FishReproduction.bornEvent -= BornCounter;
    }
}
