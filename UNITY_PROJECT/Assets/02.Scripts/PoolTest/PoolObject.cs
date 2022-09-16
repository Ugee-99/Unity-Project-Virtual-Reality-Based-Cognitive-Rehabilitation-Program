using UnityEngine;
using KeyType = System.String;

/// <summary>������ ������Ʈ�� ������Ʈ�� ���� Ŭ����. �ʵ�� Ű���� �����Ѵ�. </summary>
[DisallowMultipleComponent]
public class PoolObject : MonoBehaviour
{
    public KeyType key;

    /// <summary> ���ӿ�����Ʈ ���� </summary>
    public PoolObject Clone()
    {
        GameObject go = Instantiate(gameObject);
        if (!go.TryGetComponent(out PoolObject po))
            po = go.AddComponent<PoolObject>();
        go.SetActive(false);

        return po;
    }

    /// <summary> ���ӿ�����Ʈ Ȱ��ȭ </summary>
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    /// <summary> ���ӿ�����Ʈ ��Ȱ��ȭ </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}