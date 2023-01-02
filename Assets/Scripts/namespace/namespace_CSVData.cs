using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;

namespace CSVData
{
    public struct User
    {
        public uint uid;            //������ȣ
        public string nickname;     //����
        public uint accountLv;      //���� ����
    }

    public struct User_Character
    {
        public uint uid;            //���� ������ȣ
        public uint cid;            //ĳ���� ������ȣ
        public uint cLv;            //ĳ���� ����
        public uint cExp;           //ĳ���� ����ġ
    }

    public struct Character_Info
    {
        public uint cid;            //���� ��ȣ
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

        //public uint star;           //N��
        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}