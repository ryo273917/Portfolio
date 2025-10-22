using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreate : MonoBehaviour
{
    public GameObject[] Road = new GameObject[3];
    public GameObject player;
    private float speed = 10;

    private void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        RoadSpown();
        transform.position -= new Vector3(Time.deltaTime * speed,0, 0);
    }

    void RoadSpown()
    {
        if(transform.position.x <= -25f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
