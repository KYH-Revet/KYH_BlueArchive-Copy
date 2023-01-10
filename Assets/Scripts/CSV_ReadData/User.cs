using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private int uId;

    //Unity Functions
    void Awake()
    {
        instance = this;
        Debug_User(uData);
        Login("Test3", "pw3");
        Debug_User(uData);
        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    public bool Login(string id, string password)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["ID"].ToString() == id)
            {
                if (data[i]["PASSWORD"].ToString() == password)
                {
                    Debug.Log("로그인 성공 UID 배정 : " + data[i]["UID"].ToString());
                    uId = (int)data[i]["UID"];
                    return Read_User();
                }
            }
        }

        Debug.Log("등록되지 않은 ID 입니다.");
        return false;
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

        uData.uId = (int)data[uId - 1]["UID"];
        uData.nickname = data[uId - 1]["NICKNAME"].ToString();
        uData.accountLv = (int)data[uId - 1]["ACCOUNTLV"];
        return uData;
    }

    //CSV Functions
    bool Read_User()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);

        int cur_id = uId - 1;   //UID = 1 ~, Save Index = 0 ~

        //Exception Handling
        if (!ExceptionHandling_Read(data, cur_id)) return false;

        uData.uId = (int)data[cur_id]["UID"];
        uData.nickname = data[cur_id]["NICKNAME"].ToString();
        uData.accountLv = (int)data[cur_id]["ACCOUNTLV"];
        return true;
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
