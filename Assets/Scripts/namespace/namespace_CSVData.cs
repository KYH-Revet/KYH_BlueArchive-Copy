using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using System.Xml;

namespace CSVData
{
    /// <summary>
    /// [User 계정 데이터 구조체]
    ///     <para>
    ///         Id          : 로그인 용 ID ||
    ///         Password    : 로그인 용 Password
    ///     </para>
    ///     <para>
    ///         UId         : 유저 개인 코드 ||
    ///         NickName    : 별명
    ///     </para>
    ///     <para>
    ///         AccountLv   : 계정 레벨 ||
    ///         AccountExp  : 계정 경험치
    ///     </para>
    ///     <para>
    ///         AP          : 임무 입장에 사용할 재화 ||
    ///         Credit      : 인게임 재화 ||
    ///         Cash        : 유료 재화
    ///     </para>
    /// </summary>
    public struct User
    {
        [Header("Sign Info")]
        public string id;           //로그인 아이디
        public string password;     //로그인 비밀번호

        [Header("Account Info")]
        public int uId;             //고유번호
        public string nickname;     //별명

        public int accountLv;       //계정 레벨
        public int accountExp;      //계정 경험치

        [Header("Account Money")]
        public int ap;
        public int credit;
        public int cash;

        public User(string id, string password, int uId, string nickname)
        {
            this.id = id;
            this.password = password;
            this.uId = uId;
            this.nickname = nickname;
            accountLv = 1;
            accountExp = 0;
            ap = 50;
            credit = 1000;
            cash = 0;
        }
    }

    /// <summary>
    /// User 당 소지 중인 캐릭터의 데이터 구조체
    ///     <para>
    ///     CId         = 캐릭터 고유번호
    ///     CLv         = 캐릭터의 레벨
    ///     CExp        = 캐릭터의 경험치
    ///     Possesion   = 소유 여부
    ///     Start       = 캐릭터의 현재 성급
    ///     </para>
    /// </summary>
    public struct User_Character
    {
        public int cId;             //캐릭터 고유번호
        public int cLv;             //캐릭터 레벨
        public int cExp;            //캐릭터 경험치
        public bool possesion;      //소유 여부
        public int star;            //성급

        public User_Character(int cId, int cLv, int cExp, bool possesion, int star)
        {
            this.cId = cId;
            this.cLv = cLv;
            this.cExp = cExp;
            this.possesion = possesion;
            if(possesion)
                this.star = star;
            else
                this.star = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].star_Basic;
        }
    }

    /// <summary>
    /// 캐릭터의 고정 기본 데이터 (수정은 CSV에서만)
    ///     <para>
    ///     Name
    ///     Start_Basic
    ///     Stat
    ///     
    ///     CityLv
    ///     outDoorLv
    ///     InsideLv
    ///     
    ///     tClass
    ///     tRole
    ///     tPositioning
    ///     tProperty_Att
    ///     tProperty_Def
    ///     </para>
    /// </summary>
    public struct Character_Info
    {
        //Character infomation
        public string name;         //이름
        public int star_Basic;      //기본 성급
        public Character_Stat stat; //스탯

        //Stage 
        public string cityLv;       //시가지 전투력
        public string outdoorLv;    //야외 전투력
        public string insideLv;     //실내 전투력

        //Types
        public Type_Class tClass;
        public Type_Role tRole;
        public Type_Positioning tPositioning;
        public Type_Property tProperty_Att;
        public Type_Property tProperty_Def;
        public Type_Weapon tWeapon;
    }
}