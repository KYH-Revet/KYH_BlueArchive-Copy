using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    //Singleton
    static SignManager instance;
    public static SignManager Instance()
    {
        return instance = (instance == null) ? new SignManager() : instance;
    }

    private void Awake()
    {
        //Singleton
        instance = this;

        //Work Test
        SignIn("Test1", "pw1");
        Debug_UserData();

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

        //Save this gameobject
        DontDestroyOnLoad(gameObject);
    }

    //User Data
    CSVData.User uData;
    public CSVData.User user_Data { get { return uData; } }

    //Dictionary of User's Characters
    Dictionary<int, CSVData.User_Character> uCharacters; //Key = cId
    public Dictionary<int, CSVData.User_Character> user_Characters { get { return uCharacters; } }

    //Functions
    public bool SignUp(string id, string password, string nickname)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(User._path);
        int maxUId = 0;

        //Exception Handling & Increase the max user index
        if (data == null) return false;
        if (data.Count > 0)
        {
            //중복검사
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i]["ID"].ToString() == id)
                {
                    Debug.LogError("중복된 ID 입니다.");
                    return false;
                }

                //Increase the max user index
                maxUId = ((int)data[i]["UID"] > maxUId) ? (int)data[i]["UID"] : maxUId;
            }
        }

        //Sign Up
        CSVData.User newUser = new CSVData.User(id, password, maxUId + 1, nickname);
        Debug.Log("새로운 회원 정보]");
        User.Debug_User(newUser);

        //Write
        User.Write_Add_User(newUser);

        return true;
    }
    public bool SignIn(string id, string password)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(User._path);
        if (data == null) return false;

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["ID"].ToString() == id)
            {
                if (data[i]["PASSWORD"].ToString() == password)
                {
                    Debug.Log("로그인 성공 UID 배정 : " + data[i]["UID"].ToString());
                    uData = User.Read_User((int)data[i]["UID"]);                    //Read User data
                    uCharacters = User_Character.Read_User_Character(uData.uId);    //Read User Character datas
                    return true;
                }
            }
        }

        Debug.Log("등록되지 않은 ID 입니다.");
        return false;
    }

    //Debug Functions
    void Debug_UserData()
    {
        User.Debug_User(uData);
        User_Character.Debug_User_Character(uCharacters, uCharacters.Count);
    }
}
