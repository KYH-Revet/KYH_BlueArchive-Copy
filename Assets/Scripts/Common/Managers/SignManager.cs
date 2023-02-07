using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    public bool AutoLogin;
    private void Awake()
    {
        if (AutoLogin)
        {
            Login("Test1", "pw1");
            Load_User_Character();
        }
        //Save this gameobject
        DontDestroyOnLoad(gameObject);
    }

    //User Data
    static CSVData.User uData;
    public static CSVData.User user_Data { get { return uData; } }

    //Dictionary of User's Characters
    static Dictionary<int, CSVData.User_Character> uCharacters; //Key = cId
    public static Dictionary<int, CSVData.User_Character> user_Characters { get { return uCharacters; } }

    //Functions
    public static bool SignUp(string id, string password, string nickname)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(User._path);
        int maxUId = 0;

        //Exception Handling & Increase the max user index
        if (data == null) return false;
        if (data.Count > 0)
        {
            //중복검사
            for (int line = 0; line < data.Count; line++)
            {
                if (data[line]["ID"].ToString() == id)
                {
                    Debug.LogError("중복된 ID 입니다.");
                    return false;
                }

                //Increase the max user index
                maxUId = ((int)data[line]["UID"] > maxUId) ? (int)data[line]["UID"] : maxUId;
            }
        }

        //Sign Up
        CSVData.User newUser = new CSVData.User(id, password, maxUId + 1, nickname);

        //Write
        User.Write_Add_User(newUser);

        //Debug
        Debug.Log("새로운 회원 정보]");
        User.Debug_User(newUser);

        return true;
    }
    public static bool Login(string id, string password)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(User._path);
        if (data == null) return false;

        for (int line = 0; line < data.Count; line++)
        {
            if (data[line]["ID"].ToString() == id)
            {
                if (data[line]["PASSWORD"].ToString() == password)
                {
                    Debug.Log("로그인 성공 UID 배정 : " + data[line]["UID"].ToString());

                    //Read User data
                    uData = User.Read_User((int)data[line]["UID"]);
                    if(uData.uId == -1) //Exception handling
                    {
                        Debug.LogError("로그인 실패] 유저를 불러오는데 실패했습니다.");
                        return false;
                    }
                    DataInitialize.load_User = true;

                    //Success the login
                    DataInitialize.login = DataInitialize.load_User;
                    return DataInitialize.login;
                }
            }
        }

        Debug.Log("등록되지 않은 ID 입니다.");
        return false;
    }
    public static bool Load_User_Character()
    {
        uCharacters = User_Character.Read_User_Character(uData.uId);
        if (uCharacters.Count <= 0)
        {
            Debug.LogError("Load Fails : UID[" + SignManager.user_Data.uId + "] User_Character");
            return false;
        }

        Debug.Log("Complete Load : UID[" + SignManager.user_Data.uId + "] User_Character");
        return true;
    }

    public static bool Modyfy_Nickname(string nickname)
    {
        string origin_Nickname = uData.nickname;
        uData.nickname = nickname;

        if (User.Write_Modify_User(uData))
            return true;

        uData.nickname = origin_Nickname;
        return false;
    }

    //Debug Functions
    void Debug_UserData()
    {
        User.Debug_User(uData);
        User_Character.Debug_User_Character(uCharacters, uCharacters.Count);
    }

    void Test()
    {
        /*
        //Work Test
        SignIn("Test1", "pw1");
        Debug_UserData();
        */  //ex) Login

        /*
        uData.nickname = "Master";
        User.Write_Modify_User(uData);
        Debug_UserData();
        */  //ex) Modify User data

        /*
        int cId = 3;
        CSVData.User_Character newData = uCharacters[cId];
        newData.possesion = false;
        newData.star = 1;
        uCharacters[cId] = newData;
        User_Character.Write_Modify_User_Character(uData.uId, cId, uCharacters[cId]);
        Debug_UserData();
        */ //ex) Modify User Character data

    }
}
