using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public class Databasemanager : MonoBehaviour
{
    String abc_question,abc_answer,abc_option1,abc_option2,abc_option3,abc_option4,abc_category,abc_Level ,abc_Standard ,abc_explanation,abc_complexity;
    string conn;
    int abc_qustionid;
    //IDbConnection conn;
    // Start is called before the first frame update
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Questions.db"; //Path to database.
        if(conn != null)
        {
            Debug.Log(conn);
        }
        conn = Application.persistentDataPath + "/dataBase.db";
             if(!File.Exists(conn))
             {
                 WWW load = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + "/Questions.db"); 
                 while (!load.isDone){}
 
                 File.WriteAllBytes (conn, load.bytes);
             }

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getquestions()
    {
        
        IDbConnection dbconnection = new SqliteConnection(conn);
        {
            dbconnection.Open();
            using(IDbCommand dbCmd = dbconnection.CreateCommand())
            {   
            
                string query = "SELECT * FROM Questions";
                dbCmd.CommandText = query;

                    using(IDataReader reader = dbCmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {   
                            Debug.Log(reader.GetString(1));
                            Debug.Log(reader.GetString(2));
                            Debug.Log(reader.GetString(3));
                            Debug.Log(reader.GetString(4));
                            Debug.Log(reader.GetString(5));
                            Debug.Log(reader.GetString(6));
                            Debug.Log(reader.GetString(7));
                            Debug.Log(reader.GetString(8));
                            Debug.Log(reader.GetString(9));
                            Debug.Log(reader.GetString(10));
                            Debug.Log(reader.GetString(11));


                        }
                        dbconnection.Close();
                        reader.Close();
                    }
            }
        }
    }

    public void savedb()
    {
        abc_qustionid   = 10;
        abc_question    = "name";
        abc_answer      = "Pakistan";
        abc_option1     = "abc";
        abc_option2     = "asasas";
        abc_option3     = "asasas";
        abc_option4     = "saasasas";
        abc_category    = "jhabhas";
        abc_Level       = "sdsa";
        abc_Standard    = "sasda"; 
        abc_explanation = "asdsd";
        abc_complexity  = "dsadsa";
        insertdata(abc_question,abc_answer,abc_option1,abc_option2,abc_option3,abc_option4,abc_category,abc_Level ,abc_Standard ,abc_explanation,abc_complexity);
        
    }

    public void insertdata(string _question,string _answer,string _option1,string _option2,string _option3,string _option4,string _category,string _Level,string _Standard,string _explanation,string _complexity)
    {
        IDbConnection dbconnection = new SqliteConnection(conn);
        {
            dbconnection.Open();
            using(IDbCommand dbCmd = dbconnection.CreateCommand())
            {                                                                                                                                       //"INSERT INTO previousMessages ")",name,email,address); "+_cipher+", "+_initialMessage+", "+_encryptedMessage+")";
            
                //string query = "INSERT INTO Questions (question,answer,option1,option2,option3,option4,category,Level,Standard,explanation,complexity) values ("+_question+", "+_answer+","+_option1+","+_option2+","+_option3+","+_option4+","+_category+","+_Level+","+_Standard+","+_explanation+","+_complexity+")";
                string query = string.Format("INSERT INTO Questions (question,answer,option1,option2,option3,option4,category,Level,Standard,explanation,complexity) VALUES (\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\")",_question,_answer,_option1,_option2,_option3,_option4,_category,_Level,_Standard,_explanation,_complexity);        
                //sqlQuery = string.Format("insert into Questions(question, answer, option1) values (\"{0}\",\"{1}\",\"{2}\")",name,email,address);        
                dbCmd.CommandText = query;

                dbCmd.ExecuteScalar();
                dbCmd.ExecuteNonQuery();
                dbconnection.Close();
                //dbCmd.CommandText = "INSERT INTO users (username , password ) VALUES (@UserName @Password)";
                //dbCmd.Parameters.Add("@UserName", DbType.String).Value = question;
                //dbCmd.Parameters.Add("@Password", DbType.String).Value = answer;
                //dbCmd.ExecuteNonQuery()
//objConn.Open(dbCmd)
                    //using(IDataReader reader = dbCmd.ExecuteReader())
                    //{
                    //    while(reader.Read())
                   //     {   
                     //       Debug.Log(reader.GetString(5));
                     //   }
                     //   dbconnection.Close();
                     //   reader.Close();
                   // }
            }
            
                
            
        }
    }
}
