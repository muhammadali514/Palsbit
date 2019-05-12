using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Auth;
using Firebase.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class insert : MonoBehaviour
{
private int idLevel;
string ans;
private float points; 
private float ques; 
private int correct; 
private int Finish; 
string show_question;
string show_answer  ;
string show_option1 ;
string show_option2 ;
string show_option3 ;
string show_option4 ;
    public Text infoAnswer;
     public Text question;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public class questionclass{
        public string class_question;
        public string class_answer;
        public string class_option1;
        public string class_option2;
        public string class_option3;
        public string class_option4;

        public string answerval;
   

        public questionclass()
        {
        }
        public questionclass(string question, string answer, string option1, string option2,string option3, string option4)
        {
            this.class_question = question;
            this.class_answer   = answer;
            this.class_option1 = option1;
            this.class_option2 = option2;
            this.class_option3 = option3;
            this.class_option4 = option4;

        }

    }
    List<questionclass> questionlist = new List<questionclass>();
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
public string answerval;
string abc_question;
string abc_answer;
string abc_option1;
string abc_option2;
string abc_option3;
string abc_option4;
string abc_category;
string abc_Level;
string abc_Standard;
string abc_explanation;
string abc_complexity;


public string _question;
    public string _option1;
    public string _option2;
    public string _option3;
    public string _option4;
    public string standard;
    public string answer;
    public string complexity;
    public string level;
    public string category;

    public string explanation = "all are same";
    public int iIndex = 0;

    private DatabaseReference mDatabaseRef;
    public DataSnapshot snapshot;
    // Use this for initialization
    void Start()
    {   
        
        conn = "URI=file:" + Application.dataPath + "/Questions.db"; //Path to database.
        conn = Application.persistentDataPath + "/Questions.db";

        conn = "URI= file:jar:" + Application.dataPath + "!/assets/" + "/Questions.db";
        //dbcon = new SqliteConnection(connection);
        //Deletvalue(6);
        //insertvalue("ahmedm", "ahmedm@gmail.com", "sss"); 
        //Updatevalue("a","w@gamil.com","1st",1);
        //readers();


        //for firebase
                FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("questions").OrderByKey().GetValueAsync().ContinueWith(task =>
        {


            if (task.IsFaulted)
            {
                //Debug.Log("into the debug 22");
                // Handle the error...
            }

            else if (task.IsCompleted)
            {

                snapshot = task.Result;
                Debug.Log(snapshot.ChildrenCount);
                foreach (DataSnapshot user in snapshot.Children)
                {
                    //Debug.Log("into for  " +user);
                    IDictionary dictUser = (IDictionary)user.Value;
                   // Debug.Log("Working ");
                    //Debug.Log("value of dict   " + dictUser["id"]);

                    // question.text =dictUser["Question"].ToString();
                    // option1.text = dictUser["option1"].ToString();
                    // option2.text = dictUser["option2"].ToString();
                    // option3.text = dictUser["option3"].ToString();
                    // option4.text = dictUser["option4"].ToString();


                    _question   = dictUser["Question"].ToString();
                    _option1    = dictUser["Option1"].ToString();
                    _option2    = dictUser["Option2"].ToString();
                    _option3    = dictUser["Option3"].ToString();
                    _option4    = dictUser["Option4"].ToString();
                    answer      = dictUser["Answer"].ToString();
                    complexity  = dictUser["Complexity"].ToString();
                    category    = dictUser["SubCategory"].ToString();
                    standard    = dictUser["Standard"].ToString();
                    level       = dictUser["Level"].ToString();
                    //explanation =dictUser["explanation"].ToString();

                    //savedb();


                }

            }
        });
        //firebase end

        
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database."SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            dbcmd = dbconn.CreateCommand();//"SELECT * FROM myTable WHERE column1 = "+ someValue,
            //sqlQuery = "SELECT * " + "FROM Questions "+ "where  Level" = '"++"' ;// table name
            sqlQuery = "SELECT * FROM Questions WHERE Level == 2 AND Standard == 2" ;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string question = reader.GetString(1);
                string answer =   reader.GetString(2);
                string option1 =  reader.GetString(3);
                string option2 =  reader.GetString(4);
                string Option3 =  reader.GetString(5);
                string option4 =  reader.GetString(6);
                string category = reader.GetString(7);
                int level = int.Parse(reader.GetString(8));
                int standard = int.Parse(reader.GetString(9));
                string explanation = reader.GetString(10);
                string complexity = reader.GetString(11);
                
                questionlist.Add(new questionclass(question,answer,option1,option2,Option3,option4));             


                    
                

                //Debug.Log("value= " + id + "  name =" + name + "  Eamil =" + Email + "   Phone" + Phone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
            show_question = questionlist[iIndex].class_question;
            show_answer = questionlist[iIndex].class_answer;
            show_option1 = questionlist[iIndex].class_option1;
            show_option2 = questionlist[iIndex].class_option2;
            show_option3 = questionlist[iIndex].class_option3;
            show_option4 = questionlist[iIndex].class_option4;

            Debug.Log("answer is  "+show_answer);
            question.text = show_question.ToString();
            option1.text = show_option1.ToString();
            option2.text = show_option2.ToString();
            option3.text = show_option3.ToString();
            option4.text = show_option4.ToString();
            infoAnswer.text = "Correct Answers "+correct.ToString () + " of " + ques.ToString()+ " Questions.";
            ques = questionlist.Count;
        
    }
    

    public void savedb()
    {
        
        abc_question =    _question ;
        abc_answer =      answer   ;
        abc_option1 =     _option1   ;
        abc_option2 =     _option2   ;
        abc_option3 =     _option3   ;
        abc_option4 =     _option4     ;
        abc_category =    category ;
        abc_Level =       level   ;
        abc_Standard =    standard   ;
        abc_explanation = explanation ;
        abc_complexity =  complexity;
        insertvalue(abc_question, abc_answer, abc_option1, abc_option2, abc_option3, abc_option4, abc_category, abc_Level, abc_Standard, abc_explanation, abc_complexity);

    }

    private void insertvalue(string _question,string _answer,string _option1,string _option2,string _option3,string _option4,string _category,string _Level,string _Standard,string _explanation,string _complexity)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Questions(question, answer, option1, option2, option3, option4, category , Level, Standard, explanation, complexity) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\")", _question, _answer, _option1,_option2,_option3,_option4,_category,_Level,_Standard,_explanation,_complexity);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            Debug.Log("Data entered");
        }
    }
    private void Deletvalue(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void Updatevalue(string name, string email, string address, int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Usersinfo set Name=\"{0}\", Email=\"{1}\", Address=\"{2}\" WHERE ID=\"{3}\" ", name, email, address, id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void readers()
    {
        Debug.Log("In readers");
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM Questions";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string Email = reader.GetString(2);
                string Phone = reader.GetString(3);

                Debug.Log("value= " + id + "  name =" + name + "  Eamil =" + Email + "   Phone" + Phone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    // Update is called once per frame
    
    private void Update() {
        //Debug.Log("answer is  "+show_answer);
    }
    public void checkkrso()
    {
        Debug.Log("In check");
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database."SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            dbcmd = dbconn.CreateCommand();//"SELECT * FROM myTable WHERE column1 = "+ someValue,
            //sqlQuery = "SELECT * " + "FROM Questions "+ "where  Level" = '"++"' ;// table name
            sqlQuery = "SELECT * FROM Questions WHERE Level == 2 AND Standard == 2" ;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string question = reader.GetString(1);
                string answer =   reader.GetString(2);
                string option1 =  reader.GetString(3);
                string option2 =  reader.GetString(4);
                string Option3 =  reader.GetString(5);
                string option4 =  reader.GetString(6);
                string category = reader.GetString(7);
                int level = int.Parse(reader.GetString(8));
                int standard = int.Parse(reader.GetString(9));
                string explanation = reader.GetString(10);
                string complexity = reader.GetString(11);
                
                questionlist.Add(new questionclass(question,answer,option1,option2,Option3,option4));             


                    
                

                //Debug.Log("value= " + id + "  name =" + name + "  Eamil =" + Email + "   Phone" + Phone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    public void showquestion()
    {
        iIndex += 1;
        Debug.Log(correct);
        if (iIndex <= ques)

        {
            
            show_question = questionlist[iIndex].class_question;
            show_answer   = questionlist[iIndex].class_answer;
            show_option1  = questionlist[iIndex].class_option1;
            show_option2  = questionlist[iIndex].class_option2;
            show_option3  = questionlist[iIndex].class_option3;
            show_option4  = questionlist[iIndex].class_option4;


            question.text = show_question.ToString();
            option1.text = show_option1.ToString();
            option2.text = show_option2.ToString();
            option3.text = show_option3.ToString();
            option4.text = show_option4.ToString();
            
            infoAnswer.text = "Correct Answers "+correct.ToString () + " of " + ques.ToString()+ " Questions.";
        }
        else
        {


            points = 100 * (correct / ques);
            Finish = Mathf.RoundToInt(points);

            if (Finish > PlayerPrefs.GetInt("Finish" + iIndex.ToString()))
            {
                PlayerPrefs.SetInt("Finish" + iIndex.ToString(), Finish);
                PlayerPrefs.SetInt("correct" ,correct);
            }


            PlayerPrefs.SetInt("FinishTemp" + iIndex.ToString(), Finish);
            PlayerPrefs.SetInt("correctTemp" ,correct);

            Finishhh();

        }
        //int i = questionlist.Count;

        //int index = myList.Where<Person>( x => return x.Age == 20; ).Select<Person,int>( x => 
        //myList.IndexOf(x)).Single<int>();
        //for (var i = 0; i < myMoney.Count; i++) {
        //Console.WriteLine("Amount is {0} and type is {1}", myMoney[i].amount, myMoney[i].type);
        //}

        //Debug.Log("question  "+questionlist[iIndex].class_question);
        //Debug.Log("answer  "  +questionlist[iIndex].class_answer);   
        //Debug.Log(" "         +questionlist[iIndex].class_option1);  
        //Debug.Log(" "         +questionlist[iIndex].class_option2);  
        //Debug.Log(" "         +questionlist[iIndex].class_option3);  
        //Debug.Log(" "         +questionlist[iIndex].class_option4);  

        //object o = questionlist[iIndex];
        //



    }
    public void Finishhh()
    {
        SceneManager.LoadScene(18);
    }

    public void onclick1()
    {
        if(show_answer.Equals(show_option1))
        {
            Debug.Log("you won");
            correct += 1;
        }
        else
        {
            Debug.Log("you lose");
        }
        showquestion();
    }
    public void onclick2()
    {
        if(show_answer.Equals(show_option2))
        {
            Debug.Log("you won");
            correct += 1;
        }
        else
        {
            Debug.Log("you lose");
        }
        showquestion();
    }
    public void onclick3()
    {
        if(show_answer.Equals(show_option3))
        {
            Debug.Log("you won");
            correct += 1;
        }
        else
        {
            Debug.Log("you lose");
        }
        showquestion();
    }
    public void onclick4()
    {
        if(show_answer.Equals(show_option4))
        {
            Debug.Log("you won");
            correct += 1;
        }
        else
        {
            Debug.Log("you lose");
        }
        showquestion();
    }
}