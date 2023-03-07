using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSVData;
using _Character;
using System;

public class Dictionary_CharacterStat : MonoBehaviour
{
    //SingleTon
    static Dictionary_CharacterStat instance;
    public static Dictionary_CharacterStat Instance()
    {
        if (instance == null)
            instance = new Dictionary_CharacterStat();
        return instance;
    }

    //Dictionary of Character stats
    Dictionary<int, Character_Stat> dic_Cha_Stat;
    public Dictionary<int, Character_Stat> dictionary_CharacterStat { get { return dic_Cha_Stat; } }
    string path = "CSV/CharacterStat";

    //Dictionary of Character stat increase
    Dictionary<int, Character_Stat> dic_Cha_StatIncrease;
    public Dictionary<int, Character_Stat> dictionary_CharacterStatIncrease { get { return dic_Cha_StatIncrease; } }
    string path_Increase = "CSV/CharacterStatIncrease";
    public int dictionary_size = 0;
    int dictionary_size_increase = 0;

    //Unity Functions
    void Awake()
    {
        //Singleton
        instance = this;

        //New Dictionary
        dic_Cha_Stat = new Dictionary<int, Character_Stat>();
        dic_Cha_StatIncrease = new Dictionary<int, Character_Stat>();

        //Load stat data
        Read_Character_Stat();
        //Completed load
        if (dic_Cha_Stat.Count > 0)
        {
            Debug.Log("Dictionary] Complete Load");
            DataInitialize.load_Dictionary_CharacterStat = true;
        }

        //Load stat increase data
        Read_Character_StatIncrease();
        //Completed load
        if (dic_Cha_StatIncrease.Count > 0)
        {
            Debug.Log("Dictionary] Complete Load");
            DataInitialize.load_Dictionary_CharacterStatIncrease = true;
        }

        //Dictionary size compare
        if(dictionary_size != dictionary_size_increase)
        {
            Debug.LogWarning("Dictionary_CharacterStat] Stat 사전과 StatIncrease 사전의 크기가 다릅니다. CSV 파일에 누락된 내용이 있는지 확인하세요.");
        }

        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    void Read_Character_Stat()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);

