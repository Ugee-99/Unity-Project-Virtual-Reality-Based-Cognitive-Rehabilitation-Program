using UnityEngine;

// ����ȭ�� ���� �ٸ� Ŭ������ �ν�����â���� Ȯ��
[System.Serializable]
public class VRMap
{
    // VR Ÿ���̶�� VR ��ȯ�� ���� ���� ������ Ŭ���� 4����
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    // Add Call Add ������ ���� �� ���� ���� ������ �ʷ� ���� ����
    public Transform headConstraint;

    // �Ӹ��� ��ü ������ �ʱ� ��ġ ���̰� �� ���� ����
    public Vector3 headBodyOffset;

    public int turnSmoothness;

    private void Start()
    {
        // ���ʿ� ��ġ ��ȯ�� ���ش�.
        headBodyOffset = transform.position - headConstraint.position;
    }

    private void Update()
    {
        // �Ӹ� ��ġ�� ���� ��ü�� ���÷� ��ȭ�Ѵ�.
        // �Ӹ��� ��ġ�� �������� �߰��� ������ ���� �θ𿡰� �����Ѵ�.
        transform.position = headConstraint.position + headBodyOffset;

        // �� �κ��� 3D ĳ������ ��� �࿡ ���� ���÷� ����Ǿ�� �Ѵ�.
        // Robot Kyle�� ��� �Ӹ��� ������ ���(y)���̹Ƿ� ������ up�� �־��ش�.
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}