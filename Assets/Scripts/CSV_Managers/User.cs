using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


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
    public void SetUID(int uId) { uData.uId = uId; }
    //File path
    string path = "CSV/User";
    public string _path { get { return path; } }
    //CSV File Keys
    string[] keys = { "ID", "PASSWORD", "UID", "NICKNAME", "ACCOUNTLV" };

    //Unity Functions
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Class Public Functions
    
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
    public void ChangeNickname(string nickname)
    {
        uData.nickname = nickname;
        //Write
    }

    //Class Private Functions
    string[] StringArr_NewUser(CSVData.User newUser)
    {
        string[] newData = new string[5];
        
        newData[0] = newUser.id;                     //Id
        newData[1] = newUser.password;               //Password
        newData[2] = newUser.uId.ToString();         //UId
        newData[3] = newUser.nickname;               //Nickname
        newData[4] = newUser.accountLv.ToString();   //AccountLv
        
        return newData;
    }

    //CSV Functions
    public bool Read_User()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);

        int cur_id = uData.uId - 1;   //UID = 1 ~, Save Index = 0 ~

        //Exception Handling
        if (!ExceptionHandling_Read(data, cur_id)) return false;

        uData.uId = (int)data[cur_id]["UID"];
        uData.nickname = data[cur_id]["NICKNAME"].ToString();
        uData.accountLv = (int)data[cur_id]["ACCOUNTLV"];

        User_Character.Instance().Read_User_Character();

        return true;
    }
    public bool Write_Add_User(List<Dictionary<string, object>> data, CSVData.User newUser)
    {
        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };
        
        //Set Values
        for(int idx_Data = 0; idx_Data <= data.Count; idx_Data++)
        {
            if (idx_Data >= data.Count)
            {
                //New Data
                allData.Add(StringArr_NewUser(newUser));
                break;
            }

            //Old data
            string[] newData = new string[5];   //Id, Password, UId, Nickname, AccountLv
            
            for(int idx_Keys = 0; idx_Keys < keys.Length; idx_Keys++)
                newData[idx_Keys] = data[idx_Data][keys[idx_Keys]].ToString();

            //Add string[] data
            allData.Add(newData);
        }

        //Create User_Character csv file
        if (!User_Character.Instance().Write_Add_User_Character(newUser.uId))
            return false;

        //Create User csv data
        CSVWriter.Write(path, allData);
        return true;
    }
    public bool Write_Modify_User()
    {
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
