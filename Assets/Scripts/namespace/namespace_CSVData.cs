using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using System.Xml;

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
                this.star = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].star_Basic;
        }
    }

    /// <summary>
    /// ĳ������ ���� �⺻ ������ (������ CSV������)
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
        public string name;         //�̸�
        public int star_Basic;      //�⺻ ����
        public Character_Stat stat; //����

        //Stage 
        public string cityLv;       //�ð��� ������
        public string outdoorLv;    //�߿� ������
        public string insideLv;     //�ǳ� ������

        //Types
        public Type_Class tClass;
        public Type_Role tRole;
        public Type_Positioning tPositioning;
        public Type_Property tProperty_Att;
        public Type_Property tProperty_Def;
        public Type_Weapon tWeapon;
    }
}