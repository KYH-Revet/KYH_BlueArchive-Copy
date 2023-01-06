using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using CSVData;
using System.Threading;

public class User : MonoBehaviour
{
    //Singleton
    static User instance;
    public static User Instance()
    {
        if (instance == null)
        {
            Debug.Log("instance is null");
            instance = new User();
        }
        return instance;
    }

    //User Data
    CSVData.User uData;
    public CSVData.User user_Data { get { return uData; } }
    string path = "CSV/User";

    //User ID
    public int uId { get { return user_Data.uId; } set { uId = value; } }

    //Unity Functions
    void Awake()
    {
        instance = this;
        Read_User();
        DontDestroyOnLoad(gameObject);
    }

    //Class Function
    bool Read_User()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);

        //Exception Handling
        if (!ExceptionHandling_Read(data, uId)) return false;

        uData.uId       = (int)data[uId]["UID"];
        uData.nickname  = data[uId]["NICKNAME"].ToString();
        uData.accountLv = (int)data[uId]["ACCOUNTLV"];
        return true;
    }
    public CSVData.User Search_User(int uId)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        CSVData.User uData = new CSVData.User();
        //Exception Handling
        if (!ExceptionHandling_Read(data, uId))
        {
            uData.uId = -1;
            return uData;
        }

        uData.uId       = (int)data[uId]["UID"];
        uData.nickname  = data[uId]["NICKNAME"].ToString();
        uData.accountLv = (int)data[uId]["ACCOUNTLV"];
        return uData;
    }

    //Exception Handling Functions
    bool ExceptionHandling_Read(List<Dictionary<string, object>> data, int uId)
    {
        bool found = false;
        for (int i = 0; i < data.Count; i++)
            if ((int)data[i]["UID"] == uId) { found = true; break; }
        
        if (!found) Debug.Log("등록되지 않은 User Id 입니다.");
        return found;
    }

    //Debug Functions
    public void Debug_User(CSVData.User uData)
    {
        Debug.Log(uData.uId + "\t" + uData.nickname + "\t" + uData.accountLv);
    }
}
