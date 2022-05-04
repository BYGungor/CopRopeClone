using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRopeBack : MonoBehaviour
{
    private Rigidbody _rb;

    private float _timer;

    private float _coolDown = 0.9f;

    private float _speed1=9;
                 
    private float _speed2=25;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _timer += Time.deltaTime;
            if (_timer > _coolDown)
            {
                transform.position += -transform.forward * _speed1 * Time.deltaTime;
            }
            else
            {
                transform.position += -transform.forward * _speed2 * Time.deltaTime;
            }
           
        }
    }
}
