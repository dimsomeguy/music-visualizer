using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBuilder512 : MonoBehaviour {

    public GameObject BaseCubeprefab;

    public float maxScaler = 10;

    GameObject[] BaseCube = new GameObject[512];
	// Use this for initialization
	void Start () {

        for (int i = 0; i < 512; i++)
        {
            GameObject InsttantiateBaseCube = (GameObject)Instantiate(BaseCubeprefab);
            InsttantiateBaseCube.transform.position = this.transform.position;
            InsttantiateBaseCube.transform.parent = this.transform;
            InsttantiateBaseCube.name = "BaseCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            InsttantiateBaseCube.transform.position = Vector3.forward * 1000;
            BaseCube[i] = InsttantiateBaseCube;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 512; i++)
        {
            if (BaseCube != null)
            {
                BaseCube[i].transform.localScale = new Vector3(10, (Audioviz.Samples[i] * maxScaler) + 2, 10);
            }
        }
	}
}
