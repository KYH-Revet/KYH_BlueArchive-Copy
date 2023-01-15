using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class User_Character
{
    //File path
    static string path = "CSV/User_Character/User_Character_"; //User_Character_N; N = UID
    public static string _path { get { return path; } }
    //CSV File Keys
    static string[] keys = { "CID", "LV", "EXP", "POSSESION", "STAR" };

    //CSV Functions
    public static Dictionary<int, CSVData.User_Character> Read_User_Character(int uId)
    {
        //Read file
        List<Dictionary<string, object>> data = CSVReader.Read(path + uId.ToString());

        //Exception Handling
        if (data == null) { Debug.Log("\"" + path + uId.ToString() + "\" 파일이 없습니다."); return null; }

        Dictionary<int, CSVData.User_Character> uCharacters = new Dictionary<int, CSVData.User_Character>();
        for (int line = 0; line < data.Count; line++)
        {
            //Get Character Id in this line
            int cId = (int)data[line]["CID"];

            //Exception Handling (Current id is already have)
            if (uCharacters.ContainsKey(cId))   //Dictionary Key = 1 ~
            {
                Debug.LogError("에러 위치 \"User_Character.Add()\", 이미 등록되어있는 cid 입니다.]///[등록되어있는 캐릭터] cid: " + cId + ", 이름: " + Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].name);
                continue;
            }

            //Character[cId]'s data
            CSVData.User_Character chaData = new CSVData.User_Character
                (
                                        cId,
                    (int)               data[cId]["LV"],
                    (int)               data[cId]["EXP"],
                    Convert.ToBoolean(  data[cId]["POSSESION"]),
                    (int)               data[cId]["STAR"]
                );
            
            uCharacters.Add(cId, chaData);
        }
        return uCharacters;
    }
    public static bool Write_Add_User_Character(int uId)
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
        
        for (int i = 0; i < dic_Character.dictionary_size; i++)
        {
            //Current charcater info
            CSVData.Character_Info info = dic_Character.dictionary_CharacterInfo[i+1];

            string[] data = new string[5];
            data[0] = i.ToString();               //CID
            data[1] = "1";                        //Lv
            data[2] = "0";                        //EXP
            data[3] = false.ToString();           //Possesion
            data[4] = info.star_Basic.ToString(); //Star
            update.Add(data);
        }
        
        //Write CSV File
        CSVWriter.Write(path + uId.ToString(), update);

        return true;
    }
    public static bool Write_Modify_User_Character(int uId, int cId, CSVData.User_Character modified_Data)
    {
        //current user's file path
        string cur_path = path + uId.ToString();

        //Exception Handling (Not have a file)
        List<Dictionary<string, object>> data = CSVReader.Read(cur_path);
        if (data == null)
        {
            Debug.Log("\"" + path + uId.ToString() + "\" 수정할 파일이 존재하지 않습니다.");
            return false;
        }

        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };

        //Set Values
        for (int line = 0; line < data.Count; line++)
        {
            string[] newData = new string[keys.Length];     //CID, LV, EXP, POSSESION, STAR

            if ((int)data[line]["CID"] == cId)  //New Data
            {
                newData = StringArr_User_Character(modified_Data);
            }
            else                                //Old Data
            {
                for (int i = 0; i < keys.Length; i++)
                    newData[i] = data[line][keys[i]].ToString();
            }

            //Add string[] data
            allData.Add(newData);
        }

        //Modify csv file
        CSVWriter.Write(cur_path, allData);
        return true;
    }
    public static List<CSVData.User_Character> Search_Users_Each_Characters(int uId, List<int> cIds)
    {
        //Read CSV File
        List<Dictionary<string, object>> data = CSVReader.Read(path + uId.ToString());

        //Exception Handling (data is Exist)
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

            //Exception Handling (i is correct character id?)
            if (cId < 0 || (int)data[cId - 1]["CID"] != cId)   //CID : 1 ~, Data Index : 0 ~
            {
                Debug.Log("존재하지 않는 Character ID입니다.");
                continue;
            }

            CSVData.User_Character chaData = new CSVData.User_Character //cIds[i] - 1;(CID : 1 ~, Data Index : 0 ~)
                (
                    cId,
                    (int)data[cId]["LV"],
                    (int)data[cId]["EXP"],
                    (bool)data[cId]["POSSESION"],
                    (int)data[cId]["STAR"]
                );

            target_User_Character.Add(chaData);
        }
        return target_User_Character;
    }

    //Class Sub Functions
    static string[] StringArr_User_Character(CSVData.User_Character user_Character)
    {
        string[] arr = new string[keys.Length];

        arr[0] = user_Character.cId.ToString();         //Character idx
        arr[1] = user_Character.cLv.ToString();         //Character lv
        arr[2] = user_Character.cExp.ToString();        //Character exp
        arr[3] = user_Character.possesion.ToString();   //Possesion
        arr[4] = user_Character.star.ToString();        //Character Star

        return arr;
    }

    //Debug Functions
    public static void Debug_User_Character(CSVData.User user)
    {
        int uId = user.uId;

        List<Dictionary<string, object>> data = CSVReader.Read(path + uId.ToString());
        if(data == null)
        {
            Debug.Log("Data가 존재하지 않는 입니다. Path : " + path + uId.ToString());
            return;
        }

        Dictionary<int, CSVData.User_Character> uCharacters = Read_User_Character(uId);

        Debug.Log("User Characters]");
        //Key of uCharacters(Dictionary<int cid, User_Character data>) is start from 1
        for (int cId = 0; cId < uCharacters.Count; cId++)
        {
            Debug.Log("CID : "  + uCharacters[cId].cId  + " \tLV : "         + uCharacters[cId].cLv
                + " \tExp : "   + uCharacters[cId].cExp + " \tPossesion : " + uCharacters[cId].possesion
                + " \tStar : "  + uCharacters[cId].star );
        }
    }
    public static void Debug_User_Character(Dictionary<int, CSVData.User_Character> uCharacters, int maxIdx)
    {
        for (int i = 0; i < maxIdx; i++)
        {
            if (!uCharacters.ContainsKey(i)) continue;

            Debug.Log("CID : "  + uCharacters[i].cId    + " \tCLV : "           + uCharacters[i].cLv
                + " \tCEXP : "  + uCharacters[i].cExp   + " \t POSSESTION : "   + uCharacters[i].possesion
                + " \tSTAR : "  + uCharacters[i].star);
        }
    }
    public static void Debug_User_Character(int uId, List<CSVData.User_Character> uCharacters)
    {
        for (int i = 0; i < uCharacters.Count; i++)
        {
            Debug.Log("UID : " + uId +
                "\tCID : " + uCharacters[i].cId + "\tCLV : " + uCharacters[i].cLv + " \tCEXP :" + uCharacters[i].cExp);
        }
    }
    public static void Debug_Search_Character()
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
    static void NewKey()
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
