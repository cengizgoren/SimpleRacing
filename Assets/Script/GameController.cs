using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	internal static bool isGameOver;
	private GameObject _GameOverText;
	private GameObject _FadeScreen;
	private Animator _fadeAnim;
	private bool _readyToGetOut;
	private void Awake()
	{
		_GameOverText = GameObject.FindGameObjectWithTag(MyTag.GameOverText.ToString());
		_FadeScreen = GameObject.FindGameObjectWithTag(MyTag.FadeIn.ToString());
		_fadeAnim = _FadeScreen.GetComponent<Animator>();
	}

	private void Start()
	{
		isGameOver = false;
		_GameOverText.SetActive(false);
	}

	void Update () {
		if (isGameOver)
		{
			CarDriveForwardBehaviour.isDrive = false;
			_GameOverText.SetActive(true);
			_fadeAnim.SetTrigger("FadeIn");
			StartCoroutine(SlowDownGoToMenu());
			if(Input.anyKey && _readyToGetOut) SceneManager.LoadScene("Menu");
			Reset();
		}
	}

	private void Reset()
	{
		Trap.firstPositionAfterStart = 150;
		Tree.firstPositionAfterStart = 0;
		Road.firstPositionAfterStart = 0;
		Coin.firstPositionAfterStart = -400;
	}

	IEnumerator SlowDownGoToMenu()
	{
		yield return new WaitForSeconds(1);
		_readyToGetOut = true;
	}
}
