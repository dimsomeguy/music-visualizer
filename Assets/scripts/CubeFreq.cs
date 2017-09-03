using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFreq : MonoBehaviour {
    public int band;
    public float StartScale, ScaleMultiplier;
    public bool UseBuffer = true;
    public Color MyColor;
    Material Mat;

	// Use this for initialization
	void Start () {
        Mat = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (UseBuffer == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, (Audioviz.BandBuff[band] * ScaleMultiplier) + StartScale, transform.localScale.z);
            Color color = new Color(MyColor.r * Audioviz.audiobandBuffer[band], MyColor.g * Audioviz.audiobandBuffer[band],MyColor.b  * Audioviz.audiobandBuffer[band]);
            Mat.SetColor("_EmissionColor", color);
        }
        else if (UseBuffer != true)
        {
            transform.localScale = new Vector3(transform.localScale.x, (Audioviz.FreqBand[band] * ScaleMultiplier) + StartScale, transform.localScale.z);
            Color color = new Color(MyColor.r * Audioviz.audioband[band], MyColor.g * Audioviz.audioband[band], MyColor.b * Audioviz.audioband[band]);
            Mat.SetColor("_EmissionColor", color);
        }
    }
}
