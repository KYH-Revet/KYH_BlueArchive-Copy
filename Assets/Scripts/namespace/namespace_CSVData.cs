using UnityEngine;

using _Character;

namespace CSVData
{
    /// <summary>
    /// [User ���� ������ ����ü]
    ///     <para>
    ///         Id          : �α��� �� ID ||
    ///         Password    : �α��� �� Password
    ///     </para>
    ///     <para>
    ///         UId         : ���� ���� �ڵ� ||
    ///         NickName    : ����
    ///     </para>
    ///     <para>
    ///         AccountLv   : ���� ���� ||
    ///         AccountExp  : ���� ����ġ
    ///     </para>
    ///     <para>
    ///         AP          : �ӹ� ���忡 ����� ��ȭ ||
    ///         Credit      : �ΰ��� ��ȭ ||
    ///         Cash        : ���� ��ȭ
    ///     </para>
    /// </summary>
    public struct User
    {
        [Header("Sign Info")]
        public string id;           //�α��� ���̵�
        public string password;     //�α��� ��й�ȣ

        [Header("Account Info")]
        public int uId;             //������ȣ
        public string nickname;     //����

        public int accountLv;       //���� ����
        public int accountExp;      //���� ����ġ

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
    /// User �� ���� ���� ĳ������ ������ ����ü
    ///     <para>
    ///     CId         = ĳ���� ������ȣ
    ///     CLv         = ĳ������ ����
    ///     CExp        = ĳ������ ����ġ
    ///     Possesion   = ���� ����
    ///     Start       = ĳ������ ���� ����
    ///     </para>
    /// </summary>
    public struct User_Character
    {
        public int cId;             //ĳ���� ������ȣ
        public int cLv;             //ĳ���� ����
        public int cExp;            //ĳ���� ����ġ
        public bool possesion;      //���� ����
        public int star;            //����

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
    /// ĳ������ ���� �⺻ ������ (������ CSV������)
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
        public string name;         //�̸�
        public int star_Basic;      //�⺻ ����
        [Header("Character Stat")]
        public Character_Stat stat; //����

        //Stage
        [Header("Character Stage (SS > S > A > B > C)")]
        [Tooltip("�ð���")]
        public string cityLv;       //�ð��� ������
        [Tooltip("�߿�")]
        public string outdoorLv;    //�߿� ������
        [Tooltip("�ǳ�")]
        public string insideLv;     //�ǳ� ������

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