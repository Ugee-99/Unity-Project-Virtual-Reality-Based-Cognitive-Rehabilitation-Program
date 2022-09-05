using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyze : MonoBehaviour
{
    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    public float Rms;
    public float freqN;

    const int   QSamples  = 1024;
    const float RefValue  = 0.1f;
    const float Threshold = 0.02f;

    float[] _samples;
    float[] _spectrum;
    float   _fSample;

    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
    }

    void Update()
    {
        AnalyzeSound();
    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 1); // ���÷� �迭 ����
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // ���� ������ ��
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = ����� ������


        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); //  dB ���
        if (DbValue < -160) DbValue = -160; //  �ּ� -160dB�� ����
                                            // ���� ����Ʈ�� ����

        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 1, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // max�� Ž��
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN��  �ִ밪�� ����
        }
        float freqN = maxN; // ������ �ε�������
        if (maxN > 0 && maxN < QSamples - 1)
        { // �̿������� �̿��Ͽ� ������ ����
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples / 3; // ������ ���ļ��� ��ȯ


        if (maxN > 0 && maxN < QSamples - 1)
        { // �̿������� �̿��Ͽ� ����Ȯ��

            if (_spectrum[maxN] < _spectrum[maxN - 1] * 1.12)
            {
                Rms = 1;
                Debug.Log(Rms);
            }
            else
                Rms = 0;
            return;
        }
    }
}