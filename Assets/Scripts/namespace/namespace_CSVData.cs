using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;

namespace CSVData
{
    public struct User
    {
        public int uId;             //������ȣ
        public string nickname;     //����
        public int accountLv;      //���� ����
    }

    public struct User_Character
    {
        public int uId;             //���� ������ȣ
        public int cId;             //ĳ���� ������ȣ
        public int cLv;            //ĳ���� ����
        public int cExp;           //ĳ���� ����ġ
    }

    public struct Character_Info
    {
        public string name;         //�̸�

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

        //public int star;           //N��
        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}