using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private const float _speed = 5f;

    private Vector3 _lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(Random.Range(-1, 1) >= 0 ? 1 : -1, Random.Range(0.2f, 0.8f), 0) * _speed;
        Debug.Log(_rigidbody.velocity);
    }

    private void Update()
    {
        _lastVelocity = _rigidbody.velocity;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        var reflect = Vector2.Reflect(_lastVelocity, collision.contacts[0].normal).normalized * _speed;

        Debug.Log(_lastVelocity);
        Debug.Log(collision.contacts[0].normal);
        Debug.Log(reflect);
        _rigidbody.velocity = reflect;
    }

    public void ResetBall()
    {
        // Wait for X seconds, then release the ball
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

        StartCoroutine(waiter(3));
    }

    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Start();
    }
}
