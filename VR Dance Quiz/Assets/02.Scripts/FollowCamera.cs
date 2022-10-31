using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;

    // ����� �� �ð�
    float lerpTime = 0.5f;
    // ��� ī��Ʈ
    float currentTime = 0f;

    private void Start()
    {
        this.transform.position = startPosition.position;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= lerpTime)
        {
            currentTime = lerpTime;
        }
        // currentTime / lerpTime <--- �����Ӹ��� 0���� 1���� ������ �����ϴ� ����
        this.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, currentTime / lerpTime);
    }
}