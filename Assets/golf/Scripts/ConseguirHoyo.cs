using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Michael Soler Beatty [MAT]

public class ConseguirHoyo : MonoBehaviour {

	// Use this for initialization
	public InputField txtInput;
	public int ecuacion;
	public Text txtResult;
	public Vector3 objective;
	public Transform Tball;
	public int golpes;
	public float min=1,max=2;
	public float value, image;
	public Canvas end;
	public Text txtGolpes,txtTiempo,txtNumerador ,txtDenominador,  txtHoyo, txtMin,txtMax;
	float elapsed;
	public int a,b,c,d;
	public int par=3;
	public int score=0;
	public Text txtIntentos;
	public float center;
	public float amplitud=0.5f;
	public Button buttonPlay;
	Rigidbody rb;


	void Start ()
	{

		Physics.gravity = new Vector3 (0, -50f, 0);
		elapsed = 0;
		golpes = 0;
		a = 0;
		b = 0;
		c = 0;
		d = 0;
		txtIntentos.text = "";

		if (ecuacion == 0) {
			while (a == 0 || b == 0) {
				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);
			}

			center = Random.Range (-9, 9);
			while (center - b == 0) {
				center = Random.Range (-9, 9);
			}
			max = center + amplitud;
			min = center - amplitud;

			if (b > 0) {
				txtDenominador.text = "" + a + "X+" + b;
			} else {
				txtDenominador.text = "" + a + "X" + b;
			}


			Debug.Log ((1/center-b)/a);

		} else if (ecuacion == 1) 
		{
			center = Random.Range (-9, 9);
			while (center == 0) {
				center = Random.Range (-9, 9);
			}
			max = center + amplitud;
			min = center - amplitud;

			while (a *center <= 0 ){
				a = Random.Range (-9, 9);
				txtDenominador.text = "" + a + "X^2";
			}

			Debug.Log (Mathf.Pow(1/center/a,0.5f));


		} else if (ecuacion == 2) 
		{
			center = Random.Range (-9, 9);
			while (center == 0) {
				center = Random.Range (-9, 9);
			}
			max = center + amplitud;
			min = center - amplitud;

			while (a == 0 || (1/center/a)<=0 || b==0){
				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);
				txtNumerador.text = "" + b;
				txtDenominador.text = "" + a + "X";
			}

