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


public class childinfo : MonoBehaviour
{
    public Text btntxt;

    int i;
    public GameObject childinfocanvas;
    public GameObject childplaycanvas;

    public Button createchild;
    private DatabaseReference mDatabaseRef;

    public GameObject user1;
    public GameObject user2;
    public GameObject user3;
    public GameObject user4;

    public Text username1;
    public Text username2;
    public Text username3;
    public Text username4;

    public Text age1;
    public Text age2;
    public Text age3;
    public Text age4;

    public string path1;
    public string path2;
    public string path3;
    public string path4;

    private string usernamesaver1;

    private int useragesave1;

    private int user1standardsaver;

    private string usernamesaver2;

    private int useragesave2;

    private int user2standardsaver;

    private string usernamesaver3;

    private int useragesave3;

    private int user3standardsaver;

    private string usernamesaver4;

    private int useragesave4;

    private int user4standardsaver;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
       // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
         mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;


                       usernamesaver1      =    PlayerPrefs.GetString("username1");
                       useragesave1        =    PlayerPrefs.GetInt("user1age");
                       user1standardsaver  =    PlayerPrefs.GetInt("user1standard");
                       usernamesaver2      =    PlayerPrefs.GetString("username2");
                       useragesave2        =    PlayerPrefs.GetInt("user2age");
                       user2standardsaver  =    PlayerPrefs.GetInt("user2standard");
                       usernamesaver3      =    PlayerPrefs.GetString("username3");
                       useragesave3        =    PlayerPrefs.GetInt("user3age");
                       user3standardsaver  =    PlayerPrefs.GetInt("user3standard");
                       usernamesaver4      =    PlayerPrefs.GetString("username4");
                       useragesave4        =    PlayerPrefs.GetInt("user4age");
                       user4standardsaver  =    PlayerPrefs.GetInt("user4standard");

        i = PlayerPrefs.GetInt("counter");
        btntxt.text = "Create child "+ i.ToString() + "/4";
       //child one data retreival
       Children.child1created = PlayerPrefs.GetInt("child1created");
       Children.child2created = PlayerPrefs.GetInt("child2created");
       Children.child3created = PlayerPrefs.GetInt("child3created");
       Children.child4created = PlayerPrefs.GetInt("child4created");

       // Debug.Log("child1created  "+Children.child1created);
       // Debug.Log("child2created  "+Children.child2created);
       // Debug.Log("child3created  "+Children.child3created);
       // Debug.Log("child4created  "+Children.child4created);
        path1 = PlayerPrefs.GetString("child1");
        path2 = PlayerPrefs.GetString("child2");
        path3 = PlayerPrefs.GetString("child3");
        path4 = PlayerPrefs.GetString("child4");

