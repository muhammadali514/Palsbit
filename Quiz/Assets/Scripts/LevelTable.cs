using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTable : MonoBehaviour {

	public Button Play;
	public Text txtselectLevel;
	public GameObject infoLevel;
	public Text txtinfoLevel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public string[] Level;
	public int numberQuestions;
	private int idLevel;

	// Use this for initialization
	void Start () {
		
		idLevel = 0;
		txtselectLevel.text = Level[idLevel] ;
		txtinfoLevel.text = "Correct answers X of X questions";
		infoLevel.SetActive (false);
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		Play.interactable = false;
	}


	public void SelectLevel(int i){
		
		idLevel = i;
		PlayerPrefs.SetInt ("idLevel", idLevel);
		txtselectLevel.text = Level[idLevel];

		int Finish = PlayerPrefs.GetInt ("FinishTemp"+idLevel.ToString ());
		int corrects = PlayerPrefs.GetInt ("correctTemp"+idLevel.ToString ());

		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);


		if (Finish == 100) {
			
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);

		}

		else if (Finish >= 70) {
			
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);

		}

		else if (Finish >= 50) {
				
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
		}


		txtinfoLevel.text = "Correct answers "+corrects.ToString()+" of "+numberQuestions.ToString()+" questions";
		infoLevel.SetActive (true);
		Play.interactable = true;
	}

	public void Levels(){
		
		Application.LoadLevel ("L"+idLevel.ToString());
	}
}
