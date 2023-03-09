using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CSVData;
using _Character;

public class Character : MonoBehaviour
{
    //Character infomation
    [Header("Infomation")]
    [SerializeField]
    protected int cId;
    [SerializeField]
    protected int level;

    [SerializeField]
    protected Character_Info characterInfo;
    protected Character_Stat stat { get { return characterInfo.stat; } }

    [Header("2D Images")]
    //public Sprite sprite_FullBody;
    public Sprite sprite_Profile;

    protected virtual void Start()
    {
        LoadCharacterInfo();
    }

    void LoadCharacterInfo()
    {
<<<<<<< HEAD
        try
        {
            ////Get Character Lv
            level = SignManager.user_Characters[cId].cLv;
            ////Character_Info�� Dictionary_Character�� ����Ǿ��ִ� ���� �����Ϳ��� ���κ� ������ �� ����
            Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo.TryGetValue(cId, out characterInfo);
            //Get Stat (With calculate by level)
            characterInfo.stat = Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level);
        }
        catch (KeyNotFoundException)
        {
            Debug.Log(Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level).maxHp);
            Debug.LogError("KeyNotFoundException : CID [" + cId + "] �ҷ����� ����");
        }
=======
        Debug.Log(DataInitialize.load_User_Character);
        level = SignManager.user_Characters[cId].cLv;
        
        //Character_Info�� Dictionary_Character�� ����Ǿ��ִ� ���� �����Ϳ��� ���κ� ������ �� ����
        if (Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo.TryGetValue(cId, out characterInfo))
            Debug.Log("CID [" + cId + "] �ҷ����� ����");
        else
            Debug.Log("CID [" + cId + "] �ҷ����� ����");

        characterInfo.stat = Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level);
>>>>>>> parent of 2a53b00 (Add 2D Sprite Images)
    }
}
