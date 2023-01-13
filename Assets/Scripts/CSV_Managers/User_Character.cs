using System;
using System.Collections.Generic;
using UnityEngine;

public class User_Character : MonoBehaviour
{
    //Singleton
    static User_Character instance;
    public static User_Character Instance()
    {
        if (instance == null)
            instance = new User_Character();
        return instance;
    }

    //Dictionary of User's Characters
    Dictionary<int, CSVData.User_Character> uCharacters; //Key = cId
    public Dictionary<int, CSVData.User_Character> user_Characters { get { return uCharacters; } }
    
    //File path
    string path = "CSV/User_Character/User_Character_"; //User_Character_N; N = UID
    public string _path { get { return path; } }
    //CSV File Keys
    string[] keys = { "CID", "LV", "EXP", "POSSESION", "STAR" };

    //Unity Functions
    void Awake()
    {
        instance = this;
        uCharacters = new Dictionary<int, CSVData.User_Character>();
        DontDestroyOnLoad(gameObject);

        //Debug_User_Character();
        //Debug_User_Character(1, Search_Users_Each_Characters(1, new List<int> { 1, 4, 2, 3 }));
    }
    private void Update()
    {
        //Debug_Search_User();
        //Debug_Search_Character();
    }

    //CSV Functions
    public bool Read_User_Character()
    {
        List<Dictionary<string, object>> data = Read_Path();
        //Exception Handling
        if (data == null || data.Count <= 0)
        {
            Debug.LogError("User_Character의 정보가 없습니다!");
            return false;
        }

        for (int line = 0; line < data.Count; line++)
        {
            //Get Character Id in this line
            int cId = (int)data[line]["CID"];

            //Exception Handling (Current id is already included)
            if (uCharacters.ContainsKey(cId))   //Dictionary Key = 1 ~
            {
                Debug.LogError("에러 위치 \"User_Character.Add()\", 이미 등록되어있는 cid 입니다.]///[등록되어있는 캐릭터] cid: " + cId + ", 이름: " + Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].name);
                continue;
            }

            //Character[cId]'s data
            CSVData.User_Character chaData = new CSVData.User_Character //CID = 1 ~, Data Index = 0 ~
                (
                    cId,
                    (int)data[cId - 1]["LV"],
                    (int)data[cId - 1]["EXP"],
                    Convert.ToBoolean(data[cId - 1]["POSSESION"]),
                    (int)data[cId - 1]["STAR"]
                );
            
            uCharacters.Add(cId, chaData);
        }
        return true;
    }
    List<Dictionary<string, object>> Read_Path()
    {
        //Exception Handling
        if (User.Instance().user_Data.uId == -1)
            return null;

        //Return a data
        return CSVReader.Read(path + User.Instance().user_Data.uId.ToString());
    }
    public bool Write_Add_User_Character(int uId)
    {
        //Exception Handling (already have file)
        if (CSVReader.Read(path + uId.ToString()) != null)
        {
            Debug.Log("\"" + path + uId.ToString() + "\" 파일이 이미 존재합니다.");
            return false;
        }

        //Set Keys
        List<string[]> update = new List<string[]>() { keys };

        //Set Values (all Character)
        Dictionary_CharacterInfo dic_Character = Dictionary_CharacterInfo.Instance();
        Debug.Log(dic_Character.dictionary_size);
        for (int i = 0; i < dic_Character.dictionary_size; i++)
        {
            string[] values = new string[5];
            values[0] = i.ToString();       //CID
            values[1] = "1";                //Lv
            values[2] = "0";                //EXP
            values[3] = false.ToString();   //Possesion
            values[4] = "3";                //Star
            update.Add(values);
        }
        
        //Write CSV File
        CSVWriter.Write(path + uId.ToString(), update);

        return true;
    }
    
    //Class Functions
    List<CSVData.User_Character> Search_Users_Each_Characters(int uId, List<int> cIds)
    {
        //Read CSV File
        List<Dictionary<string, object>> data = CSVReader.Read(path + uId.ToString());

        //Exception Handling
        if (data == null || data.Count <= 0)
        {
            Debug.LogError("User_Character의 정보가 없습니다!");
            return null;   //target_User_Character.Count <= 0
        }

        List<CSVData.User_Character> target_User_Character = new List<CSVData.User_Character>();

        //Get Characters
        for (int i = 0; i < cIds.Count; i++)
        {
            int cId = cIds[i];

            //Exception Handling            
            if (cId <= 0 || (int)data[cId - 1]["CID"] != cId)   //CID : 1 ~, Data Index : 0 ~
            {
                Debug.Log("존재하지 않는 Character ID입니다.");
                continue;
            }

            CSVData.User_Character chaData = new CSVData.User_Character //cIds[i] - 1;(CID : 1 ~, Data Index : 0 ~)
                (
                    cId,
                    (int)data[cId - 1]["LV"],
                    (int)data[cId - 1]["EXP"],
                    (bool)data[cId - 1]["POSSESION"],
                    (int)data[cId - 1]["STAR"]
                );

            target_User_Character.Add(chaData);
        }
        return target_User_Character;
    }

    //Debug Functions
    void Debug_User_Character()
    {
        //Key of uCharacters(Dictionary<int cid, User_Character data>) is start from 1
        for (int i = 1; i <= uCharacters.Count; i++)
        {
            Debug.Log("UID : " + User.Instance().user_Data.uId +
                "\tCID : " + uCharacters[i].cId + "\tCLV : " + uCharacters[i].cLv + " \tCEXP :" + uCharacters[i].cExp);
        }
    }
    void Debug_User_Character(int uId, List<CSVData.User_Character> uCharacters)
    {
        for (int i = 0; i < uCharacters.Count; i++)
        {
            Debug.Log("UID : " + uId +
                "\tCID : " + uCharacters[i].cId + "\tCLV : " + uCharacters[i].cLv + " \tCEXP :" + uCharacters[i].cExp);
        }
    }
    void Debug_Search_User()
    {
        CSVData.User newUser = new CSVData.User();
        int uid = -1;

        //Input
        if (Input.GetKeyDown(KeyCode.Keypad1)) uid = 1;
        else if (Input.GetKeyDown(KeyCode.Keypad2)) uid = 2;
        else if (Input.GetKeyDown(KeyCode.Keypad3)) uid = 3;
        if (uid == -1) return;

        newUser = User.Instance().Search_User(uid);
        if (newUser.uId != -1)
            User.Instance().Debug_User(newUser);
    }
    void Debug_Search_Character()
    {
        List<CSVData.User_Character> newUser = new List<CSVData.User_Character>();
        List<int> cIds = new List<int>();

        //cIds.Add(0);

        int uid = -1;

        //Input
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            uid = 1;
            cIds.Add(1);
            cIds.Add(2);
            cIds.Add(3);
            cIds.Add(4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            uid = 2;
            cIds.Add(4);
            cIds.Add(3);
            cIds.Add(2);
            cIds.Add(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            uid = 3;
            cIds.Add(2);
            cIds.Add(1);
            cIds.Add(4);
            cIds.Add(0);
        }
        if (uid == -1) return;

        Debug.Log("캐릭터 검색 시작");
        newUser = Search_Users_Each_Characters(uid, cIds);
        if (newUser.Count <= 0) { Debug.Log("검색된 캐릭터들이 없습니다"); return; }
        for (int i = 0; i < newUser.Count; i++)
        {
            Dictionary<int, CSVData.Character_Info> newDictionary = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo;
            Debug.Log("UID : " + uid + "\tCID : " + newUser[i].cId + "\tName : " + newDictionary[cIds[i]].name + "\t");
            //Dictionary_CharacterInfo.Instance().Debug_CharacterInfoInDictionary(newUser[i].uId);
        }
    }

    //Add Key in CSV
    void NewKey()
    {
        string[] newValue = new string[2];
        newValue[0] = true.ToString();  //Possesion
        newValue[1] = "3";              //Star

        for(int file = 1; file < 100; file++)
        {
            //UID 1~N data
            List<Dictionary<string, object>> data = CSVReader.Read(path + (file).ToString());
            if(data == null || data.Count <= 0) { /*Debug.Log("데이터 없음");*/ continue; }

            List<string[]> update = new List<string[]>() { keys };
            for(int i = 0; i < data.Count; i++)
            {
                string[] values = new string[5];
                values[0] = data[i][keys[0]].ToString();
                values[1] = data[i][keys[1]].ToString();
                values[2] = data[i][keys[2]].ToString();
                values[3] = newValue[0];
                values[4] = newValue[1];
                update.Add(values);
            }
            string cur_path = path + file.ToString();
            CSVWriter.Write(cur_path, update);
        }
    }
}
