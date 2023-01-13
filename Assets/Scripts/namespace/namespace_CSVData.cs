using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using System.Xml;

namespace CSVData
{
    public struct User
    {
        public string id;           //�α��� ���̵�
        public string password;     //�α��� ��й�ȣ
        public int uId;             //������ȣ
        public string nickname;     //����
        public int accountLv;       //���� ����

        public User(string id, string password, int uId, string nickname)
        {
            this.id = id;
            this.password = password;
            this.uId = uId;
            this.nickname = nickname;
            accountLv = 1;
        }
    }

    public struct User_Character
    {
        public int cId;             //ĳ���� ������ȣ
        public int cLv;             //ĳ���� ����
        public int cExp;            //ĳ���� ����ġ
        public bool possesion;      //���� ����
        public int star;            //����

        public User_Character(int cId, int cLv, int cExp, bool possesion, int star) : this()
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

    public struct Character_Info
    {
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
        public Type_Property tProperty_att;
        public Type_Property tProperty_def;

        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}