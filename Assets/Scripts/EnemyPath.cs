using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;
    [SerializeField] GameObject _enemyPrefab;

    private void Start()
    {
        GameObject enemy = Instantiate(_enemyPrefab, _waypoints[0].position, _waypoints[0].rotation);
        enemy.GetComponent<EnemyController>().Waypoints = _waypoints;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_waypoints[i].position, .3f);
            Gizmos.color = Color.red;

            Gizmos.DrawLine(_waypoints[i].position, _waypoints[(i + 1) % _waypoints.Length].position);
        }
    }
}
