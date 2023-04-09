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
            ////Character_Info�� Dictionary_Character�� ����Ǿ��ִ� ���� �����Ϳ��� ���κ� ������ �� ����
            Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo.TryGetValue(cId, out characterInfo);
            //Get Stat (With calculate by level)
            characterInfo.stat = Dictionary_CharacterStat.Instance().GetCharacterStat(cId, level);
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError("KeyNotFoundException : CID [" + cId + "] �ҷ����� ����");
        }
    }
}
