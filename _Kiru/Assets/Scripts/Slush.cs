using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slush : MonoBehaviour
{
    [SerializeField] private GameObject _atack;

    private void Start()
    {
        _atack.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = target;

        if (Input.GetMouseButton(0))
        {
            _atack.SetActive(true);
        }
        else 
        {
            _atack.SetActive(false);
        }

    }
}
