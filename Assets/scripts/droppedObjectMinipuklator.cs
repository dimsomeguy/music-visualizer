using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppedObjectMinipuklator : MonoBehaviour {

    public int band;
    public float StartScale, ScaleMultiplier;
    public bool UseBuffer = true;
    public Color MyColor;
    private int count = 0;

    Material Mat;
    // Use this for initialization
    void Start () {
       Mat = GetComponent<MeshRenderer>().materials[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (UseBuffer == true)
        {
            transform.localScale = new Vector3((Audioviz.BandBuff[band] * ScaleMultiplier) + StartScale, (Audioviz.BandBuff[band] * ScaleMultiplier) + StartScale, (Audioviz.BandBuff[band] * ScaleMultiplier) + StartScale);
            Color color = new Color(MyColor.r * Audioviz.audiobandBuffer[band], MyColor.g * Audioviz.audiobandBuffer[band], MyColor.b * Audioviz.audiobandBuffer[band]);
            Mat.SetColor("_EmissionColor", color);
        }
        else if (UseBuffer != true)
        {
            transform.localScale = new Vector3((Audioviz.FreqBand[band] * ScaleMultiplier) + StartScale, (Audioviz.FreqBand[band] * ScaleMultiplier) + StartScale, (Audioviz.FreqBand[band] * ScaleMultiplier) + StartScale);
            Color color = new Color(MyColor.r * Audioviz.audioband[band], MyColor.g * Audioviz.audioband[band], MyColor.b * Audioviz.audioband[band]);
            Mat.SetColor("_EmissionColor", color);
        }

        if (transform.localScale.x <= 1.0F)
        {
            count++;
            if (count == 150)
            {
               Destroy(this.gameObject);
            }
        }
        else
        {
            count = 0;
        }
    }
}
