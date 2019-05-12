using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Children : MonoBehaviour
{
    public static string key1 = "";
    public static string key2 = "";
    public static string key3 = "";
    public static string key4 = "";

    public Text child1;
    public Text child2;
    public Text child3;
    public Text child4;

    public static int child1created = 0;
    public static int child2created = 0;
    public static int child3created = 0;
    public static int child4created = 0;

    // Start is called before the first frame update
    void Start()
    {
       
       
      key1 = PlayerPrefs.GetString("child1");
      key2 = PlayerPrefs.GetString("child2");
      key3 = PlayerPrefs.GetString("child3");
      key4 = PlayerPrefs.GetString("child4");
    }

    // Update is called once per frame
    public void chlid1class()
    {
            child1created = 1;
            PlayerPrefs.SetInt("child1created", child1created);
            key1 = childcreator.keygen;
            Debug.Log("val" +key1);
            PlayerPrefs.SetString("child1", key1);
            child1.text = "Child 1 created";
            
            
    }
    public void chlid2class()
    {
            child2created = 1;
            PlayerPrefs.SetInt("child2created", child2created);
            key2 = childcreator.keygen;
            Debug.Log("val" +key2);
            PlayerPrefs.SetString("child2", key2);
            child2.text = "Child 2 created";
    }
    public void chlid3class()
    {
            child3created = 1;
            PlayerPrefs.SetInt("child3created", child3created);
            key3 = childcreator.keygen;
            Debug.Log("val" +key3);
            PlayerPrefs.SetString("child3", key3);
            child3.text = "Child 3 created";
    }
    public void chlid4class()
    {   
            child4created = 1;
            PlayerPrefs.SetInt("child4created", child4created);
            key4 = childcreator.keygen;
            Debug.Log("val" +key4);
            PlayerPrefs.SetString("child4", key4);
            child4.text = "Child 4 created";
    }

    public void checkonclick()
    {
        Debug.Log("value of child 1  " +key1);
        Debug.Log("value of child 2  " +key2);
        Debug.Log("value of child 3  " +key3);
        Debug.Log("value of child 4  " +key4);
    }

    
    
}
