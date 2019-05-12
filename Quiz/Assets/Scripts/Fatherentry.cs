using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatherentry 
    {

    public string fid; 
    public string username ;

    public string _name ;

    public string countryy;

    public string email;
    

    public Fatherentry() {
    }

    
    public Fatherentry(string username,string name, string country, string email) 
    {
        //this.fid = fatherid;
        this.username = username;
        this._name = name;
        this.countryy = country;
        this.email = email;
    }
        public Dictionary<string, System.Object> ToDictionary() 
        {
        Dictionary<string, System.Object> fatherdetail = new Dictionary<string, System.Object>();
        //fatherdetail["fatherid"] = fid;
        fatherdetail["username"] = username;
        fatherdetail["name"] = _name;
        fatherdetail["age"] = countryy;
        fatherdetail["stand"] = email;


        return fatherdetail;
        }
}

