using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class User
{
    //File path
    static string path = "CSV/User";
    public static string _path { get { return path; } }
    //CSV File Keys
    static string[] keys = { "ID", "PASSWORD", "UID", "NICKNAME", "ACCOUNTLV" };
    
    //CSV Functions
    public static CSVData.User Read_User(int uId)
    {
        //Variables for read user data
        CSVData.User uData = new CSVData.User();
        uData.uId = -1;

        //Read csv file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) return uData;

        //Search user with user id
        int user_Idx = uData.uId;
        for (int i = 0; i < data.Count; i++)
            if ((int)data[i]["UID"] == uId)
                user_Idx = i;

        //Not found user
        if (user_Idx == -1) return uData;

        //Input data without id, password
        uData.id        =       data[user_Idx][keys[0]].ToString();
        uData.password  =       data[user_Idx][keys[1]].ToString();
        uData.uId       = (int) data[user_Idx][keys[2]];
        uData.nickname  =       data[user_Idx][keys[3]].ToString();
        uData.accountLv = (int) data[user_Idx][keys[4]];
        return uData;
    }
    public static bool Write_Add_User(CSVData.User newUser)
    {
        //Read file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) return false;

        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };
        
        //Set Values
        for(int idx_Data = 0; idx_Data <= data.Count; idx_Data++)
        {
            if (idx_Data >= data.Count)
            {
                //New Data
                allData.Add(StringArr_User(newUser));
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
        if (!User_Character.Write_Add_User_Character(newUser.uId))
            return false;

        //Create User csv data
        CSVWriter.Write(path, allData);
        return true;
    }
    public static bool Write_Modify_User(CSVData.User modified_Data)
    {
        //Read file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) { Debug.LogError("Write_Modify_User(), data is null"); return false; };

        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };

        //Set Values
        for (int line = 0; line < data.Count; line++)
        {
            string[] newData = new string[5];   //Id, Password, UId, Nickname, AccountLv

            if ((int)data[line]["UID"] == modified_Data.uId)   //Modify target
            {
                newData = StringArr_User(modified_Data);
            }
            else                                        //Old data
            {
                for (int idx_Keys = 0; idx_Keys < keys.Length; idx_Keys++)
                    newData[idx_Keys] = data[line][keys[idx_Keys]].ToString();
            }

            //Add string[] data
            allData.Add(newData);
        }

        //Modify csv file
        CSVWriter.Write(path, allData);
        return true;
    }

    //Class Sub Functions
    static string[] StringArr_User(CSVData.User newUser)
    {
        string[] newData = new string[keys.Length];

        newData[0] = newUser.id;                     //Id
        newData[1] = newUser.password;               //Password
        newData[2] = newUser.uId.ToString();         //UId
        newData[3] = newUser.nickname;               //Nickname
        newData[4] = newUser.accountLv.ToString();   //AccountLv

        return newData;
    }
    //Debug Functions
    public static void Debug_User(CSVData.User uData)
    {
        Debug.Log("User]");
        Debug.Log("uId : "+ uData.uId + "\tNickname : " + uData.nickname + "\tAccountLv : " + uData.accountLv);
    }
}