			Debug.Log (b/center/a);

		}
		else if (ecuacion == 3) 
		{
			center = Random.Range (-9, 9);
			max = center + amplitud;
			min = center - amplitud;

			while (a == 0 || b==0){
				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);

				if (b > 0) {
					txtDenominador.text = "" + a + "X+" + b;
				} else {
					txtDenominador.text = "" + a + "X" + b;
				}
			}

			Debug.Log ((center-b)/a);

		}
		else if (ecuacion == 4) 
		{
			
			while (a == 0 || a*center<=0){

				center = Random.Range (-9, 9);
				max = center + amplitud;
				min = center - amplitud;

				a = Random.Range (-9, 9);

			
				txtDenominador.text = "" + a + "X^2";

			}

			Debug.Log (Mathf.Pow(center/a,0.5f));

		}
		else if (ecuacion == 5) 
		{

			while (a == 0 || b==0 || (center-b)/a<=0){

				center = Random.Range (-9, 9);
				max = center + amplitud;
				min = center - amplitud;

				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);


				if (b > 0) {
					txtDenominador.text = "" + a + "X^2+" + b;
				} else {
					txtDenominador.text = "" + a + "X^2" + b;
				}

			}

			Debug.Log (Mathf.Pow((center-b)/a,0.5f));

		}
		else if (ecuacion == 6) 
		{

			while (a == 0 || b==0 || c==0|| (Mathf.Pow(b,2)-4*a*(c-center))<=0){

				center = Random.Range (-9, 9);
				max = center + amplitud;
				min = center - amplitud;

				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);
				c = Random.Range (-9, 9);

				if (b > 0) {
					txtDenominador.text = "" + a + "X^2+" + b+"X";
				} else {
					txtDenominador.text = "" + a + "X^2" + b+"X";
				}
				if (c > 0) {
					txtDenominador.text += "+"+c;
				} else {
					txtDenominador.text += ""+ c;
				}

			}

			Debug.Log ((-b+Mathf.Pow(Mathf.Pow(b,2)-4*a*(c-center),0.5f))/(2*a));

		}
		else if (ecuacion == 7) 
		{

			while (a == 0 || b==0|| (Mathf.Pow(b,2)-4*a*(-center))<=0 ){

				center = Random.Range (-9, 9);
				max = center + amplitud;
				min = center - amplitud;

				a = Random.Range (-9, 9);
				b = Random.Range (-9, 9);
	
				if (b > 0) {
					txtDenominador.text = "" + a + "X^2+" + b+"X";
				} else {
					txtDenominador.text = "" + a + "X^2" + b+"X";
				}


			}

			Debug.Log ((-b+Mathf.Pow(Mathf.Pow(b,2)-4*a*(-center),0.5f))/(2*a));

		}
		else if (ecuacion == 8) 
		{
				while (a == 0 ){

				center = Random.Range (1, 9);
				max = center + amplitud;
				min = center - amplitud;

				a = Random.Range (-3, 3);
	
				txtDenominador.text = "e^( " + a +"X)";
			
			}

			Debug.Log (Mathf.Log(center)/a);

		}

		txtMax.text=""+(Mathf.Round(max*100)/100);
		txtMin.text=""+(Mathf.Round(min*100)/100);


		//Tball.position = new Vector3 (-6.06f,-0.74f,-0.62f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		elapsed += Time.fixedDeltaTime;
	}

	public void calculate ()
	{
		value = float.Parse (txtInput.text);
		image = 0;
		float a1 = (2.5f - 0.6f) / (max - min);
		float b1 = 2.5f - a1 * max;

		if (ecuacion == 0) {

			if (Mathf.Abs (a * value + b) > 1e-8) {
				image = 1 / (a * value + b);
				txtResult.text = "" + (Mathf.Round (100 * image) / 100);
				objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

				if (image * a1 + b1<-7.9f) {
					objective = new Vector3 (-7.9f, -0.74f, -0.62f);
				}
				if (image * a1 + b1>7.9f) {
					objective = new Vector3 (7.9f, -0.74f, -0.62f);
				}




				golpes += 1;

				rb = Tball.GetComponent<Rigidbody> ();
				rb.velocity = new Vector3 (0, 50f, 0);

				StartCoroutine (moveBall());


			} else {
				txtResult.text = "error";
			}
		}

		else if (ecuacion == 1) {

			if (Mathf.Abs (a * Mathf.Pow(value,2)) > 1e-8) {
				image = 1 / (a *Mathf.Pow(value,2));
				txtResult.text = "" + (Mathf.Round (100 * image) / 100);
				objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

				if (image * a1 + b1<-7.9f) {
					objective = new Vector3 (-7.9f, -0.74f, -0.62f);
				}
				if (image * a1 + b1>7.9f) {
					objective = new Vector3 (7.9f, -0.74f, -0.62f);
				}
					
				golpes += 1;
				rb = Tball.GetComponent<Rigidbody> ();
				rb.velocity = new Vector3 (0, 50f, 0);
				StartCoroutine (moveBall());


			} else {
				txtResult.text = "error";
			}
		}
		else if (ecuacion == 2) {

			if (Mathf.Abs (a * value) > 1e-8) {
				image = b / (a *value);
				txtResult.text = "" + (Mathf.Round (100 * image) / 100);
				objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

				if (image * a1 + b1<-7.9f) {
					objective = new Vector3 (-7.9f, -0.74f, -0.62f);
				}
				if (image * a1 + b1>7.9f) {
					objective = new Vector3 (7.9f, -0.74f, -0.62f);
				}

				golpes += 1;
				rb = Tball.GetComponent<Rigidbody> ();
				rb.velocity = new Vector3 (0, 50f, 0);
				StartCoroutine (moveBall());


			} else {
				txtResult.text = "error";
			}
		}
		else if (ecuacion == 3) {


			image = a *value+b;
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}
		else if (ecuacion == 4) {


			image = a *Mathf.Pow(value,2);
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}

		else if (ecuacion == 5) {


			image = a *Mathf.Pow(value,2)+b;
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}

		else if (ecuacion == 6) {


			image = a *Mathf.Pow(value,2)+b*value+c;
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}

		else if (ecuacion == 7) {


			image = a *Mathf.Pow(value,2)+b*value;
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}

		else if (ecuacion == 8) {


			image = Mathf.Exp(a*value);
			txtResult.text = "" + (Mathf.Round (100 * image) / 100);
			objective = new Vector3 (image * a1 + b1, -0.74f, -0.62f);

			if (image * a1 + b1<-7.9f) {
				objective = new Vector3 (-7.9f, -0.74f, -0.62f);
			}
			if (image * a1 + b1>7.9f) {
				objective = new Vector3 (7.9f, -0.74f, -0.62f);
			}

			golpes += 1;
			rb = Tball.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, 50f, 0);
			StartCoroutine (moveBall());
		}

	}


	IEnumerator moveBall ()
	{

	
		while ((Tball.position - objective).magnitude > 0.1f) {

			float distance = (Tball.position - objective).magnitude;

			rb.MovePosition( Vector3.Lerp (Tball.position, objective, 0.2f));

			yield return new WaitForSeconds (0.01f);
		}

		txtIntentos.text+=""+golpes+ " x="+value+ " Im="+(Mathf.Round(image*100)/100)+"\n";

		if (image >= min && image <= max) {
			
			score+=(golpes-par);
			txtGolpes.text = "" +score; 

			buttonPlay.interactable = false;

			float minutes = Mathf.Floor (elapsed / 60);
			float seconds = Mathf.Round (elapsed % 60);

			string timeS;

			timeS = "";
			if (minutes < 10) {
				timeS += "0" + minutes;
			} else {	
				timeS += minutes;
			}

			if (seconds < 10) {
				timeS += " : 0" + seconds;
			} else {	
				timeS += " : " + seconds;
			}

			if (golpes - par == -3) {
				txtHoyo.text = "Albatros";
			} else if (golpes - par == -2) {
				txtHoyo.text = "Eagle";
			}else if (golpes - par == -1) {
				txtHoyo.text = "Birdie";
			}else if (golpes - par == 0) {
				txtHoyo.text = "Par";
			}else if (golpes - par == 1) {
				txtHoyo.text = "Bogey";
			}
			else if (golpes - par == 2) {
				txtHoyo.text = "Double Bogey";
			}
			else if (golpes - par == 3) {
				txtHoyo.text = "Triple Bogey";
			}
			else {
				txtHoyo.text = "En "+golpes;
			}

			rb.useGravity = false;
			rb.GetComponent<Collider> ().enabled = false;
			objective = objective - new Vector3 (0, 1.5f, 0);

			while ((Tball.position - objective).magnitude > 0.15f) {
				Tball.position = Vector3.Lerp (Tball.position, objective, 0.1f);

				yield return new WaitForSeconds (0.01f);
			}
			yield return new WaitForSeconds (1.5f);
			txtTiempo.text = timeS;
			end.enabled = true;
		}

		Debug.Log ("end");
	}


}
