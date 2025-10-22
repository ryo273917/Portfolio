using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircle : MonoBehaviour
{
    [SerializeField] private float _radius = 1;
    [SerializeField] private Vector2 _center;
    [SerializeField] private GameObject _hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var circlePos = _radius * Random.insideUnitCircle;

            var spawnPos = new Vector2(
                circlePos.x, circlePos.y ) + _center;

            Instantiate(_hit, spawnPos, Quaternion.identity);
        }
    }
}
