using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_CubeMove : MonoBehaviour {

    public float fl_speed;

    private void FixedUpdate()
    {
        CubeMove();
    }

    void CubeMove()
    {
        transform.Translate(Vector2.left * Time.deltaTime * fl_speed);
    }
}
