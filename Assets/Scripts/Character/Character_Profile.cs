using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Not include enemy(Not necessary)
/// </summary>
public class Character_Profile : Character
{
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
}
