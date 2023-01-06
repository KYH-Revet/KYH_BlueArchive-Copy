using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    string path = "CSV/User_Character";

    //Unity Functions
    void Awake()
    {
        instance = this;
        uCharacters = new Dictionary<int, CSVData.User_Character>();
        Read_User_Character();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //Debug_Search_User();
        //Debug_Search_Character();
    }
    //Class Functions
    bool Read_User_Character()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        //Exception Handling
        if (data.Count <= 0)
        {
            Debug.LogError("User_Character의 정보가 없습니다!");
            return false;
        }

        int uId = User.Instance().user_Data.uId;
        for (int i = 0; i < data.Count; i++)
        {
            //Sort by user id
            if ((int)data[i]["UID"] > uId)
                break;

            if ((int)data[i]["UID"] == uId)
            {
                int cId = (int)data[i]["CID"];
                //Exception Handling
                if (uCharacters.ContainsKey(cId))
                {
                    Debug.LogError("에러 위치 \"User_Character.Add()\", 이미 등록되어있는 cid 입니다.]///[등록되어있는 캐릭터] cid: " + cId + ", 이름: " + Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].name);
                    continue;
                }

                CSVData.User_Character chaData = new CSVData.User_Character();
                chaData.uId = uId;
                chaData.cId = cId;
                chaData.cLv = (int)data[i]["LV"];
                chaData.cExp = (int)data[i]["EXP"];

                uCharacters.Add(cId, chaData);
            }
        }
        return true;
    }
    List<CSVData.User_Character> Search_User_Character(int uId, List<int> cIds)
    {
        //Get User
        CSVData.User target_User = User.Instance().Search_User(uId);
        List<CSVData.User_Character> target_User_Character = new List<CSVData.User_Character>();
        
        //Read CSV File
        List<Dictionary<string, object>> data = CSVReader.Read(path);

        //Exception Handling
        if (target_User.uId == -1 || data.Count <= 0)
        {
            string log = "";
            log += target_User.uId == -1    ? "존재하지 않는 UID입니다! " : "";
            log += data.Count <= 0          ? "User_Character의 정보가 없습니다!" : "";
            Debug.LogError(log);
            return target_User_Character;   //target_User_Character.Count <= 0
        }

        //Get Characters
        int bag = Dictionary_CharacterInfo.Instance().dictionary_size;
        int uIdx = uId * bag;
        for (int i = 0; i < cIds.Count; i++)
        {
            int cur_line = uIdx + cIds[i] - 1;
            //Exception Handling            
            if (cur_line > data.Count || (int)data[cur_line]["UID"] != uId || (int)data[cur_line]["CID"] != cIds[i])
            {
                string log = cur_line > data.Count
                    ? "Idx가 data보다 큽니다! " : "";
                log = (int)data[cur_line]["UID"] != uId || (int)data[cur_line]["CID"] != cIds[i]
                    ? "존재하지 않는 Character ID입니다." : "";
                Debug.Log(log);
                continue;
            }

            CSVData.User_Character chaData = new CSVData.User_Character();
            chaData.uId = uId;
            chaData.cId = cIds[i] -1;
            chaData.cLv = (int)data[cur_line]["LV"];
            chaData.cExp = (int)data[cur_line]["EXP"];

            target_User_Character.Add(chaData);
        }
        return target_User_Character;
    }

    public void Write_User_Character()
    {

    }

    //Debug Functions
    void Debug_AllCharacterInfoInDictionary(CSVData.User_Character user_cha)
    {
        for (int i = 1; i <= uCharacters.Count; i++)
        {
            Debug.Log(uCharacters[i].uId +
                "\t" + uCharacters[i].cId + "\t" + uCharacters[i].cLv + "\t" + uCharacters[i].cExp);
        }
    }
    void Debug_Search_User()
    {
        CSVData.User newUser = new CSVData.User();
        int uid = -1;

        //Input
        if (Input.GetKeyDown(KeyCode.Keypad1))          uid = 0;
        else if (Input.GetKeyDown(KeyCode.Keypad2))     uid = 1;
        else if (Input.GetKeyDown(KeyCode.Keypad3))     uid = 2;
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
            uid = 0;
            cIds.Add(1);
            cIds.Add(2);
            cIds.Add(3);
            cIds.Add(4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            uid = 1;
            cIds.Add(4);
            cIds.Add(3);
            cIds.Add(2);
            cIds.Add(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            uid = 2;
            cIds.Add(2);
            cIds.Add(1);
            cIds.Add(4);
            cIds.Add(0);
        }
        if (uid == -1) return;

        Debug.Log("캐릭터 검색 시작");
        newUser = Search_User_Character(uid, cIds);
        if(newUser.Count <= 0) { Debug.Log("검색된 캐릭터들이 없습니다"); return; }
        for(int i = 0; i < newUser.Count; i++)
        {
            Dictionary<int, CSVData.Character_Info> newDictionary = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo;
            Debug.Log("UID : " + newUser[i].uId + "\tCID : " + newUser[i].cId + "\tName : " + newDictionary[cIds[i]].name + "\t");
            //Dictionary_CharacterInfo.Instance().Debug_CharacterInfoInDictionary(newUser[i].uId);
        }
    }
}
