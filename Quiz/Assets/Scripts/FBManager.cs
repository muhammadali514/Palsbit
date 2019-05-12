using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using Facebook.MiniJSON;

public class FBManager : MonoBehaviour {
 public string get_data;
 public string fbname;
	public Text txtStatus;
	public GameObject btnLi, btnLo;
	//public GameObject ProfilePicture;
	public GameObject ProfilePicture;

    public GameObject maincanvas;
    public GameObject fblogin;
    public GameObject signupcanvas;
    

	void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init(InitCallback, OnHideUnity);
		} else {
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
            Debug.Log("check 1");
			FB.ActivateApp ();
		} else {
			txtStatus.text = "Failed to Initialize the Facebook SDK";
		}

		if (FB.IsLoggedIn) {
            Debug.Log("check 2");
            
			FB.API ("/me?fields=name", HttpMethod.GET, DispName);
			Debug.Log("looged in check");
            
            FB.API ("/me/picture?redirect=false", HttpMethod.GET, GetPicture);
            
            //FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPicture);//FB.API("me/picture?type=med", Facebook.HttpMethod.GET, GetPicture);
			btnLi.SetActive (false); btnLo.SetActive (true);
		} else {
			txtStatus.text = "Please login to continue.";
			btnLi.SetActive (true); btnLo.SetActive (false);
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			Time.timeScale = 0; //pause
		} else {
			Time.timeScale = 1; //resume
		}
	}

	public void LoginWithFB(){
		var perms = new List<string>(){"public_profile"};
		FB.LogInWithReadPermissions(perms, AuthCallback);

        
        
	}

	public void LogoutFromFB(){
		FB.LogOut (); 
        btnLi.SetActive (true); btnLo.SetActive (false);
	}
		
	private void AuthCallback (ILoginResult result) {
		if (result.Error != null) {
			txtStatus.text = result.Error;
		} 
        else
        {
            DispName(result);
            Debug.Log("logged in");
            //txtStatus.text = result.Error;
        }
        //fblogin.gameObject.SetActive(true);
        //signupcanvas.gameObject.SetActive(false);
        //maincanvas.gameObject.SetActive(false);
	}

	void DispName(IResult result){
		if (result.Error != null) {
			txtStatus.text = result.Error;
		} else {

             //IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.ToString()) as IDictionary;
             //fbname = dict["first_name"].ToString();
            // print("your name is: " + fbname);
            
			txtStatus.text = "Hi there: " + result.ResultDictionary ["name"];    
		}
	}

	private void GetPicture(IGraphResult result)
	{
		if (result.Error == null && result.Texture != null)
		{       
			//http://stackoverflow.com/questions/19756453/how-to-get-users-profile-picture-with-facebooks-unity-sdk
			/*if (result.Texture != null) {
				Image img = ProfilePicture.GetComponent<Image> ();
				img.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
			}*/
			//ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
            Image ProfilePic = ProfilePicture.GetComponent<Image>();
            ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}

    //void Displayprofilepic(IGraphResult result)  
    //{
        //if(result.Texture != null){
        
        //}
    //}
}