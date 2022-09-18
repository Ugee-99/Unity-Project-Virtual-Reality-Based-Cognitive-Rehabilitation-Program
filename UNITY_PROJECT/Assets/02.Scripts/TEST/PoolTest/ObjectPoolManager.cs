using System;
using System.Collections.Generic;
using UnityEngine;
using KeyType = System.String;

/// <summary> 
/// ������Ʈ Ǯ ���� �̱���
/// </summary>
[DisallowMultipleComponent]
public class ObjectPoolManager : MonoBehaviour
{
    // �ν����Ϳ��� ������Ʈ Ǯ�� ��� ���� �߰�
    [SerializeField]
    private List<PoolObjectData> _poolObjectDataList = new List<PoolObjectData>(4);

    // ������ ������Ʈ�� ���� ��ųʸ�
    private Dictionary<KeyType, PoolObject> _sampleDict;

    // Ǯ�� ���� ��ųʸ�
    private Dictionary<KeyType, PoolObjectData> _dataDict;

    // Ǯ ��ųʸ�
    private Dictionary<KeyType, Stack<PoolObject>> _poolDict;

    public static ObjectPoolManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        int len = _poolObjectDataList.Count;
        if (len == 0) return;

        // 1. Dictionary ����
        _sampleDict = new Dictionary<KeyType, PoolObject>(len);
        _dataDict = new Dictionary<KeyType, PoolObjectData>(len);
        _poolDict = new Dictionary<KeyType, Stack<PoolObject>>(len);

        // 2. Data�κ��� ���ο� Pool ������Ʈ ���� ����
        foreach (var data in _poolObjectDataList)
        {
            Register(data);
        }
    }

    /// <summary> Pool �����ͷκ��� ���ο� Pool ������Ʈ ���� ��� </summary>
    private void Register(PoolObjectData data)
    {
        // �ߺ� Ű�� ��� �Ұ���
        if (_poolDict.ContainsKey(data.key))
        {
            return;
        }

        // 1. ���� ���ӿ�����Ʈ ����, PoolObject ������Ʈ ���� Ȯ��
        GameObject sample = Instantiate(data.prefab);
        if (!sample.TryGetComponent(out PoolObject po))
        {
            po = sample.AddComponent<PoolObject>();
            po.key = data.key;
        }
        sample.SetActive(false);

        // 2. Pool Dictionary�� Ǯ ���� + Ǯ�� �̸� ������Ʈ�� ����� ��Ƴ���
        Stack<PoolObject> pool = new Stack<PoolObject>(data.maxObjectCount);
        for (int i = 0; i < data.initialObjectCount; i++)
        {
            PoolObject clone = po.Clone();
            pool.Push(clone);
        }

        // 3. ��ųʸ��� �߰�
        _sampleDict.Add(data.key, po);
        _dataDict.Add(data.key, data);
        _poolDict.Add(data.key, pool);
    }

    /// <summary> Ǯ���� �������� </summary>
    public PoolObject Spawn(KeyType key)
    {
        // Ű�� �������� �ʴ� ��� null ����
        if (!_poolDict.TryGetValue(key, out var pool))
        {
            return null;
        }

        PoolObject po;

        // 1. Ǯ�� ��� �ִ� ��� : ��������
        if (pool.Count > 0)
        {
            po = pool.Pop();
        }
        // 2. ��� ���� ��� ���÷κ��� ����
        else
        {
            po = _sampleDict[key].Clone();
        }

        po.Activate();

        return po;
    }

    /// <summary> Ǯ�� ����ֱ� </summary>
    public void Despawn(PoolObject po)
    {
        // Ű�� �������� �ʴ� ��� ����
        if (!_poolDict.TryGetValue(po.key, out var pool))
        {
            return;
        }

        KeyType key = po.key;

        // 1. Ǯ�� ���� �� �ִ� ��� : Ǯ�� �ֱ�
        if (pool.Count < _dataDict[key].maxObjectCount)
        {
            pool.Push(po);
            po.Deactivate();
        }
        // 2. Ǯ�� �ѵ��� ���� �� ��� : �ı��ϱ�
        else
        {
            Destroy(po.gameObject);
        }
    }
}