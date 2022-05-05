using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	// Use this for initialization

	public int score;
	public int[] order;
	public GameObject[] gameObjects;
	public Text txtHoyo, txtPuntos;
	public int indx=0;
	public Canvas endCanvas;
	public Text[] pointsHole;
	public Text solButon;

	void Start () {

		RandomizeArray (order);

		//gameObjects[order[indx]].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () 
	{
		txtPuntos.text = "" + score;
	}

	public void addScore(int a)
	{
		score += a;
	}

	public void nextHole(ConseguirHoyo ch)
	{
		if (indx < 8) {
			gameObjects [order [indx]].SetActive (false);

			int result = (ch.golpes - ch.par);

			pointsHole [indx].text = ""+result;

			indx += 1;
			score += result;

			gameObjects [order [indx]].SetActive (true);
		} else {
			int result = (ch.golpes - ch.par);
			pointsHole [indx].text = ""+result;
			gameObjects [order [indx]].SetActive (false);
			endCanvas.enabled = true;
		}
		solButon.text=""+score;

		txtHoyo.text = "Hoyo " + (indx+1) + "/9";
	}

	public void RandomizeArray(int[] arr)
	{
		for (var i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range(0,i);
			int tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}


	}

	public void startGame()
	{
		gameObjects[order[indx]].SetActive(true);
		txtHoyo.text = "Hoyo " + (indx+1) + "/9";
	}

	public void restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	//salir

	public void quitApp ()
	{
		Application.Quit();
	}
}
