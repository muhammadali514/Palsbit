using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour {

//	public Admob ad;
	public MenuSound sd;
	public GameSound sound;

	void Start(){
		DontDestroyOnLoad (this);
		//ad.RequestBanner ();
		//ad.RequestInterstitial ();
		//ad.bannerView.Show();
	}

	public void LoadLevel(string Levels)
	{
		//Application.LoadLevel (Levels);
		SceneManager.LoadScene(2);
		sound.GamSound.Stop ();
	}

	public void clearAll()
	{
		//PlayerPrefs.DeleteAll ();
	}

	public void Play(){
		//Application.LoadLevel ("LevelTable");
		sd.MenuSd.Stop ();
	}

	public void gotovategory()
	{
		SceneManager.LoadScene(2);
	}
		

}
