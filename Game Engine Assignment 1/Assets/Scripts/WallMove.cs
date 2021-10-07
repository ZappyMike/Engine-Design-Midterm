using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.position += new Vector3(-(speed * Time.deltaTime), 0, 0);
    }
}
