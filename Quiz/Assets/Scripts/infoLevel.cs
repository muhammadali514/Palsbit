using UnityEngine;
using System.Collections;

public class infoLevel : MonoBehaviour {

	public int idLevel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	private int Finish;

	// Use this for initialization
	void Start () {


		int Finish = PlayerPrefs.GetInt ("FinishTemp"+idLevel.ToString());

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

		else if (Finish >= 40) {
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
		}
	}

	void Update(){
	
	}
}
