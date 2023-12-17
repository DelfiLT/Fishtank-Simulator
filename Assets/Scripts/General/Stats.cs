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
    public TextMeshProUGUI actualFishesValue;

    [Header("Final Stats")]
    public TextMeshProUGUI finalInitialFishes;
    public TextMeshProUGUI finalFishes;
    public TextMeshProUGUI finalDeaths;
    public TextMeshProUGUI finalBorns;
    public TextMeshProUGUI finalOldestAge;
    public TextMeshProUGUI finalYoungestAge;

    [Header("Stats Config")]
    public Button endSimulationButton;
    public GameObject finalStatsWindow;

    private int deathsCounter;
    private int bornsCounter;
    private GameObject[] fishes;

    private void Start()
    {
        initialFishValue.text = PlayerPrefs.GetInt("FishQuantity").ToString();

        endSimulationButton.onClick.AddListener(() =>
        {
            OnSimulationEnded();
        });
    }

    private void Update()
    {
        PlayerPrefs.SetInt("ActualFishQuantity", PlayerPrefs.GetInt("FishQuantity") - deathsCounter + bornsCounter);
        actualFishesValue.text = (PlayerPrefs.GetInt("FishQuantity") - deathsCounter + bornsCounter).ToString();
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

    void OldestAgeRecord()
    {
        olderAgeValue.text = PlayerPrefs.GetFloat("AgeRecord").ToString("0");
    }

    void YoungestAge()
    {
        youngestAgeValue.text = PlayerPrefs.GetFloat("YoungestAge").ToString("0");
    }

    public void OnSimulationEnded()
    {
        fishes = GameObject.FindGameObjectsWithTag("Fish");

        foreach (GameObject fish in fishes) 
        { 
            fish.GetComponent<FishStats>().enabled = false;
            fish.GetComponentInChildren<FishReproduction>().enabled = false;
        }

        int allFishes = fishes.Length;

        finalStatsWindow.SetActive(true);

        finalInitialFishes.text = "Initial Fishes " + PlayerPrefs.GetInt("FishQuantity").ToString();
        finalDeaths.text = "Death Fishes " + deathsCounter.ToString();
        finalBorns.text = "Born Fishes " + bornsCounter.ToString();
        finalOldestAge.text = "Oldest Age " + PlayerPrefs.GetFloat("AgeRecord").ToString("0");
        finalYoungestAge.text = "Youngest Age " + PlayerPrefs.GetFloat("YoungestAge").ToString("0");
        finalFishes.text = "Final Fishes " + allFishes.ToString();
    }


    private void OnEnable()
    {
        FishStats.deathEvent += DeathCounter;
        FishReproduction.bornEvent += BornCounter;
        FishStats.olderAgeEvent += OldestAgeRecord;
        FishStats.youngestAgeEvent += YoungestAge;
    }

    private void OnDisable()
    {
        FishStats.deathEvent -= DeathCounter;
        FishReproduction.bornEvent -= BornCounter;
        FishStats.olderAgeEvent -= OldestAgeRecord;
        FishStats.youngestAgeEvent -= YoungestAge;
    }
}
