using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{
    public GameObject ball;
    Vector3 dist;// Start is called before the first frame update
    void Start()
    {
        dist = transform.position - ball.transform.position;
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + dist;
    }
}
