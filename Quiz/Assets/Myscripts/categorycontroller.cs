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
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public class categorycontroller : MonoBehaviour
{
    public Text errorcheck;
    public string category;
    string catval;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    public class categoriess
    {

        public string categoryname;

        public categoriess(string categgory)
        {
            this.categoryname = categgory;
        }
    }

    public class academic
    {

        public string categoryname;

        public academic(string academiccat)
        {
            this.categoryname = academiccat;
        }
    }

    public class getgenerals
    {
        public int g_id;
        public string g_name;

        public getgenerals(int i,string name)
        {
            this.g_id = i;
            this.g_name = name;
        }
    }

    private DatabaseReference mDatabaseRef;

    public GameObject maincatcanvas;
    public GameObject genralcatcanvas;

    public GameObject academiccatcanvas;
    public GameObject mathscanvas;

    public string id;
    public string categoryname;
    public int sizer = 2;
    public GameObject button;

    private GameObject btn;

    public RectTransform ParentPanel;
    public RectTransform acadParentPanel;

    public String catt = "";
    public String academy = "";

    public String catgettter;

    public DataSnapshot snapshot;

    public string[] catarray;
    int i = 0;
    List<categoriess> catlist = new List<categoriess>();

    List<academic> acad = new List<academic>();
    public int counter = 0;

    public int generalcat = 0;
    public int acadcat = 0;
    public long getgeneralcat = 0;
    public long getacadcat = 0;
    string sqlQuery;
    string conn;

    int counter1;
    int counter2;

    
    // Start is called before the first frame update
    void Start()
    {   
        ///PlayerPrefs.DeleteKey("counter2");
        //PlayerPrefs.DeleteAll();
        counter1 = PlayerPrefs.GetInt("counter1");
        counter2 = PlayerPrefs.GetInt("counter2");

        string[] catarray = new string[] { };
        if (Application.platform != RuntimePlatform.Android)
        {
        conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Database.db"; //Path to database.
        if (conn != null)
        {

            Debug.Log(conn);
            errorcheck.text = conn;

        }
            
        }
        else
        {
            //conn = string.Format("{0}/{1}", Application.persistentDataPath, "/StreamingAssets/Database.db");
            //conn = "URI= file:jar:" + Application.dataPath + "!/assets/" + "/StreamingAssets/Database.db";
            //conn = "URI=file:" + System.IO.Path.Combine(Application.streamingAssetsPath,"/StreamingAssets/Database.db"); 
            
            conn = Application.persistentDataPath + "/StreamingAssets/Database.db";
            errorcheck.text = conn;
             if(!File.Exists(conn))
             {
                 
                 WWW load = new WWW ("jar:file://" + Application.dataPath + "!/assets/StreamingAssets/" + "Database.db"); 
                 errorcheck.text = "conncection load  " +load;
                 while (!load.isDone){}
 
                 File.WriteAllBytes (conn, load.bytes);
                 errorcheck.text = "conncection  " +conn;
             } errorcheck.text = "into if";
        }
        
        

        Debug.Log("load genral ");
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://palsbit-ba513.firebaseio.com/");
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testapp-d010c.firebaseio.com/");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        ///Debug.Log("into the debug");

        dbInstance.GetReference("Category").OrderByKey().GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                //Debug.Log("into the debug 22");
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                snapshot = task.Result;
                //Debug.Log(snapshot);
                //Debug.Log("value of snapshot  " + snapshot.ChildrenCount);
                getgeneralcat = snapshot.ChildrenCount;
                Debug.Log("Counter 1 value   "+counter1);
                Debug.Log("Snapshot 1 value   "+getgeneralcat);
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;

                    catt = dictUser["id"].ToString();
                    insert_generalcat(catt);    

                    //catlist.Add(new categoriess(catt));
                    //string arr = dictUser["id"].ToString();
                    //categoryarray[counter] = arr;
                    Debug.Log("value of dict   " + dictUser["id"]);
                }
            }
        });


        dbInstance.GetReference("Academic").OrderByKey().GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                //Debug.Log("into the debug 22");
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                snapshot = task.Result;
                getacadcat = snapshot.ChildrenCount;
                Debug.Log("Counter 2 value   "+counter2);
                Debug.Log("Snapshot 2 value   "+getacadcat);
                //Debug.Log(snapshot.ChildrenCount);
                
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;

                    academy = dictUser["ac_id"].ToString();
                    insert_acadcat(academy);
                    //acad.Add(new academic(academy));
                    //string arr = dictUser["id"].ToString();
                    //categoryarray[counter] = arr;
                    Debug.Log("value of dict   " + dictUser["ac_id"]);
                }
            }
        });
    }


    //start end
    public Dictionary<string, System.Object> ToDictionary()
    {
        Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
        result["id"] = id;
        //result["name"] = categoryname;



        return result;
    }
    public void gotogeneral()
    {

        for (int i = 1; i <= counter; i++)
        {

            GameObject goButton = (GameObject)Instantiate(button);
            Debug.Log("working loop");
            button.transform.position = ParentPanel.transform.position;
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            // ButtonClicked();
            //sizer = sizer + 2;
            // ButtonClicked(tempInt);
            //tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
        maincatcanvas.gameObject.SetActive(false);
        genralcatcanvas.gameObject.SetActive(true);
        academiccatcanvas.gameObject.SetActive(false);
        mathscanvas.gameObject.SetActive(false);
    }

    void ButtonClicked()
    {
        //Debug.Log ("Button clicked = " );
        this.GetComponent<Text>();
        Text ButtonText = this.button.GetComponentInChildren<Text>();
        ButtonText.text = catt.ToString();
    }
    // Update is called once per frame
    void Update()
    {
            PlayerPrefs.SetInt("counter1",counter1);
            PlayerPrefs.SetInt("counter2",counter2);

            
    }
    public void onclick()
    {   
        int i;
        
        i = gameObject.GetComponent<assignnumbertobtn>().count;
        catval = catlist[i].categoryname;

        Debug.Log("your category is   "+catval);
        //assignnumbertobtn btn = new assignnumbertobtn();
       

        SceneManager.LoadScene(2);
    }


    public void academiccat()
    {
        
            using (dbconn = new SqliteConnection("URI=file:" + conn))
        {
            dbconn.Open(); //Open connection to the database."SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            dbcmd = dbconn.CreateCommand();//"SELECT * FROM myTable WHERE column1 = "+ someValue,
            //sqlQuery = "SELECT * " + "FROM Questions "+ "where  Level" = '"++"' ;// table name
            sqlQuery = "SELECT * FROM Academic_Category" ;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string acadmeic = reader.GetString(1);

                acad.Add(new academic(acadmeic));   
                //Debug.Log("value= " + id + "  name =" + name + "  Eamil =" + Email + "   Phone" + Phone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
        
            foreach (academic acadm in acad)
            {

                Debug.Log(acadm.categoryname);

                GameObject goButton = (GameObject)Instantiate(button);
                button.transform.position = acadParentPanel.transform.position;
                goButton.transform.SetParent(acadParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);
                goButton.transform.position = new Vector2(0, 147);
                Button tempButton = goButton.GetComponent<Button>();
                GetComponent<Text>();
                Text ButtonText = button.GetComponentInChildren<Text>();
                ButtonText.text = acadm.categoryname;
                acadcat += 1;

            }
        
        //sizer = sizer + 2;
        // ButtonClicked(tempInt);
        //tempButton.onClick.AddListener(() => ButtonClicked(tempInt));

        maincatcanvas.gameObject.SetActive(false);
        genralcatcanvas.gameObject.SetActive(false);
        academiccatcanvas.gameObject.SetActive(true);
    }

    public void gotomaincat()
    {
        maincatcanvas.gameObject.SetActive(true);
        genralcatcanvas.gameObject.SetActive(false);
        academiccatcanvas.gameObject.SetActive(false);
        mathscanvas.gameObject.SetActive(false);
    }

    public void gotochildinfo()
    {
        SceneManager.LoadScene(4);
    }
    public void mathsubcat()
    {
        maincatcanvas.gameObject.SetActive(false);
        genralcatcanvas.gameObject.SetActive(false);
        academiccatcanvas.gameObject.SetActive(false);
        mathscanvas.gameObject.SetActive(true);
    }

    public void gobacktoacad()
    {
        maincatcanvas.gameObject.SetActive(false);
        genralcatcanvas.gameObject.SetActive(false);
        academiccatcanvas.gameObject.SetActive(true);
        mathscanvas.gameObject.SetActive(false);

    }


    public void loadgeneral()
    {
        
        using(dbconn = new SqliteConnection("URI=file:" +conn))
        {
            errorcheck.text = "Database found   " +dbconn.State;
        
            dbconn.Open();           
            errorcheck.text = "Data open";
            using (IDbCommand dbCmd = dbconn.CreateCommand ()) 
            {
            //Open connection to the database."SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            //dbcmd = dbconn.CreateCommand();//"SELECT * FROM myTable WHERE column1 = "+ someValue,
            
            //sqlQuery = "SELECT * " + "FROM Questions "+ "where  Level" = '"++"' ;// table name
            sqlQuery = String.Format("SELECT * FROM GeneralCategories" );
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string generalcat = reader.GetString(1);

                catlist.Add(new categoriess(generalcat));
                
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            }
        }
        
        
            foreach (categoriess cat in catlist)
            {   
                generalcat +=1;
                GameObject goButton = (GameObject)Instantiate(button);
                goButton.GetComponent<assignnumbertobtn>().count = generalcat;
                button.transform.position = ParentPanel.transform.position;
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);
                goButton.transform.position = new Vector2(0, 147);
                Button tempButton = goButton.GetComponent<Button>();
                GetComponent<Text>();
                Text ButtonText = button.GetComponentInChildren<Text>();
                ButtonText.text = cat.categoryname;
                //button.GetComponentInChildren();
                Debug.Log("counter  "+assignnumbertobtn.counter);
                
            }
            
        //Buttoncreation();
        maincatcanvas.gameObject.SetActive(false);
        genralcatcanvas.gameObject.SetActive(true);
        academiccatcanvas.gameObject.SetActive(false);
        mathscanvas.gameObject.SetActive(false);
    }

    void Buttoncreation()
    {
        Debug.Log("into button creation");
        

        for (int i = 1; i <= counter; i++)
        {
            GameObject goButton = (GameObject)Instantiate(button);
            Debug.Log("working loop");
            button.transform.position = ParentPanel.transform.position;
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            ButtonClicked();
            //sizer = sizer + 2;
            // ButtonClicked(tempInt);
            //tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
}

    public void insert_generalcat(string categoryy_name)
    {   
      //  if(counter1 != getgeneralcat && counter1 < getgeneralcat)
      //  {
            errorcheck.text = "into insertion";
           counter1 = counter1+1;
           using (dbconn = new SqliteConnection("URI=file:" + conn))
        {   
            errorcheck.text = "comming till here     " +dbconn;
            
            dbconn.Open(); //Open connection to the database.
            errorcheck.text = "opend" +dbconn.State;
            dbcmd = dbconn.CreateCommand();
            string sqlQuery = string.Format("insert into GeneralCategories(Cat_name) values (\"{0}\")", categoryy_name);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            Debug.Log("Data entered");
            errorcheck.text = "data inserted";
        }
           
      //  }
        //else
        //{
        //    Debug.Log("Values added   " +counter1);
        //}
    }

    public void insert_acadcat(string categoryy_name)
    {       
            errorcheck.text = "into acad";
        using (dbconn = new SqliteConnection("URI=file:" + conn))
       // if(counter2 != getacadcat && counter2 < getacadcat)
       // {
           errorcheck.text = "enetering  into db 1";
            counter2 = counter2+1;
            using (dbconn = new SqliteConnection(conn))
        {
            errorcheck.text = "enetering  into db 2  " +dbconn.State.ToString();
            dbconn.Open(); //Open connection to the database.
            
            dbcmd = dbconn.CreateCommand();
            string sqlQuery = string.Format("insert into Academic_Category (Cat_name) values (\"{0}\")", categoryy_name);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            Debug.Log("Data entered");
      //  }
        }
       // else
       // {
       //         Debug.Log("Values added   " +counter2);
       // }       
    
    }
    public void checkvalues(int value)
    {
        Debug.Log(value);
        category = catlist[0].categoryname;
        
        Debug.Log("your category is   "+category);
    }



    }



