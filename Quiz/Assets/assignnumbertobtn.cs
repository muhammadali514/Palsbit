using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class assignnumbertobtn : MonoBehaviour
{
    List<categorycontroller.categoriess> catlist = new List<categorycontroller.categoriess>();

    List<categorycontroller.academic> acad = new List<categorycontroller.academic>();
    public static int counter;
    public string category;

    private GameObject btns;
    private Text btntext;
    string btn;
    public int count;
    public int countval;
    // Start is called before the first frame update
    void Start()
    {   
        //PlayerPrefs.DeleteAll();
        counter = count;
        

        //btns.GameObject.FindGameObjectsWithTag("btnclones");
        btns = GameObject.FindGameObjectWithTag("btnclones");
        btntext = btns.GetComponentInChildren<Text>();
    }

    public void oncreate()
    {       

        count = count+1;
        
        //btn = btntext.ToString();
        //btns.GetComponentsInChildren<Text>();
        //btn = btns.GetComponentInChildren<Text>().ToString();
        //btn = ButtonText.text;
        //Debug.Log("name of button  " +btn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclick()
    {   
        countval  = count;
        categorycontroller cat = new categorycontroller();
        Debug.Log(countval);
        cat.checkvalues(countval);
        
        
        //category = catlist[count].categoryname;
        
        //Debug.Log("your category is   "+category);
        //assignnumbertobtn btn = new assignnumbertobtn();
       

        //SceneManager.LoadScene(2);
    }
}
