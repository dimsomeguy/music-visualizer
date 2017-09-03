using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStrobeLight : MonoBehaviour {
    public int band;
    public float minimumlight, maximumLight;

    private Light Strober;

	// Use this for initialization
	void Start () {
        Strober = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        Strober.intensity = (Audioviz.audiobandBuffer[band] * (maximumLight - minimumlight)) + minimumlight;
	}
}
