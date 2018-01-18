using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_CubeSpawn : MonoBehaviour {

    // Public variables that the can be changed in editor.
    public float fl_Timer;
    public GameObject mGo_SpawnBlock;

    // Private variables to control the time delay.

    private float fl_Store;


	// Use this for initialization
	void Start () {
        fl_Store = fl_Timer;
	}
	
	// Update is called once per frame
	void Update () {

        SpawnTime();
	}

    void SpawnTime()
    {
        fl_Store -= Time.deltaTime * 1;

        if (fl_Store <= 0)
        {
            Instantiate(mGo_SpawnBlock, transform.position, transform.rotation);
            fl_Store = fl_Timer;
        }

    }
}
