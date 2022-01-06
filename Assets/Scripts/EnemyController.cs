using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum EnemyState
    {
        SWIMMING,
        ALERT,
        CHASING,
    }

    EnemyState _state;

    public Transform[] Waypoints;

    [SerializeField] float _chaseRadius = 10f;
    [SerializeField] float _swimmingSpeed = 1f;
    [SerializeField] float _chaseSpeed = 1f;

    [SerializeField] float _alertRotationSpeed = 10f;
    [SerializeField] float _rotationSpeed = 1f;

    [SerializeField] float _secondsUntilChase = 1f;
    float _secondsPassed;

    Transform _target;
    int _currentWaypoint;

    private void Start()
    {
        _state = EnemyState.SWIMMING;
    }

    private void Update()
    {
        switch (_state)
        {
            case EnemyState.SWIMMING:
                StateSwimming();
                break;
            case EnemyState.ALERT:
                StateAlert();
                break;
            case EnemyState.CHASING:
                StateChasing();
                break;
            default:
                break;
        }
    }

    void StateSwimming()
    {
        if (Vector3.Distance(Waypoints[_currentWaypoint].position, transform.position) < 1)
        {
            _currentWaypoint = (_currentWaypoint + 1) % Waypoints.Length;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Waypoints[_currentWaypoint].position - transform.position), _rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * _swimmingSpeed * Time.deltaTime;
    }

    void StateAlert()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.position - transform.position), _alertRotationSpeed * Time.deltaTime);

        if (_secondsPassed > _secondsUntilChase)
        {
            _state = EnemyState.CHASING;
            _secondsPassed = 0;
        }

        _secondsPassed += Time.deltaTime;

        Debug.Log(_secondsPassed);
    }

    void StateChasing()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.position - transform.position), _alertRotationSpeed * Time.deltaTime);
        transform.position += transform.forward * _chaseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
            _state = EnemyState.ALERT;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _state = EnemyState.SWIMMING;
            _secondsPassed = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        #region Look Radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRadius);
        #endregion
    }
}
