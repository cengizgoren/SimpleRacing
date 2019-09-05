using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;
using Unity;

public class ModelOfCar : MonoBehaviour
{
    public static GameObject ActualCar { get; set; }
    [Serializable]
    public class Car
    {
        public GameObject prefab;
        public int price;
        public bool isBought;
    }

    public Car[] cars;
    
    #region Singleton

    public static ModelOfCar instance;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    #endregion

    private void Start()
    {
        if (ActualCar == null)
        {
            ActualCar = cars[0].prefab;
        }
    }

    public void ActivateModel(int numberOfModel)
    {
        if (CountCoins.CoinAmount >= cars[numberOfModel].price || cars[numberOfModel].isBought)
        {
            ActualCar = cars[numberOfModel].prefab;
            if (!cars[numberOfModel].isBought)
            {
                CountCoins.CoinAmount -= cars[numberOfModel].price;
                cars[numberOfModel].isBought = true;
            }
        }
    }
    
    
}
