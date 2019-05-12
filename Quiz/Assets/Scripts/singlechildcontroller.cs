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

public class singlechildcontroller : MonoBehaviour
{   
    public Text username;
    public Text userscore;

    public Text userage;
    public Text userstandard;
    public string path1;
    public string path2;
    public string path3;
    public string path4;

private string usernamesaver1    ;
private int useragesave1      ;
private int user1standardsaver;
private string usernamesaver2    ;
private int useragesave2      ;
private int user2standardsaver;
private string usernamesaver3    ;
private int useragesave3      ;
private int user3standardsaver;
private string usernamesaver4    ;
private int useragesave4      ;
private int user4standardsaver;
    
    public int childnumber = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        path1 = PlayerPrefs.GetString("child1");
        path2 = PlayerPrefs.GetString("child2");
        path3 = PlayerPrefs.GetString("child3");
        path4 = PlayerPrefs.GetString("child4");


       Children.child1created = PlayerPrefs.GetInt("child1created");
       Children.child2created = PlayerPrefs.GetInt("child2created");
       Children.child3created = PlayerPrefs.GetInt("child3created");
       Children.child4created = PlayerPrefs.GetInt("child4created");

        if (Children.child1created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;

            dbInstance.GetReference("child").OrderByKey().EqualTo(path1).GetValueAsync().ContinueWith(task =>
            {


                if (task.IsFaulted)
                {
                    //Debug.Log("into the debug 22");
                    // Handle the error...
                }

                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log(snapshot);
                    foreach (DataSnapshot user in snapshot.Children)
                    {

                        IDictionary dictUser = (IDictionary)user.Value;
                        Debug.Log("values of child one");
                        Debug.Log("" + dictUser["age"] + " - " + dictUser["username"] + "    " + dictUser["name"]);
                        Debug.Log(path1);
                        usernamesaver1 = dictUser["username"].ToString();
                        useragesave1 = int.Parse(dictUser["age"].ToString());
                        user1standardsaver = int.Parse(dictUser["stand"].ToString());

                        //username1.text = dictUser["username"].ToString();

                        // Debug.Log("valuess are " +usernamesaver1);
                        // Debug.Log(useragesave1);
                        // Debug.Log(user1standardsaver);

                        PlayerPrefs.SetString("username1", usernamesaver1.ToString());
                        PlayerPrefs.SetInt("user1age", useragesave1);
                        PlayerPrefs.SetInt("user1standard", user1standardsaver);



                    }
                }
            });
        }
        if (Children.child2created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            
            dbInstance.GetReference("child").OrderByKey().EqualTo(path2).GetValueAsync().ContinueWith(task =>
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

                        usernamesaver2 = dictUser["username"].ToString();
                        useragesave2 = int.Parse(dictUser["age"].ToString());
                        user2standardsaver = int.Parse(dictUser["stand"].ToString());


                        PlayerPrefs.SetString("username2", usernamesaver2.ToString());
                        PlayerPrefs.SetInt("user2age", useragesave2);
                        PlayerPrefs.SetInt("user2standard", user2standardsaver);

                    }
                }
            });
        }
        if (Children.child3created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 3   " + path3);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path3).GetValueAsync().ContinueWith(task =>
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


                        Debug.Log("values of child three");
                        Debug.Log("" + dictUser["age"] + " - " + dictUser["username"] + "    " + dictUser["name"]);
                        
                        usernamesaver3 = dictUser["username"].ToString();
                        useragesave3 = int.Parse(dictUser["age"].ToString());
                        user3standardsaver = int.Parse(dictUser["stand"].ToString());

                        PlayerPrefs.SetString("username3", usernamesaver3.ToString());
                        PlayerPrefs.SetInt("user3age", useragesave3);
                        PlayerPrefs.SetInt("user3standard", user3standardsaver);
                        

                    }
                }
            });
        }
        if (Children.child4created == 1)
        {
            Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
            Debug.Log("into the child 4   " + path4);
            dbInstance.GetReference("child").OrderByKey().EqualTo(path4).GetValueAsync().ContinueWith(task =>
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


                        //Debug.Log("values of child four");
                        //Debug.Log("" + dictUser["age"] + " - " + dictUser["username"] + "    " + dictUser["name"]);
                        usernamesaver4 = dictUser["username"].ToString();
                        useragesave4 = int.Parse(dictUser["age"].ToString());
                        user4standardsaver = int.Parse(dictUser["stand"].ToString());

                        PlayerPrefs.SetString("username4", usernamesaver4.ToString());
                        PlayerPrefs.SetInt("user4age", useragesave4);
                        PlayerPrefs.SetInt("user4standard", user4standardsaver);


                    }
                }
            });
        }





    }
                       
                        /* 

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

                        Debug.Log(PlayerPrefs.GetString("username1"));
                        Debug.Log(PlayerPrefs.GetInt("user1age"));    
                        Debug.Log(PlayerPrefs.GetInt("user1standard"));
                        Debug.Log(PlayerPrefs.GetString("username2")); 
                        Debug.Log(PlayerPrefs.GetInt("user2age"));    
                        Debug.Log(PlayerPrefs.GetInt("user2standard"));
                        Debug.Log(PlayerPrefs.GetString("username3")); 
                        Debug.Log(PlayerPrefs.GetInt("user3age"));     
                        Debug.Log(PlayerPrefs.GetInt("user3standard"));
                        Debug.Log(PlayerPrefs.GetString("username4")); 
                        Debug.Log(PlayerPrefs.GetInt("user4age"));     
                        Debug.Log(PlayerPrefs.GetInt("user4standard"));
                        */


    

    // Update is called once per frame
    void Update()
    {
                       

            if(childnumber == 1)
            {
                username.text = usernamesaver1;
                userage.text = useragesave1.ToString();
                userstandard.text = user1standardsaver.ToString() + "th";
            }
            if(childnumber == 2)
            {
                username.text = usernamesaver1;
                userage.text = useragesave1.ToString();
                userstandard.text = user1standardsaver.ToString() + "th";
            }
            if(childnumber == 3)
            {
                username.text = usernamesaver3;
                userage.text = useragesave3.ToString();
                userstandard.text = user3standardsaver.ToString() + "th";
            }
            if(childnumber == 4)
            {
                username.text = usernamesaver4;
                userage.text = useragesave4.ToString();
                userstandard.text = user4standardsaver.ToString() + "th";
            }

    }

    public void child1click()
    {
        childnumber = 1;
        Debug.Log("child numer " +childnumber);
    }
    public void child2click()
    {
        childnumber = 2;
        Debug.Log("child numer " +childnumber);
    }
    public void child3click()
    {
        childnumber = 3;
        Debug.Log("child numer " +childnumber);
    }
    public void child4click()
    {
        childnumber = 4;
        Debug.Log("child numer " +childnumber);
    }
}
