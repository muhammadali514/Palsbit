using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finishpoints : MonoBehaviour {

	private int idLevel;
	public Text infoStar;
	public Text infoLevel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	private int Finnish;
	private int correct;

	public FinishSound sd;
	public GameSound gm;

	// Use this for initialization
	void Start () {

		idLevel = PlayerPrefs.GetInt("idLevel");
		Debug.Log(idLevel);

		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);


		Finnish = PlayerPrefs.GetInt("FinishTemp"+idLevel.ToString());
		correct = PlayerPrefs.GetInt("correctTemp");

		infoStar.text = Finnish.ToString();
		infoLevel.text = "Correct answers " + correct.ToString () + " of 10 Questions";

		if (correct == 10) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);


		}

		else if (Finnish >= 5) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);


		}

		else if (Finnish >= 1) 
		{
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);


		}
	
	}
	public void Replay()
	{
		Application.LoadLevel ("L" + idLevel.ToString ());
		sd.FiniSound.Stop ();
	}


	public void Menu(){
		Application.LoadLevel("Menu");
		sd.FiniSound.Stop ();
	}

	public void Level(){
		Application.LoadLevel("LevelTable");
		sd.FiniSound.Stop ();
	}
}
