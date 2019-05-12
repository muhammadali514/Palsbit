using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardEntry 
    {

    public string fid; 
    public string username ;

    public string _name ;

    public string agee;

    public string standdd;
    

    public LeaderboardEntry() {
    }

    
    public LeaderboardEntry(string fatherid,string username,string name, string age, string stand_grad) 
    {
        this.fid = fatherid;
        this.username = username;
        this._name = name;
        this.agee = age;
        this.standdd = stand_grad;
    }
        public Dictionary<string, System.Object> ToDictionary() 
        {
        Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
        result["fatherid"] = fid;
        result["username"] = username;
        result["name"] = _name;
        result["age"] = agee;
        result["stand"] = standdd;


        return result;
        }
}

