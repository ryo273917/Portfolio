using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friuts : MonoBehaviour
{
    [SerializeField] private GameObject melon;
    [SerializeField] private GameObject slush1;
    [SerializeField] private GameObject slush2;
    // Start is called before the first frame update
    void Start()
    {
        melon.SetActive(true);
        slush1.SetActive(false);
        slush2.SetActive(false);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Atack"))
        {
            melon.SetActive(false);
            slush1.SetActive(true);
            slush2.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
