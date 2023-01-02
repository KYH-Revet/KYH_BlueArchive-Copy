using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSVData;
public class Dictionary_CharacterInfo : MonoBehaviour
{
    //SingleTon
    static Dictionary_CharacterInfo instance;
    public static Dictionary_CharacterInfo Instance()
    {
        if (instance == null)
            instance = new Dictionary_CharacterInfo();
        return instance;
    }

    Dictionary<int, Character_Info> dic_Cha_Info;
    public Dictionary<int, Character_Info> dictionary_CharacterInfo { get { return dic_Cha_Info; } }
    
    //Unity Functions
    void Awake()
    {
        Instance();
        dic_Cha_Info = new Dictionary<int, Character_Info>();
        DontDestroyOnLoad(this.gameObject);
    }
    
    //Class Functions
    public void Add(int cid, Character_Info data)
    {
        //Exception Handling
        if(dic_Cha_Info.ContainsKey(cid))
        {
            Debug.LogError("에러 위치 \"Dictionary_CharacterInfo.Add()\", 이미 등록되어있는 cid 입니다.] 등록되어있는 캐릭터 cid: " + cid + ", 이름: " + dic_Cha_Info[cid].name);
            return;
        }

        //Add
        dic_Cha_Info.Add(cid, data);
    }
    public Character_Info Search_CharacterInfo(int cid)
    {
        Character_Info user_Character = new Character_Info();
        user_Character.name = "";   //"" It mean searching result is null

        if (dic_Cha_Info.ContainsKey(cid))
            user_Character = dic_Cha_Info[cid];

        return user_Character;
    }
}
