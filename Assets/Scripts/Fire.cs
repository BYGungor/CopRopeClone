using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fire : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _lastVelocity;

    [SerializeField] private float _shotPower;
    [SerializeField] private float _reflectSpeed;
    [SerializeField] private float _colliderSpawnNumber=100;

    private float _timer;
    private float _coolDown = 0.7f;
    private float _speed = 10;

    public PullObjectBack prefab;

    public Transform target;

 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        for (int i = 0; i < _colliderSpawnNumber; i++)
        {
            PullObjectBack pull = Instantiate(prefab);

            pull.index = i;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 dir = hit.point - transform.position;
                dir.y = 0; 
                _rb.AddForce(dir.normalized * _shotPower, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _timer += Time.deltaTime;
            if (_timer > _coolDown)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * _speed * Time.deltaTime;
            }

        }


        _lastVelocity = _rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        var speed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        _rb.velocity = direction * Mathf.Max(_reflectSpeed, 0);


    }
}
