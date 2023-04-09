using UnityEngine;

using _Character;

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
                if(Dictionary_CharacterInfo.Instance() != null)
                    this.star = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].star_Basic;
                else
                    this.star = 0;
        }
    }

    /// <summary>
    /// 캐릭터의 고정 기본 데이터 (수정은 CSV에서만)
    ///     <para>
    ///     Name
    ///     Star_Basic
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
    [System.Serializable]
    public struct Character_Info
    {
        //Character infomation
        [Header("Character Infomation")]
        public string name;         //이름
        public int star_Basic;      //기본 성급
        [Header("Character Stat")]
        public Character_Stat stat; //스탯

        //Stage
        [Header("Character Stage (SS > S > A > B > C)")]
        [Tooltip("시가지")]
        public string cityLv;       //시가지 전투력
        [Tooltip("야외")]
        public string outdoorLv;    //야외 전투력
        [Tooltip("실내")]
        public string insideLv;     //실내 전투력

        //Types
        [Header("Character Types")]
        [Tooltip("Class Type")]
        public Type_Class tClass;
        [Tooltip("Role Type")]
        public Type_Role tRole;
        [Tooltip("Positioning Type")]
        public Type_Positioning tPositioning;
        [Tooltip("Attack Property Type")]
        public Type_Property tProperty_Att;
        [Tooltip("Deffece Property Type")]
        public Type_Property tProperty_Def;
        [Tooltip("Weapon Type")]
        public Type_Weapon tWeapon;
    }
}