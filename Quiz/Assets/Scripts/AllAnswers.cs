using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AllAnswers : MonoBehaviour {

	public int idLevel;
	public Text Question;
	public Text AnswerA;
	public Text AnswerB;
	public Text AnswerC;
	public Text AnswerD;
	public Text infoAnswer;
	public string[] questions;
	public string[] alternativeA;
	public string[] alternativeB;
	public string[] alternativeC;
	public string[] alternativeD;
	public string[] corrects; 
	private int idQuestion; 
	private float points; 
	private float ques; 
	private float correct; 
	private int Finish; 
	public GameSound sd;
	//public Admob ad;

	// Use this for initialization
	void Start () {
		idLevel = PlayerPrefs.GetInt("idLevel");
		Debug.Log(idLevel);
		idQuestion = 0;
		ques = questions.Length;

		Question.text = questions[idQuestion];
		AnswerA.text = alternativeA[idQuestion];
		AnswerB.text = alternativeB[idQuestion];
		AnswerC.text = alternativeC[idQuestion];
		AnswerD.text = alternativeD[idQuestion];
	
		infoAnswer.text = "Correct Answers "+correct.ToString () + " of " + ques.ToString()+ " Questions.";

		DontDestroyOnLoad (this);
		//ad.RequestInterstitial ();
	}
	
	public void Answersall(string alternative){

		if (alternative == "A") 
		{
			if(alternativeA[idQuestion] == corrects[idQuestion])
			{
				correct += 1;
			}
		}

		else if (alternative == "B")
		{
			if(alternativeB[idQuestion] == corrects[idQuestion])
			{
				correct += 1;
			}
		}

		else if (alternative == "C") 
		{
			if(alternativeC[idQuestion] == corrects[idQuestion])
			{
				correct += 1;
			}
		}

		else if (alternative == "D") 
		{
		if(alternativeD[idQuestion] == corrects[idQuestion])
			{
				correct += 1;
			}
		}

		nextQuestion ();
	}

	public void nextQuestion()
	{
		idQuestion += 1;

		if (idQuestion <= (ques- 1)) 
		{
			Question.text = questions [idQuestion];
			AnswerA.text = alternativeA [idQuestion];
			AnswerB.text = alternativeB [idQuestion];
			AnswerC.text = alternativeC [idQuestion];
			AnswerD.text = alternativeD [idQuestion];

			infoAnswer.text = "Correct Answers "+correct.ToString () + " of "+ques.ToString()+ " Questions.";
		}

		else
		{
			points = 100 * (correct / ques);
			Finish = Mathf.RoundToInt(points);

			if (Finish > PlayerPrefs.GetInt ("Finish" + idLevel.ToString ())) 
			{
				PlayerPrefs.SetInt ("Finish"+idLevel.ToString(), Finish);
				PlayerPrefs.SetInt ("correct"+idLevel.ToString(), (int)correct); 
			}


			PlayerPrefs.SetInt ("FinishTemp"+idLevel.ToString(), Finish);
			PlayerPrefs.SetInt ("correctTemp"+idLevel.ToString(), (int)correct); 

			Finishhh ();
		}
			
	}

	public void Finishhh(){
		
		Application.LoadLevel ("Finish");
		//ad.ShowInterstitial ();
	}

}
