using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CountCoins : MonoBehaviour
{
	private TextMeshProUGUI CountDisplay;
	internal static int CoinAmount = 0;
	private void Awake()
	{
		CountDisplay = GetComponent<TextMeshProUGUI>();
		
	}

	private void Update()
	{
		CountDisplay.text = CoinAmount.ToString();
	}
	
}
