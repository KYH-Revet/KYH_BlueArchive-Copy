using _Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Battle : Character
{
    [Header("Variable for battle")]
    public uint maxAmmo = 10;
    public uint curAmmo;
    public uint curHp;
    public uint curShield;

    public float attDelay;

    //Unity Functions
    void Start()
    {
        curHp = 0;
        curShield = 0;
        curAmmo = maxAmmo;
    }

    public override void LoadCharacterInfo()
    {
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
            Debug.LogError("KeyNotFoundException : CID [" + cId + "] 불러오기 실패");
        }
    }

    protected virtual void Skill_Entry() { }
    protected virtual void Skill_Update() { }
    protected virtual void Skill_Exit() { }
}
