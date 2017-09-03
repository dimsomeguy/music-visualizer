using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class Audioviz : MonoBehaviour {
    public AudioSource AS;

    public static float[] Samples = new float[512];
    public static float[] FreqBand = new float[8];
    public static float[] BandBuff = new float[8];
    float[] BufferDecrease = new float[8];

    float[] freqbandhighest = new float[8];
    public static float[] audioband = new float[8];
    public static float[] audiobandBuffer = new float[8];

    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetAudioSpec();
        MakeFreqBands();
        MakeBandBuff();
        MakeAudioBands();
    }
    void GetAudioSpec()
    {
        AS.GetSpectrumData(Samples, 0 ,FFTWindow.Blackman);
    }
    void MakeAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (FreqBand[i] > freqbandhighest[i])
            {
                freqbandhighest[i] = FreqBand[i];
            }

            audioband[i] = (FreqBand[i] / freqbandhighest[i]);
            audiobandBuffer[i] = (BandBuff[i] / freqbandhighest[i]);
        }


    }

    void MakeFreqBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float Average = 0;
            int SampleCounter = (int)Mathf.Pow(2, i)* 2;

            if (i == 7)
            {
                SampleCounter = +2;
            }
            for (int j = 0; j < SampleCounter; j++)
            {
                Average += Samples[count] * (count + 1);
                count++;
            }

            Average /= count;

            FreqBand[i] = Average * 10;
        }
    }
    void MakeBandBuff()
    {
        for (int i = 0; i < 8; i++)
        {
            if (FreqBand[i] > BandBuff[i])
            {
                BandBuff[i] = FreqBand[i];
                BufferDecrease[i] = 0.005f;
            }
            else if (BandBuff[i] > FreqBand[i])
            {
                BandBuff[i] -= BufferDecrease[i];
                BufferDecrease[i] *= 1.1f;
            }
        }
    }
    public void AudioGetter(AudioSource AudioDropper)
    {
        AudioDropper = AS;
    }
}
