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


public class getquestions : MonoBehaviour
{
    public string answerval;
    public Text question;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;

    public string _question;
    public string _option1;
    public string _option2;
    public string _option3;
    public string _option4;
    public string standard;
    public string answer;
    public string complexity;
    public string level;
    

    private DatabaseReference mDatabaseRef;
    public DataSnapshot snapshot;

    public GameObject canv1;
    public GameObject canv2;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        Debug.Log("into the debug");
        dbInstance.GetReference("questions").GetValueAsync().ContinueWith(task =>
        {


            if (task.IsFaulted)
            {
                //Debug.Log("into the debug 22");
                // Handle the error...
            }

            else if (task.IsCompleted)
            {

                Debug.Log("into the debug 33");
                snapshot = task.Result;
                Debug.Log(snapshot.ChildrenCount);
                foreach (DataSnapshot user in snapshot.Children)
                {
                    Debug.Log("into for");
                    IDictionary dictUser = (IDictionary)user.Value;
                    //Debug.Log("value of dict   " + dictUser["id"]);

                    // question.text =dictUser["Question"].ToString();
                    // option1.text = dictUser["option1"].ToString();
                    // option2.text = dictUser["option2"].ToString();
                    // option3.text = dictUser["option3"].ToString();
                    // option4.text = dictUser["option4"].ToString();


                    _question = dictUser["Question"].ToString();
                    _option1  = dictUser["Option1"].ToString();
                    _option2  = dictUser["Option2"].ToString();
                    _option3  = dictUser["Option3"].ToString();
                    _option4  = dictUser["Option4"].ToString();
                    answerval = dictUser["Answer"].ToString();

                    //Buttoncreation();
                    // catt = dictUser["id"].ToString();

                    Debug.Log ("answer is  "+answerval);
                    //Debug.Log("values of child one");
                    Debug.Log ("values aree   " + dictUser["Question"] + " - " + dictUser["option1"]+ "    " +dictUser["option2"]+ "    " +dictUser["option3"]+ "    " +dictUser["option4"]);
                    //Debug.Log(path1);
                    // username1.text = dictUser["username"].ToString();
                    //  age1.text = dictUser["age"].ToString();
                    // string val = dictUser["uid"].ToString();
                    // Debug.Log("vallll    "+val);

                    //usernamesaver1 =  dictUser["username"].ToString();
                    //useragesave1 = int.Parse(dictUser["age"].ToString());
                    //user1standardsaver = int.Parse(dictUser["stand"].ToString());

                    //PlayerPrefs.SetString("username1", usernamesaver1);
                    //PlayerPrefs.SetInt("user1age",useragesave1);
                    //PlayerPrefs.SetInt("user1standard",user1standardsaver);



                }

            }
        });
    }

        public Dictionary<string, System.Object> ToDictionary() 
        {
        Dictionary<string, System.Object> question = new Dictionary<string, System.Object>();
        question["Question"] = question;
        question["Answer"] = answer;
        question["Option1"] = option1;
        question["Option2"] = option2;
        question["Option3"] = option3;
        question["Option4"] = option4;
        question["Standard"] = standard;
        question["complexity"] = complexity;
        question["Level"] = level;
        
        return question;
        }

    // Update is called once per frame
    void Update()
    {
        question.text   = _question.ToString();
        option1.text    = _option1.ToString();
        option2.text    = _option2.ToString();
        option3.text    = _option3.ToString();
        option4.text    = _option4.ToString();
    } 
    public void _canv2( )
    {
        canv1.gameObject.SetActive(false);
        canv2.gameObject.SetActive(true);
    }
    public void _canv1()
    {
        canv1.gameObject.SetActive(true);
        canv2.gameObject.SetActive(false);
    }

    public void onclick1()
    {
        if(answerval.Equals(_option1))
        {
            Debug.Log("you won");
        }
        else
        {
            Debug.Log("you lose");
        }
    }
    public void onclick2()
    {
        if(answerval.Equals(_option2))
        {
            Debug.Log("you won");
        }
        else
        {
            Debug.Log("you lose");
        }
    }
    public void onclick3()
    {
        if(answerval.Equals(_option3))
        {
            Debug.Log("you won");
        }
        else
        {
            Debug.Log("you lose");
        }
    }
    public void onclick4()
    {
        if(answerval.Equals(_option4))
        {
            Debug.Log("you won");
        }
        else
        {
            Debug.Log("you lose");
        }
    }
}
