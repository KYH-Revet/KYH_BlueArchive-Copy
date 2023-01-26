using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSVData;
using _Character;

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

    //Dictionary of Character informations
    Dictionary<int, Character_Info> dic_Cha_Info;
    public Dictionary<int, Character_Info> dictionary_CharacterInfo { get { return dic_Cha_Info; } }
    string path = "CSV/CharacterInfo";
    public int dictionary_size = 0;

    //Unity Functions
    void Awake()
    {
        instance = this;
        dic_Cha_Info = new Dictionary<int, Character_Info>();
        
        //Load data
        Read_Character_Info();

        //Completed load
        if (dictionary_CharacterInfo.Count > 0)
        {
            Debug.Log("Complete Load");
            DataInitialize.load_Dictionary_CharacterInfo = true;
        }

        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    void Read_Character_Info()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        
        for (int i = 0; i < data.Count; i++)
        {
            int cid = (int)data[i]["CID"];

            //Exception Handling
            if (dic_Cha_Info.ContainsKey(cid))
            {
                Debug.LogError("���� ��ġ \"Dictionary_CharacterInfo.Add()\", �̹� ��ϵǾ��ִ� cid �Դϴ�.]///[��ϵǾ��ִ� ĳ����] cid: " + cid + ", �̸�: " + dic_Cha_Info[cid].name);
                continue;
            }

            //Add Infomation
            Character_Info curChaInfo = new Character_Info();

            //Name
            curChaInfo.name             = data[i]["NAME"].ToString();
            curChaInfo.star_Basic       = (int)data[i]["STAR"];

            //Stage
            curChaInfo.cityLv           = data[i]["CITYLV"].ToString();     //�ð��� ������
            curChaInfo.outdoorLv        = data[i]["OUTDOORLV"].ToString();  //�߿� ������
            curChaInfo.insideLv         = data[i]["INSIDELV"].ToString();   //�ǳ� ������

            //Types
            curChaInfo.tClass           = (Type_Class)      Enum.Parse(typeof(Type_Class),          data[i]["CLASS"].ToString());
            curChaInfo.tRole            = (Type_Role)       Enum.Parse(typeof(Type_Role),           data[i]["ROLE"].ToString());
            curChaInfo.tPositioning     = (Type_Positioning)Enum.Parse(typeof(Type_Positioning),    data[i]["POSITIONING"].ToString());
            curChaInfo.tProperty_att    = (Type_Property)   Enum.Parse(typeof(Type_Property),       data[i]["PROPERTY_ATT"].ToString());
            curChaInfo.tProperty_def    = (Type_Property)   Enum.Parse(typeof(Type_Property),       data[i]["PROPERTY_DEF"].ToString());


            //Add in dictionary
            dic_Cha_Info.Add((int)data[i]["CID"], curChaInfo);
            dictionary_size++;
        }
    }

    //Debug Functions
    public void Debug_AllCharacterInfoInDictionary()
    {
        for (int i = 1; i <= dic_Cha_Info.Count; i++)
        {
            Debug.Log(dic_Cha_Info[i].name +
                "\t" + dic_Cha_Info[i].cityLv + "\t" + dic_Cha_Info[i].outdoorLv + "\t" + dic_Cha_Info[i].insideLv +
                "\t" + dic_Cha_Info[i].tClass + "\t" + dic_Cha_Info[i].tRole + "\t" + dic_Cha_Info[i].tPositioning +
                "\t" + dic_Cha_Info[i].tProperty_att + "   \t" + dic_Cha_Info[i].tProperty_def);
        }
    }
    public void Debug_CharacterInfoInDictionary(int cId)
    {
        Debug.Log(dic_Cha_Info[cId].name +
            "\t" + dic_Cha_Info[cId].cityLv + "\t" + dic_Cha_Info[cId].outdoorLv + "\t" + dic_Cha_Info[cId].insideLv +
            "\t" + dic_Cha_Info[cId].tClass + "\t" + dic_Cha_Info[cId].tRole + "\t" + dic_Cha_Info[cId].tPositioning +
            "\t" + dic_Cha_Info[cId].tProperty_att + "   \t" + dic_Cha_Info[cId].tProperty_def);
    }
}
