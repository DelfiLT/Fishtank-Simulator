using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI initialFishValue;
    public TextMeshProUGUI deathsValue;
    public TextMeshProUGUI bornsValue;
    public TextMeshProUGUI olderAgeValue;
    public TextMeshProUGUI youngestAgeValue;

    private int deathsCounter;
    private int bornsCounter;

    public static Stats StatsSharedInstance;

    private void Awake()
    {
        StatsSharedInstance = this;
    }

    private void Start()
    {
        initialFishValue.text = PlayerPrefs.GetInt("FishQuantity").ToString();
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
        int allFishes = PlayerPrefs.GetInt("FishQuantity") - deathsCounter + bornsCounter;

        PlayerPrefs.SetInt("FinalFishQuantity", allFishes);
        PlayerPrefs.SetInt("Deaths", deathsCounter);
        PlayerPrefs.SetInt("Borns", bornsCounter);

        //cargar escena final o pausar la simulacion y mostrar estos ultimos valores
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
