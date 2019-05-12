using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using Firebase.Auth;
using Firebase.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logincontroller : MonoBehaviour
{
    
    public bool loggedinbool = false;
    public Text displayusername;
        public GameObject profilepic;   
    List<string> countries = new List<string>(){"Select your country", "Afghanistan", "Albania","Algeria","Andora","Armania","Australia","Austria","Azerbaijan","Bahamas","Bahrain","Bangladesh","Bhutan","Brazil","Brunei","Bulgeria","Cambodia","Canada","Chile","China","Colombia","Croatia","Cyprus","Dominicia","Denmark","Egypt","Ethopia","Fiji","Finland","France","Georgia","Ghana","Greece","Germany","Haiti","Hungry","Iceland","India","Indonesia","Iraq","Iran","Ireland","Israel","Italy","Jamaica","Japan","Jordan","Kazakhstan","Kenya","Kuwait","Lebanon","Libya","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta","Mauritius","Mauritania","Mexico","Monaco","Mazambique","Nepal","Netherlands","Niger","Nigeria","Norway","Oman","Pakistan","Palau","Panama","Peru","Philippines","Poland","Portugal","Qatar","Romania","Russia","Saudia Arabia","Serbia","Singapore","Slovenia","SolomonIslands","South Africa","Sri Lanka","Sudan","Spain","Sweden","Switzerland","Syria","Taiwan","Tajikistan","Thailand","Togo","Tunisia","Turkey","Turkmenistan","Uganda","Ukraine","United Arab Emirates","United Kingdom","United States","Uzbekistan","Vanuatu","Vietnam","Yemen","Zambia","Zimbabwe"};
    public Dropdown countrydropdown;

    public string countryval;
    public Button createsignup;
    public Text error;
    public Text signuperror;
    public string id = "111";
    public InputField username;
    public InputField _name;
    public InputField loginemail;
    public InputField loginpassword;
    public InputField signupcanvasemail;

    public InputField signuppassword;
    private string mailid;

    private string f_user_name;
    private string f_name;
    private string f_country;
    private string f_email;

    //private string f_4digid;
    public int loggedin = 0;
    public string accessToken;

    private DatabaseReference mDatabaseRef;
    public GameObject parentlogincanvas;
    public GameObject parentsignupcanvas;
    public GameObject signinnedpage;
    public FirebaseUser userr;
    //public FirebaseAuth auth;
    public string parentid;
    public bool onetimeuse = false;

    public bool loginvalue = true;
    public class User
    {
        public string username;

        

        public string country;

        public string standdd;
        public string email;

        public User()
        {
        }
        public User(string username, string country, string stand_grad, string email)
        {
            this.username = username;
            this.email = email;
            this.country = country;
            this.standdd = stand_grad;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
             
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        //Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        populateoptions();
    }
    

    void populateoptions()
    {
        
        countrydropdown.AddOptions(countries);
    }

    public void valuechanged(int index)
    {
        countryval = countries[index];
        PlayerPrefs.SetString("country",countryval);
    }
    
    // Update is called once per frame


    public void signin()
    {
        
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(loginemail.text, loginpassword.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                loginvalue = false;
                Debug.Log (loginvalue);
                //error.text = "Wrong id or Password";
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);


                // wrongidpasstext.text = "Wrong Password or id";
                return;
            }
            loggedin =1;
            loginvalue = true;
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
            
            //parentloggedin = true;


        });

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private void Update() {
        if(loggedin == 1)
        {
            if(onetimeuse == false)
            {
                onetimeuse = true;
                SceneManager.LoadScene(4);
            }
        }
        if(loginvalue== false)
        {
            error.text = "Wrong id pass";
        }
        if(loginvalue == true)
        {
            error.text = "";
        }
        
        if( string.IsNullOrEmpty( _name.text ) )
        {
            createsignup.interactable = false;
        }
        if(string.IsNullOrEmpty( username.text ))
        {
            createsignup.interactable = false;
        }
        if(string.IsNullOrEmpty( signupcanvasemail.text ))
        {
            createsignup.interactable = false;
        }
        if(string.IsNullOrEmpty( signuppassword.text ))
        {
            createsignup.interactable = false;
        }
        
        else
        {
            createsignup.interactable = true;
        }
        if(loggedinbool==true)
        {
            parentlogincanvas.gameObject.SetActive(false);
            parentsignupcanvas.gameObject.SetActive(false);
            signinnedpage.gameObject.SetActive(true);
        }
        else if(loggedinbool==false)
        {
            parentlogincanvas.gameObject.SetActive(true);
            parentsignupcanvas.gameObject.SetActive(false);
            signinnedpage.gameObject.SetActive(false);
        }
    }
    public void fblogin()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.Credential credential =
        Firebase.Auth.FacebookAuthProvider.GetCredential(accessToken);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            loggedinbool = true;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
            getcred();
            

        });

        
   
    }

    public void getcred()
    {
            
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("working till here");
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        Debug.Log("working till here  2");
        if (user != null)
        {
            Debug.Log("working till here 3");
            string name = user.DisplayName;
            string email = user.Email;
            System.Uri photo_url = user.PhotoUrl;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = user.UserId;

            Debug.Log(name);
            Debug.Log(email);

            displayusername.text = name.ToString();
            //profilepic dp = GetComponent<Image>();
            //profilepic = photo_url.;
            //profilepic.sprite = Sprite.Create (profilepic.transform, new Rect (0, 0, 128, 128), new Vector2 ());
            
        }
    }

    public void gotosignuppage()
    {
        parentlogincanvas.gameObject.SetActive(false);
        parentsignupcanvas.gameObject.SetActive(true);
    }

    public void signup()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        
        
        signuperror.text = "0";
        f_user_name = username.text;
        f_name = _name.text;
        f_country = countryval;
        f_email = signupcanvasemail.text;
        //f_4digid = "";

        signuperror.text = "1";
        auth.CreateUserWithEmailAndPasswordAsync(signupcanvasemail.text, signuppassword.text).ContinueWith(task =>
        {
            signuperror.text = "2";
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                signuperror.text = "error ocuured   " + task.Exception;
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        


        writeNewUser(f_user_name,f_name, f_country, f_email);
        //FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(signupcanvasemail.text, signuppassword.text).ContinueWith((obj) =>
        //{

        //       Debug.Log(obj);
        //});
        parentlogincanvas.gameObject.SetActive(true);
        parentsignupcanvas.gameObject.SetActive(false);
    }
    
    private void writeNewUser(string user_name, string __name, string _country, string email)
    {

        /* 
        User user = new User(name, age, grade, email);
        string json = JsonUtility.ToJson(user);

        Debug.Log("value of jason  " + json);
        mDatabaseRef.Child("user").Child().SetRawJsonValueAsync(json);
        //mDatabaseRef.Child("user").Child("user_name").SetValueAsync(name);
        //mDatabaseRef.Child("user").Push();
        Debug.Log("json value" + json);
        */
        string key = mDatabaseRef.Child("child").Push().Key;

        Fatherentry entry = new Fatherentry(user_name, __name, _country, email);

        //entry = new LeaderBoardEntry(fatherId, name_user,name,age,grade);
        Dictionary<string, System.Object> entryValues = entry.ToDictionary();

        Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();
        childUpdates["/parent/" + key] = entryValues;
        //childUpdates["/user-scores/" + key ] = entryValues;

        mDatabaseRef.UpdateChildrenAsync(childUpdates);


    }


    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != userr)
        {
            bool signedIn = userr != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && userr != null)
            {
                Debug.Log("Signed out " + userr.UserId);
            }
            userr = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + userr.UserId);
                createparent();
            }
        }
    }
    public void createparent()
    {
        parentid = userr.UserId.ToString();
        PlayerPrefs.SetString("parentid", parentid);
        Debug.Log("Parent id is " + parentid);
    }

    public void gotologinpage()
    {
        parentlogincanvas.gameObject.SetActive(true);
        parentsignupcanvas.gameObject.SetActive(false);
    }

    

}
