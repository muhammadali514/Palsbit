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


public class childcreator : MonoBehaviour
{
    List<string> standards = new List<string>(){"Select your standard","1st","2nd","3rd","4th","5th","6th","7th","8th","9th","10th","11th","12th"};

    public Dropdown dropdown;
    
    int standard_val;
    public string getstandard;
    public Button createchild;
    public Text checkk;
    string keyy;

    string p_id;

    public GameObject createacc;

    public static string keygen;
    int i;

    public InputField _username;
    public InputField _name;
    public InputField age;
    public InputField standard;

    public InputField signupcanvasemail;

    private string mailid;

    private string f_fatherid;
    private string f_username;

    private string f_name;
    private string f_age;
    private string f_stand;
    private string f_4digid;

    public GameObject childinfo;
    public GameObject childcreation;
    public int childrencomplete = 0;

    public GameObject intothechild;
    private DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {   //PlayerPrefs.DeleteAll();
        populateoptions();
        //PlayerPrefs.DeleteAll();
        i = PlayerPrefs.GetInt("counter");

        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }
    void Update()
    {
        if(string.IsNullOrEmpty( _username.text ))
        {
            createchild.interactable = false;
        }
        if(string.IsNullOrEmpty(_name.text))
        {
            createchild.interactable = false;
        }
        
        if(string.IsNullOrEmpty(age.text))
        {
            createchild.interactable = false;
        }
        else
        {
            createchild.interactable = true;
        }
        
    }
    void populateoptions()
    {
        
        dropdown.AddOptions(standards);
    }
    public void valuechanged(int index)
    {
        getstandard = standards[index];
        standard_val = index;
        Debug.Log("standard is  " +standard_val);

    }
    public void createchildd()
    {

        p_id = PlayerPrefs.GetString("parentid");
        Debug.Log(p_id);
        f_fatherid = p_id; //getthis from firebase parent auth id
        f_username = _name.text;
        f_name = _username.text;
        f_age = age.text;
        f_stand = standard_val.ToString();
        // f_4digid = id.text;

        writeNewUser(f_fatherid, f_username, f_name, f_age, f_stand);

    }

    private void writeNewUser(string fatherId, string name_user, string name, string age, string grade)
    {
        
        i += 1;
        PlayerPrefs.SetInt("counter", i);
        string key = mDatabaseRef.Child("child").Push().Key;

        LeaderboardEntry entry = new LeaderboardEntry(fatherId, name_user, name, age, grade);

        //entry = new LeaderBoardEntry(fatherId, name_user,name,age,grade);
        Dictionary<string, System.Object> entryValues = entry.ToDictionary();

        Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();
        childUpdates["/child/" + key] = entryValues;
        //childUpdates["/user-scores/" + key ] = entryValues;

        mDatabaseRef.UpdateChildrenAsync(childUpdates);

        Debug.Log("value of keey   " + key);


        
        keygen = key;
        Debug.Log("value of i   " + i);
        //User user = new User(fatherId,name_user,name,age,grade);
        //string json = JsonUtility.ToJson(user);
        // Debug.Log("value of jason  "+json);
        // keyy = mDatabaseRef.Child("scores").Push().Key;
        //Debug.Log(keyy);
        //mDatabaseRef.Child("scores").Child(keyy).SetRawJsonValueAsync(json);
        //string key = mDatabaseRef.Child("scores").Push().Key;
        // mDatabaseRef.Child("scores").Child(keyy).SetRawJsonValueAsync(json);

        if (i == 1)
        {
            Children child1 = new Children();
            child1.chlid1class();

            PlayerPrefs.SetString("username1",  _username.text);                   
            PlayerPrefs.SetInt("user1age",      int.Parse(age.ToString()));           
            PlayerPrefs.SetInt("user1standard", int.Parse(standard.ToString()));




        }
        if (i == 2)
        {
            Children child2 = new Children();
            child2.chlid2class();

            PlayerPrefs.GetString("username2"  ,_username.text);              
            PlayerPrefs.GetInt("user2age"      ,int.Parse(age.ToString()));
            PlayerPrefs.GetInt("user2standard" ,int.Parse(standard.ToString()));
        }

        if (i == 3)
        {
            Children child3 = new Children();
            child3.chlid3class();


            PlayerPrefs.GetString("username3"  ,_username.text);              
            PlayerPrefs.GetInt("user3age"      ,int.Parse(age.ToString()));
            PlayerPrefs.GetInt("user3standard" ,int.Parse(standard.ToString()));
        }

        if (i == 4)
        {
            Children child4 = new Children();
            child4.chlid4class();
            createacc.gameObject.SetActive(false);
            PlayerPrefs.GetString("username4"  ,_username.text);              
            PlayerPrefs.GetInt("user4age"      ,int.Parse(age.ToString()));
            PlayerPrefs.GetInt("user4standard" ,int.Parse(standard.ToString()));
        }
        





        // mDatabaseRef.Child("user").SetRawJsonValueAsync(json);
        //mDatabaseRef.Child("user").Child("user_name").SetValueAsync(name);
        //mDatabaseRef.Child("user").Push();
        //  Debug.Log("json value" +json);



    }

    public void GetUsers()
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("child").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;
                    Debug.Log("values are here");
                    Debug.Log("" + dictUser["uid"] + " - " + dictUser["username"]);

                    string val = dictUser["uid"].ToString();
                    Debug.Log("vallll    " + val);
                    checkk.text = "value is  " + val.ToString();
                }
            }
        });


    }




    // Update is called once per frame
    public void gotochildcreation()
    {
        childinfo.gameObject.SetActive(false);
        childcreation.gameObject.SetActive(true);
        intothechild.gameObject.SetActive(false);
    }

    public void onclickcreate()
    {
        SceneManager.LoadScene(4);
    }

    public void gointothechild()
    {
        childinfo.gameObject.SetActive(false);
        childcreation.gameObject.SetActive(false);
        intothechild.gameObject.SetActive(true);
    }

    public void gotocat()
    {
        SceneManager.LoadScene(3);
    }

    public void gobacktochildinfo()
    {
        childinfo.gameObject.SetActive(true);
        childcreation.gameObject.SetActive(false);
        intothechild.gameObject.SetActive(false);
    }
}
