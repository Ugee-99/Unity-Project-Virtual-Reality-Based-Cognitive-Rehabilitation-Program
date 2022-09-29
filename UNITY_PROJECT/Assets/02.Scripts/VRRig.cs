using UnityEngine;

// ����ȭ�� ���� �ٸ� Ŭ������ �ν�����â���� Ȯ��
[System.Serializable]
public class VRMap
{
    // VR Ÿ���̶�� VR ��ȯ�� ���� ���� ������ Ŭ���� 4����
    public Transform[] vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        // Lay Controller
        if (GameManager.instance.layLeftController.activeSelf && GameManager.instance.layRightController.activeSelf)
        {
            rigTarget.position = vrTarget[0].TransformPoint(trackingPositionOffset);
            rigTarget.rotation = vrTarget[0].rotation * Quaternion.Euler(trackingRotationOffset);
        }
        // Hand Controller
        else if (GameManager.instance.handLeftController.activeSelf && GameManager.instance.handRightController.activeSelf)
        {
            rigTarget.position = vrTarget[1].TransformPoint(trackingPositionOffset);
            rigTarget.rotation = vrTarget[1].rotation * Quaternion.Euler(trackingRotationOffset);
        }
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