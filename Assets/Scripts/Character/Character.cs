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
            ////Character_Info는 Dictionary_Character에 저장되어있는 고정 데이터에서 상당부분 가져올 수 있음
            Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo.TryGetValue(cId, out characterInfo);
            //Get Stat (With calculate by level)
            characterInfo.stat = Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level);
        }
        catch (KeyNotFoundException)
        {
            Debug.Log(Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level).maxHp);
            Debug.LogError("KeyNotFoundException : CID [" + cId + "] 불러오기 실패");
        }
=======
        Debug.Log(DataInitialize.load_User_Character);
        level = SignManager.user_Characters[cId].cLv;
        
        //Character_Info는 Dictionary_Character에 저장되어있는 고정 데이터에서 상당부분 가져올 수 있음
        if (Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo.TryGetValue(cId, out characterInfo))
            Debug.Log("CID [" + cId + "] 불러오기 성공");
        else
            Debug.Log("CID [" + cId + "] 불러오기 실패");

        characterInfo.stat = Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level);
>>>>>>> parent of 2a53b00 (Add 2D Sprite Images)
    }
}
