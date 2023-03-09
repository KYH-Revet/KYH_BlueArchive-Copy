using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSVData;
using _Character;
using System;
using System.Security.Cryptography;
using UnityEditorInternal;

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

    public struct Dictionary_Stat
    {
        //Private
        Dictionary<int, Character_Stat> dictionary_CharacterStat;

        //Public
        public Dictionary<int, Character_Stat> dictionary { get { return dictionary_CharacterStat; } }
        public string path;
        public int size;

        public Dictionary_Stat(string path)
        {
            this.dictionary_CharacterStat = new Dictionary<int, Character_Stat>();
            this.path = path;
            this.size = 0;
        }
    }

    //Dictionary of Character stats & Character stat increase
    public Dictionary_Stat dic_Stat         = new Dictionary_Stat("CSV/CharacterStat");
    public Dictionary_Stat dic_StatIncrease = new Dictionary_Stat("CSV/CharacterStatIncrease");

    delegate Character_Stat Loading(int cId, List<Dictionary<string, object>> data);

    //Unity Functions
    void Awake()
    {
        //Singleton
        instance = this;

        //Load data in each dictionary
        Load(dic_Stat,          Loading_Character_Stat);
        Load(dic_StatIncrease,  Loading_Character_StatIncrease);
        
        //Set data initialize sign
        DataInitialize.load_Dictionary_CharacterStat = dic_Stat.size > 0;
        DataInitialize.load_Dictionary_CharacterStatIncrease = dic_StatIncrease.size > 0;

        //Dictionary size compare
        if (dic_Stat.size != dic_StatIncrease.size)
        {
            Debug.LogWarning("Dictionary_CharacterStat] Stat ������ StatIncrease ������ ũ�Ⱑ �ٸ��ϴ�. CSV ���Ͽ� ������ ������ �ִ��� Ȯ���ϼ���.");
        }

        //Don't Destroy On Load
        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    void Load(Dictionary_Stat dictionary, Loading reading)
    {
        //Read CSV File
        List<Dictionary<string, object>> data = CSVReader.Read(dictionary.path);

        //Add data
        for(int i = 0; i < data.Count; i++)
        {
            int cId = (int)data[i]["CID"];
            try
            {   //New Data
                dictionary.dictionary.Add(cId, reading(cId, data));
                dictionary.size++;
            }
            catch (ArgumentException)
            {
                Debug.LogError("���� ��ġ \"Dictionary_Character_Stat.Read()\", �̹� ��ϵǾ��ִ� cid �Դϴ�.]///[��ϵǾ��ִ� ĳ����] cid: " + cId);
            }
        }
    }

    //Delegate Loading(...) Fucntions
    Character_Stat Loading_Character_Stat(int cId, List<Dictionary<string, object>> data)
    {
        //Add Infomation
        Character_Stat curChaStatIncrease = new Character_Stat();

        //Data
        curChaStatIncrease.maxHp        = (int)data[cId]["MAXHP"];           //�ִ� �����
        curChaStatIncrease.damage       = (int)data[cId]["DAMAGE"];          //���ݷ�
        curChaStatIncrease.defensive    = (int)data[cId]["DEFENSIVE"];       //����
        curChaStatIncrease.cure         = (int)data[cId]["CURE"];            //ġ����
        curChaStatIncrease.hitRate      = (int)data[cId]["HITRATE"];         //���߷�
        curChaStatIncrease.evasionLv    = (int)data[cId]["EVASIONLV"];       //ȸ�� ��ġ
        curChaStatIncrease.criticalLv   = (int)data[cId]["CRITICALLV"];      //ġ�� ��ġ
        curChaStatIncrease.criticaldmg  = (int)data[cId]["CRITICALDMG"];     //ġ�� ������
        curChaStatIncrease.stabillty    = (int)data[cId]["STAILLTY"];        //������
        curChaStatIncrease.ccRimforce   = (int)data[cId]["CCRIMFORCE"];      //���������
        curChaStatIncrease.ccResistance = (int)data[cId]["CCRESISTANCE"];    //�������� ���׷�
        curChaStatIncrease.normalRange  = (int)data[cId]["NORMALRANGE"];     //�Ϲݰ��� ��Ÿ�
        curChaStatIncrease.costRecovery = (int)data[cId]["COSTRECOVERY"];    //�ڽ�Ʈ ȸ����

        return curChaStatIncrease;
    }
    Character_Stat Loading_Character_StatIncrease(int cId, List<Dictionary<string, object>> data)
    {
        //Add Infomation
        Character_Stat curChaStatIncrease = new Character_Stat();

        //Data
        curChaStatIncrease.maxHp        = (int)data[cId]["MAXHP"];      //�ִ� �����
        curChaStatIncrease.damage       = (int)data[cId]["DAMAGE"];     //���ݷ�
        curChaStatIncrease.defensive    = (int)data[cId]["DEFENSIVE"];  //����
        curChaStatIncrease.cure         = (int)data[cId]["CURE"];       //ġ����

        return curChaStatIncrease;
    }

    //Public Function
    public Character_Stat GetCharacterStat(int cid, int clv)
    {
        //Get character stat
        Character_Stat target = dic_Stat.dictionary[cid];

        //Increase by character level
        target.maxHp        += (int)clv * dic_StatIncrease.dictionary[cid].maxHp;
        target.damage       += (int)clv * dic_StatIncrease.dictionary[cid].damage;
        target.defensive    += (int)clv * dic_StatIncrease.dictionary[cid].defensive;
        target.cure         += (int)clv * dic_StatIncrease.dictionary[cid].cure;

        return target;
    }
    
    //Debug Functions
    public void Debug_AllCharacterStatInDictionary()
    {
        for (int i = 1; i <= dic_Stat.size; i++)
        {
            Debug.Log(dic_Stat.dictionary[i].maxHp + "\t" + dic_Stat.dictionary[i].damage +
                "\t" + dic_Stat.dictionary[i].defensive + "\t" + dic_Stat.dictionary[i].cure +
                "\t" + dic_Stat.dictionary[i].hitRate + "\t" + dic_Stat.dictionary[i].evasionLv +
                "\t" + dic_Stat.dictionary[i].criticalLv + "\t" + dic_Stat.dictionary[i].criticaldmg +
                "\t" + dic_Stat.dictionary[i].ccRimforce + "\t" + dic_Stat.dictionary[i].ccResistance +
                "\t" + dic_Stat.dictionary[i].normalRange + "\t" + dic_Stat.dictionary[i].costRecovery);
        }
    }
    public void Debug_CharacterStatInDictionary(int cId)
    {
        Debug.Log(dic_Stat.dictionary[cId].maxHp + "\t" + dic_Stat.dictionary[cId].damage +
                "\t" + dic_Stat.dictionary[cId].defensive + "\t" + dic_Stat.dictionary[cId].cure +
                "\t" + dic_Stat.dictionary[cId].hitRate + "\t" + dic_Stat.dictionary[cId].evasionLv +
                "\t" + dic_Stat.dictionary[cId].criticalLv + "\t" + dic_Stat.dictionary[cId].criticaldmg +
                "\t" + dic_Stat.dictionary[cId].ccRimforce + "\t" + dic_Stat.dictionary[cId].ccResistance +
                "\t" + dic_Stat.dictionary[cId].normalRange + "\t" + dic_Stat.dictionary[cId].costRecovery);
    }
    public void Debug_AllCharacterStatIncreaseInDictionary()
    {
        for (int i = 1; i <= dic_StatIncrease.size; i++)
        {
            Debug.Log(dic_StatIncrease.dictionary[i].maxHp + "\t" + dic_StatIncrease.dictionary[i].damage +
                "\t" + dic_StatIncrease.dictionary[i].defensive + "\t" + dic_StatIncrease.dictionary[i].cure);
        }
    }
    public void Debug_CharacterStatIncreaseInDictionary(int cId)
    {
        Debug.Log(dic_StatIncrease.dictionary[cId].maxHp + "\t" + dic_StatIncrease.dictionary[cId].damage +
            "\t"+ dic_StatIncrease.dictionary[cId].defensive + "\t" + dic_StatIncrease.dictionary[cId].cure);
    }
}