        for (int i = 0; i < data.Count; i++)
        {
            int cid = (int)data[i]["CID"];

            //Exception Handling
            if (dic_Cha_Stat.ContainsKey(cid))
            {
                Debug.LogError("에러 위치 \"Dictionary_Character_Stat.Read_Character_Stat()\", 이미 등록되어있는 cid 입니다.]///[등록되어있는 캐릭터] cid: " + cid);
                continue;
            }

            //Add Infomation
            Character_Stat curChaStat = new Character_Stat();

            //Data
            curChaStat.maxHp        = (int)data[i]["MAXHP"];           //최대 생명력
            curChaStat.damage       = (int)data[i]["DAMAGE"];          //공격력
            curChaStat.defensive    = (int)data[i]["DEFENSIVE"];       //방어력
            curChaStat.cure         = (int)data[i]["CURE"];            //치유력
            curChaStat.hitRate      = (int)data[i]["HITRATE"];         //명중률
            curChaStat.evasionLv    = (int)data[i]["EVASIONLV"];       //회피 수치
            curChaStat.criticalLv   = (int)data[i]["CRITICALLV"];      //치명 수치
            curChaStat.criticaldmg  = (int)data[i]["CRITICALDMG"];     //치명 데미지
            curChaStat.stabillty    = (int)data[i]["STAILLTY"];        //안정성
            curChaStat.ccRimforce   = (int)data[i]["CCRIMFORCE"];      //군중제어력
            curChaStat.ccResistance = (int)data[i]["CCRESISTANCE"];    //군중제어 저항력
            curChaStat.normalRange  = (int)data[i]["NORMALRANGE"];     //일반공격 사거리
            curChaStat.costRecovery = (int)data[i]["COSTRECOVERY"];    //코스트 회복력

            //Add in dictionary
            dic_Cha_Stat.Add((int)data[i]["CID"], curChaStat);
            dictionary_size++;
        }
    }    
    void Read_Character_StatIncrease()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path_Increase);

        for (int i = 0; i < data.Count; i++)
        {
            int cid = (int)data[i]["CID"];

            //Exception Handling
            if (dic_Cha_StatIncrease.ContainsKey(cid))
            {
                Debug.LogError("에러 위치 \"Dictionary_Character_Stat.Read_Character_StatIncrease()\", 이미 등록되어있는 cid 입니다.]///[등록되어있는 캐릭터] cid: " + cid);
                continue;
            }

            //Add Infomation
            Character_Stat curChaStatIncrease = new Character_Stat();

            //Data
            curChaStatIncrease.maxHp        = (int)data[i]["MAXHP"];      //최대 생명력
            curChaStatIncrease.damage       = (int)data[i]["DAMAGE"];     //공격력
            curChaStatIncrease.defensive    = (int)data[i]["DEFENSIVE"];  //방어력
            curChaStatIncrease.cure         = (int)data[i]["CURE"];       //치유력

            //Add in dictionary
            dic_Cha_StatIncrease.Add((int)data[i]["CID"], curChaStatIncrease);
            dictionary_size_increase++;
        }
    }

    //Public Function
    public Character_Stat GetCharacterStat(int cid, int clv)
    {
        //Get character stat
        Character_Stat target = dic_Cha_Stat[cid];

        //Increase by character level
        target.maxHp        += (int)clv * dic_Cha_StatIncrease[cid].maxHp;
        target.damage       += (int)clv * dic_Cha_StatIncrease[cid].damage;
        target.defensive    += (int)clv * dic_Cha_StatIncrease[cid].defensive;
        target.cure         += (int)clv * dic_Cha_StatIncrease[cid].cure;

        return target;
    }
    
    //Debug Functions
    public void Debug_AllCharacterStatInDictionary()
    {
        for (int i = 1; i <= dic_Cha_Stat.Count; i++)
        {
            Debug.Log(dic_Cha_Stat[i].maxHp + "\t" + dic_Cha_Stat[i].damage +
                "\t" + dic_Cha_Stat[i].defensive + "\t" + dic_Cha_Stat[i].cure +
                "\t" + dic_Cha_Stat[i].hitRate + "\t" + dic_Cha_Stat[i].evasionLv +
                "\t" + dic_Cha_Stat[i].criticalLv + "\t" + dic_Cha_Stat[i].criticaldmg +
                "\t" + dic_Cha_Stat[i].ccRimforce + "\t" + dic_Cha_Stat[i].ccResistance +
                "\t" + dic_Cha_Stat[i].normalRange + "\t" + dic_Cha_Stat[i].costRecovery);
        }
    }
    public void Debug_CharacterStatInDictionary(int cId)
    {
        Debug.Log(dic_Cha_Stat[cId].maxHp + "\t" + dic_Cha_Stat[cId].damage +
                "\t" + dic_Cha_Stat[cId].defensive + "\t" + dic_Cha_Stat[cId].cure +
                "\t" + dic_Cha_Stat[cId].hitRate + "\t" + dic_Cha_Stat[cId].evasionLv +
                "\t" + dic_Cha_Stat[cId].criticalLv + "\t" + dic_Cha_Stat[cId].criticaldmg +
                "\t" + dic_Cha_Stat[cId].ccRimforce + "\t" + dic_Cha_Stat[cId].ccResistance +
                "\t" + dic_Cha_Stat[cId].normalRange + "\t" + dic_Cha_Stat[cId].costRecovery);
    }
    public void Debug_AllCharacterStatIncreaseInDictionary()
    {
        for (int i = 1; i <= dic_Cha_Stat.Count; i++)
        {
            Debug.Log(dic_Cha_Stat[i].maxHp + "\t" + dic_Cha_Stat[i].damage +
                "\t" + dic_Cha_Stat[i].defensive + "\t" + dic_Cha_Stat[i].cure);
        }
    }
    public void Debug_CharacterStatIncreaseInDictionary(int cId)
    {
        Debug.Log(dic_Cha_Stat[cId].maxHp + "\t" + dic_Cha_Stat[cId].damage +
            "\t"+ dic_Cha_Stat[cId].defensive + "\t" + dic_Cha_Stat[cId].cure);
    }
}
