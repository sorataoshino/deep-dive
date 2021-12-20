using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum EnemyState
    { 
        SWIMMING,
        CHASING,
        RESETTING
    }

    EnemyState _state;

    [SerializeField] float _lookRadius = 10f;
    [SerializeField] float _moveSpeed = 1f;

    [SerializeField] Transform[] _waypoints;
    Transform _currentWaypoint;

    private void Start()
    {
        _currentWaypoint = _waypoints[0];
        _state = EnemyState.SWIMMING;
    }

    private void Update()
    {
        switch (_state)
        {
            case EnemyState.SWIMMING:
                StateSwimming();
                break;
            case EnemyState.CHASING:
                StateChasing();
                break;
            case EnemyState.RESETTING:
                StateResetting();
                break;
            default:
                break;
        }
    }

    void StateSwimming()
    {
       transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _moveSpeed) * Time.deltaTime;
    }

    void StateChasing()
    {

    }

    void StateResetting()
    {

    }

    private void OnDrawGizmosSelected()
    {
        #region Look Radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
        #endregion
    }

    private void OnDrawGizmos()
    {
        #region Path
        Gizmos.color = Color.green;
        for (int i = 0; i < _waypoints.Length - 1; i++)
        {
            Gizmos.DrawWireSphere(_waypoints[i].position, .3f);
            Gizmos.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
        }
        #endregion
    }
}