        if(Children.child1created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 1   "+path1);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path1).GetValueAsync().ContinueWith(task => {
            
                   
                    if (task.IsFaulted) {
                        //Debug.Log("into the debug 22");
                        // Handle the error...
                    }
                    
                        else if (task.IsCompleted) 
                        {
                        Debug.Log("into the debug 33");
                        DataSnapshot snapshot = task.Result;
                        Debug.Log(snapshot);
                        foreach ( DataSnapshot user in snapshot.Children){
                        
                        IDictionary dictUser = (IDictionary)user.Value;
                        Debug.Log("values of child one");
                        Debug.Log ("" + dictUser["age"] + " - " + dictUser["username"]+ "    " +dictUser["name"]);
                        Debug.Log(path1);
                        //username1.text = dictUser["username"].ToString();
                        //age1.text = dictUser["age"].ToString();
                       // string val = dictUser["uid"].ToString();
                       // Debug.Log("vallll    "+val);

                       usernamesaver1 =  dictUser["username"].ToString();
                       useragesave1 = int.Parse(dictUser["age"].ToString());
                       user1standardsaver = int.Parse(dictUser["stand"].ToString());

                       //username1.text = dictUser["username"].ToString();

                        // Debug.Log("valuess are " +usernamesaver1);
                        // Debug.Log(useragesave1);
                        // Debug.Log(user1standardsaver);

                       PlayerPrefs.SetString("username1", usernamesaver1.ToString());
                       PlayerPrefs.SetInt("user1age",useragesave1);
                       PlayerPrefs.SetInt("user1standard",user1standardsaver);


                        
                      }
                    }
          });
        }
        if(Children.child2created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 2      "+path2);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path2).GetValueAsync().ContinueWith(task => {
                    if (task.IsFaulted) {
                        // Handle the error...
                    }
                    
                        else if (task.IsCompleted) {
                        DataSnapshot snapshot = task.Result;
                        foreach ( DataSnapshot user in snapshot.Children){
                        IDictionary dictUser = (IDictionary)user.Value;

                        
                        //Debug.Log("values of child two");
                        //Debug.Log ("" + dictUser["age"] + " - " + dictUser["username"] + "    " +dictUser["name"]);
                        //Debug.Log(path2);
                        //username2.text = dictUser["username"].ToString();
                        //age2.text = dictUser["age"].ToString();
                       // string val = dictUser["uid"].ToString();
                       usernamesaver2 =  dictUser["username"].ToString();
                       useragesave2 = int.Parse(dictUser["age"].ToString());
                       user2standardsaver = int.Parse(dictUser["stand"].ToString());

                        Debug.Log("values are "+usernamesaver1);
                        Debug.Log("values are "+useragesave1);
                        Debug.Log("values are "+user1standardsaver);
                        
                       PlayerPrefs.SetString("username2", usernamesaver2.ToString());
                       PlayerPrefs.SetInt("user2age",useragesave2);
                       PlayerPrefs.SetInt("user2standard",user2standardsaver);

                       //Debug.Log("playerprefs ans are     " +PlayerPrefs.GetString("username2"));
                       //Debug.Log("playerprefs ans are     " +PlayerPrefs.GetInt("user2age"));
                       //Debug.Log("playerprefs ans are     " +PlayerPrefs.GetInt("user2standard")); 
                      }
                    }
          });
        }
        if(Children.child3created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 3   "+path3);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path3).GetValueAsync().ContinueWith(task => {
                    if (task.IsFaulted) {
                        // Handle the error...
                    }
                    
                        else if (task.IsCompleted) {
                        DataSnapshot snapshot = task.Result;
                        foreach ( DataSnapshot user in snapshot.Children){
                        IDictionary dictUser = (IDictionary)user.Value;

                        
                        Debug.Log("values of child three");
                        Debug.Log ("" + dictUser["age"] + " - " + dictUser["username"]+ "    " +dictUser["name"]);
                        //username3.text = dictUser["username"].ToString();
                        //age3.text = dictUser["age"].ToString();
                       // string val = dictUser["uid"].ToString();
                       usernamesaver3 =  dictUser["username"].ToString();
                       useragesave3 = int.Parse(dictUser["age"].ToString());
                       user3standardsaver = int.Parse(dictUser["stand"].ToString());

                        PlayerPrefs.SetString("username3", usernamesaver3.ToString());
                        PlayerPrefs.SetInt("user3age",useragesave3);
                        PlayerPrefs.SetInt("user3standard",user3standardsaver);
                       // Debug.Log("vallll    "+val);
                        
                      }
                    }
          });
        }
        if(Children.child4created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 4   " +path4);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path4).GetValueAsync().ContinueWith(task => {
                    if (task.IsFaulted) {
                        // Handle the error...
                    }
                    
                        else if (task.IsCompleted) {
                        DataSnapshot snapshot = task.Result;
                        foreach ( DataSnapshot user in snapshot.Children){
                        IDictionary dictUser = (IDictionary)user.Value;

                        
                        Debug.Log("values of child four");
                        Debug.Log ("" + dictUser["age"] + " - " + dictUser["username"]+ "    " +dictUser["name"]);
                        //username4.text = dictUser["username"].ToString();
                        //age4.text = dictUser["age"].ToString();

                       usernamesaver4 =  dictUser["username"].ToString();
                       useragesave4 = int.Parse(dictUser["age"].ToString());
                       user4standardsaver = int.Parse(dictUser["stand"].ToString());

                      PlayerPrefs.SetString("username4", usernamesaver4.ToString());
                      PlayerPrefs.SetInt("user4age",useragesave4);
                      PlayerPrefs.SetInt("user4standard",user4standardsaver);

                      //  string val = dictUser["uid"].ToString();
                      //  Debug.Log("vallll    "+val);
                        
                      }
                    }
          });
        }





    }

    
    void Update()
    {   


                       //usernamesaver1      =    PlayerPrefs.GetString("username1");
                       //useragesave1        =    PlayerPrefs.GetInt("user1age");
                       //user1standardsaver  =    PlayerPrefs.GetInt("user1standard");
                       //usernamesaver2      =    PlayerPrefs.GetString("username2");
                       //useragesave2        =    PlayerPrefs.GetInt("user2age");
                       //user2standardsaver  =    PlayerPrefs.GetInt("user2standard");
                       //usernamesaver3      =    PlayerPrefs.GetString("username3");
                       //useragesave3        =    PlayerPrefs.GetInt("user3age");
                       //user3standardsaver  =    PlayerPrefs.GetInt("user3standard");
                       //usernamesaver4      =    PlayerPrefs.GetString("username4");
                       //useragesave4        =    PlayerPrefs.GetInt("user4age");
                       //user4standardsaver  =    PlayerPrefs.GetInt("user4standard");

       // Debug.Log(Children.child1created);
         ///useragesave1 




        if(Children.child1created == 0)
        {
            user1.gameObject.SetActive (false);
            
        }
        if(Children.child2created == 0)
        {
            user2.gameObject.SetActive (false);
            
        }
        if(Children.child3created == 0)
        {
            user3.gameObject.SetActive (false);
            
        }
        if(Children.child4created == 0)
        {
            user4.gameObject.SetActive (false);
            
        }

        if(Children.child1created == 1)
        {
            user1.gameObject.SetActive (true);
            username1.text = usernamesaver1.ToString();
            age1.text = useragesave1.ToString();
            
        }
        if(Children.child2created == 1)
        {
            user2.gameObject.SetActive (true);
            username2.text = usernamesaver2.ToString();
            age2.text = useragesave2.ToString();
        }
        if(Children.child3created == 1)
        {
            user3.gameObject.SetActive (true);
            username3.text = usernamesaver3.ToString();
            age3.text = useragesave3.ToString();
        }
        if(Children.child4created == 1)
        {
            user4.gameObject.SetActive (true);
            username4.text = usernamesaver4.ToString();
            age4.text = useragesave4.ToString();
            createchild.interactable = false;


        }
        
            
            
          
        
        }
        public void gotochild()
        {
            SceneManager.LoadScene(1);
        }

        public void onclickcheck()
        {
                       Debug.Log(usernamesaver1);
                       Debug.Log(usernamesaver2);
                       Debug.Log(usernamesaver3);
                       Debug.Log(usernamesaver4);
                       Debug.Log(useragesave1);
                       Debug.Log(useragesave2);
                       Debug.Log(useragesave3);
                       Debug.Log(useragesave4);
                       Debug.Log(user1standardsaver);
                       Debug.Log(user2standardsaver);
                       Debug.Log(user3standardsaver);
                       Debug.Log(user4standardsaver);
        }

        public void signout()
        {
            FirebaseAuth.DefaultInstance.SignOut();
            SceneManager.LoadScene(0);
        }
        public void gotochildcanvas()
    {
        childinfocanvas.gameObject.SetActive(false);
        childplaycanvas.gameObject.SetActive(true);
    }

    public void gotochildinfocanvas()
    {
        childinfocanvas.gameObject.SetActive(true);
        childplaycanvas.gameObject.SetActive(false);
    }

    public void gotocat()
    {
        SceneManager.LoadScene(3);
    }



    // Update is called once per frame
    
}
