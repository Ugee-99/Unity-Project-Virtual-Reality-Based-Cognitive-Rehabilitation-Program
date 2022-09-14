using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // Song beats per minute
    // This is determined by the song you're trying to sync up to
    // �д� Beat, ����ȭ�Ϸ��� �뷡�� ���� ����
    public float songBpm;

    // The number of seconds for each song beat
    // �� �뷡 ���ڿ� ���� �ð�(��)
    public float secPerBeat;

    // Current song position, in seconds
    // ���� �뷡 ��ġ(��)
    public float songPosition;

    // Current song position, in beats
    // ���� �� ��ġ(���� ����)
    public float songPositionInBeats;

    // How many seconds have passed since the song started
    // �뷡 ��� �ð�
    public float dspSongTime;

    // an AudioSource attached to this GameObject that will play the music.
    // ������ ����� �� ���� ��ü�� ����� ����� �ҽ�
    public AudioSource musicSource;

    // ����� ���۵Ǹ� �� ���� ����� �����Ͽ� �Ϻ� ������ �����ϰ� ���������� ������� ���۵� �ð��� ����ؾ� �մϴ�.
    void Start()
    {
        // Load the AudioSource attached to the Conductor GameObject
        // ������ ���� ��ü�� ����� ����� �ҽ� �ε�
        musicSource = GetComponent<AudioSource>();

        // Calculate the number of seconds in each beat
        // �� ������ �� ���� ���
        secPerBeat = 60f / songBpm;

        // Record the time when the music starts
        // ������ ���۵Ǵ� �ð� ���
        dspSongTime = (float)AudioSettings.dspTime;

        // Start the music
        // ���� ����
        musicSource.Play();
    }


    // ����� �ý��ۿ� ���� ���� �ð��� �뷡�� ����� �� �ð�(��)�� �ش��ϴ� �뷡�� ���۵� �ð� ������ ���̸� �����ϸ� �̸� ���� songPosition�� �����մϴ�.
    void Update()
    {
        // determine how many seconds since the song started
        // �뷡 ���� �� �� �� ������ Ȯ��
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        // determine how many beats since the song started
        // �뷡�� ���۵� ���� �� �������� Ȯ��
        songPositionInBeats = songPosition / secPerBeat;
    }
}
