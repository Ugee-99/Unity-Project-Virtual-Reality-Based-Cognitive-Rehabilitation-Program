using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;

// GameData.cs - ����ü�� �ݷ����� ������ �߰�
public class GameData
{
    // MongoDB ������ �����ϴ� ��ü
    public ObjectId id { get; set; }  // �ʵ��� ���� Index
    public string signInId { get; set; }
    public string signInPw { get; set; }
    public int gender { get; set; } // 0 == Man / 1 == Girl
    public int age { get; set; }
}
