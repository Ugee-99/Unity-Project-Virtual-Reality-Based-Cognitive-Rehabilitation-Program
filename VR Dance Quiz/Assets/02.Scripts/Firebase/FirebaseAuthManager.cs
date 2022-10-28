using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Unity.XR.CoreUtils;

public class FirebaseAuthManager
{
    static FirebaseAuthManager instance = null;

    public static FirebaseAuthManager Instance
    {
        get
        {
            if (instance == null)
                instance = new FirebaseAuthManager();
            return instance;
        }
    }

    // �α��� / ȸ������ � ���
    FirebaseAuth auth;
    // ������ �Ϸ�� ���� ����
    FirebaseUser user;

    public string UserId => user.UserId;

    public Action<bool> LoginState;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        // �ӽ�ó��
        if (auth.CurrentUser != null)
        {
            Logout();
            //Debug.Log("�ӽ�ó��");
        }
        // �̺�Ʈ �ڵ鷯(���� ���°� �ٲ� �� ���� ȣ��)
        auth.StateChanged += OnChanged;
    }

    void OnChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                //Debug.Log("�α׾ƿ�");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if (signed)
            {
                //Debug.Log("�α���");
                LoginState?.Invoke(true);
            }
        }
    }

    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                //Debug.Log("ȸ������ ���");
                return;
            }

            if (task.IsFaulted)
            {
                // ȸ������ ���� ���� ---> �̸����� ������ / ��й�ȣ�� �ʹ� ���� / �̹� ���Ե� �̸��� ��
                //Debug.Log("ȸ������ ����");
                Singleton<LoginSystem>.Instance.SigninFailMessage();
                return;
            }

            // �������� �ʾ��� ��� ������ ������ ���ο� ������ ������
            FirebaseUser newUser = task.Result;
            //Debug.Log("ȸ������ �Ϸ�");
        });
    }

    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                //Debug.Log("�α��� ���");
                return;
            }

            if (task.IsFaulted)
            {
                // �α��� ���� ���� ---> �̸����� ������ / ��й�ȣ�� �ʹ� ���� / �̹� ���Ե� �̸��� ��
                //Debug.Log("�α��� ����");
                Singleton<LoginSystem>.Instance.LoginFailMessage();
                return;
            }

            // �������� �ʾ��� ��� ������ ������ ���ο� ������ ������
            FirebaseUser newUser = task.Result;
            //Debug.Log("�α��� �Ϸ�");
        });
    }

    public void Logout()
    {
        auth.SignOut();
        //Debug.Log("�α׾ƿ�");
    }
}