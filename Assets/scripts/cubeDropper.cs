using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDropper : MonoBehaviour {

    private int TopBand =  0;
    public float minimumsize, maximumsize;

    public int InstanRate = 5;


    public GameObject[] dropperObject = new GameObject[8];

   
    void Start () {
        Debug.Log(this.transform.position);

        InvokeRepeating("ObjectDrop", 5.0f, 0.5f);

        AudioProcessor Processor = FindObjectOfType<AudioProcessor>();
        Processor.onBeat.AddListener(onBeatDetected);

    }
	
	// Update is called once per frame
	void Update () {

    }
    void onBeatDetected()
    {
        Debug.Log("the beat was dropped");
    }
    void ObjectDrop()
    {
        BestBandGetter();

        Instantiate(dropperObject[TopBand], new Vector3(Random.Range(-5000f, 5000), Random.Range(100, 1000), Random.Range(0f, 10000f)), transform.rotation);

    }

    void BestBandGetter()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i == 0)
            {
                TopBand = 0;
            }
            else if (Audioviz.audioband[TopBand] < Audioviz.audioband[i])
            {
                TopBand = i;
            }
        }
    }
}
