using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RopeMinikit;
using Unity.Mathematics;

public class PullObjectBack : MonoBehaviour
{
    [HideInInspector]
    public int index;

    private Rigidbody _rb;

    Transform target;

    private Rope _rope;

    private float _timer;

    [SerializeField] private float _coolDown1=0.85f;

    [SerializeField] private float _coolDown2=1.2f;

    [SerializeField] private float _velocity1=120;

    [SerializeField] private float _velocity2=107;
    private void Awake()
    {
        _rope = GameObject.FindObjectOfType<Rope>();
        _rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        if (Input.GetKey(KeyCode.S))
        {
            _timer += Time.deltaTime;
            if (_timer > _coolDown1 && _timer < _coolDown2)
            {
                _rb.velocity = Vector3.back * _velocity1;
            }
            else if (_timer > _coolDown2)
            {
                _rb.velocity = Vector3.back * _velocity2;
            }

        }
        else if (_rope.once)
        {
            transform.position = _rope.GetPositionAt(index);
        }

    }

}


