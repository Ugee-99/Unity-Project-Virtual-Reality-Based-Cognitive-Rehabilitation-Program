/// <summary>
/// QuizManager.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// ���� : ���� ���� ��ü�� ���ڸ� ����ϼ���. (���� ���۰� ���ÿ� ����)
/// 1) ���� ��ü 7���� �� ��1 
/// 2) ���ڿ� N���� �� ��1  (���ڿ��� ��� �þ ����) - '���� ��ȭ �뼭 ���� ħ�� ���� ��ȭ ���� ���� ���� ģ�� ���� Ȱ�� ���� ���� ��� �� ���� ��� ��� ��� ���� �ں� �ε巯�� �ູ ���� ���� ���� �ڽŰ� ���� �ູ ��ȥ ��ø�� �ǰ� �游 �ϰ��� ���� ���� ���� ǳ�� ���� ���� �ɷ� ������ �Ҹ� ħ�� ���� ��� �һ�' ��
///
/// ���� : ���� ���۰� ���ÿ� ��Ÿ���� ���� ��ü�� ���ڸ� ����غ�����.
/// 1) ������1 : ����  (��ġ�� 1/2Ȯ���� ����)
/// 2) ������2 : ����  (��ġ�� 1/2Ȯ���� ����)  
/// 
/// </summary>



/// �� ���� �г� ���� ����
/// | Easy / Normal : ���ʿ� Light, �����ʿ� �۱� �������� ����
/// | Hard : ���� Light�� �۱Ͱ� ���� ��ġ�� ����

/// �� ���� �г� ���� ����
/// | �� - ����� ������ ���Ƶ� ��� ����
/// | �۱� - ���� �г��� �۱Ϳ� �ϳ��� ��ġ�ؾ� ��

using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel; // ���� �г�



    public static QuizManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //if (GameManager.instance.isStart)
    }

    /// <summary>
    /// �� ���� �г� ���� ����
    /// | Easy / Normal : ���ʿ� Light, �����ʿ� �۱� �������� ����
    /// | Hard : ���� Light�� �۱Ͱ� ���� ��ġ�� ����
    /// </summary>
    /// <param name=""></param>
    void QuizSuggestion()
    {
        //quizThemeChoice = Random.Range(0, 2);

        //switch (quizThemeChoice)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        break;
        //}
    }

    /** �μ��� ���� �ʾ������� ������ **/
    //public void QuizUnit()
    //{
    //    Random random = Random.range;           /// �����Լ� ��ü����
        
    //    this.color = random.Range(7);           /// 0~6 ������ ������ ���� ����
    //    this.letter = random.Range(4);          /// 0~3 ������ ������ ���� ����
    //}

    /** �μ��� �־������� ������ **/
    //public QuizUnit(int _color, int _letter)
    //{
    //    Random randdom = new Random();

    //    do
    //    {
    //        this.color = random.Range(7);
    //        this.letter = random.Range(4);
    //    } while (this.color == _color && this.letter == _letter)        /// �Ѵ� �����ϴٸ� ���ο� ���� ����. �� �� �ϳ��� �������� ���������� ��ӵ���	
    //}

    //QuizUnit answer;
    //QuizUnit opt1;
    //QuizUnit opt2;

    //public void Play()
    //{
    //    answer = new Quiz();                                        ///���� ����

    //    Random random = new Random();

    //    random = random.Range(2);                                   /// 1/2Ȯ���� ���� ���� ���� - �ϳ��� �����̸� �ٸ� �ϳ��� ����
    //    switch (random)
    //    {
    //        case 0:
    //            {
    //                opt1 = answer;
    //                opt2 = new QuizUnit(answer.color, answer.letter);   ///�ɼ�2�� ���ο� ������ ����/���� ����
    //                break;
    //            }
    //        case 1:
    //            {
    //                opt2 = answer;
    //                opt1 = new QuizUnit(answer.color, answer.letter);
    //                break;
    //            }
    //    }

    //    //1. ������ - ���� ó�� ������ ���� ������� ��
    //    ����Ƽȭ��ǥ�õ��Լ�(answer.color);
    //    ����Ƽȭ��ǥ�õ��Լ�(answer.letter);

    //    //2. ������
    //    random = random.Range(2);

    //    ConsoleKeyInfo KeyInfo;                         ///�Է°�ü -> ����Ƽ�� �°� ����
    //    KeyInfo = Console.ReadKey();                    ///�Է°�ü -> ����Ƽ�� �°� ����
    //                                                    /// if(KeyInfo.Key == ConsoleKey.A)

    //    int choice;

    //    switch (random)   /// ó�� ������ ans�� color�� letter ���� �ϳ��� �������� �����ؾ� �Ѵ�.	
    //    {
    //        case 0:
    //            {
    //                /// ���� ����
    //                ����Ƽȭ��ǥ��(answer.color);

    //                /// ������ ����
    //                ����Ƽȭ��ǥ��(opt1.letter);
    //                ����Ƽȭ��ǥ��(opt2.letter);

    //                /// ���� ���� �� ��� ǥ��
    //                System.Console.WriteLine("�����ϼ���");
    //                choice = Convert.ToInt32(Console.ReadKey());       ///�Է°�ü -> ����Ƽ�� �°� ����
    //                if (choice == answer.letter)
    //                    System.Console.WriteLine("�����Դϴ�");
    //                else
    //                    System.Console.WriteLine("�����Դϴ�.");
    //            }
    //        case 1:
    //            {
    //                /// ���� ����
    //                ����Ƽȭ��ǥ��(answer.letter);

    //                /// ������ ����
    //                ����Ƽȭ��ǥ��(opt1.color);
    //                ����Ƽȭ��ǥ��(opt2.color);

    //                /// ���� ���� �� ��� ǥ��
    //                System.Console.WriteLine("�����ϼ���");
    //                choice = Convert.ToInt32(Console.ReadKey());       ///�Է°�ü -> ����Ƽ�� �°� ����
    //                if (choice == answer.color)
    //                    System.Console.WriteLine("�����Դϴ�");
    //                else
    //                    System.Console.WriteLine("�����Դϴ�.");
    //            }
    //    }
    //}
}