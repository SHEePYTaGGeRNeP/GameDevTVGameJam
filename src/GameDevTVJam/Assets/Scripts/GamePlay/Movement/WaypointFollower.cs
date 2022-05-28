using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Movement
{
    public class WaypointFollower : MovementBase
    {
        [SerializeField]
        private List<Transform> _waypoints;

        [SerializeField]
        private float _distanceBeforeReached = 1f;

        [Header("Debugging Waypoint Follower")]
        [SerializeField]
        private Transform _nextWaypoint;

        private void Awake()
        {
            _nextWaypoint = _waypoints[0];
            targetPosition = _nextWaypoint.position;
        }

        private void Update()
        {
            if (Vector2.Distance(this.transform.position, _nextWaypoint.position) < _distanceBeforeReached)
            {
                NextWaypoint();
            }
            MoveToTargetPosition();
        }

        private void NextWaypoint()
        {
            if (_nextWaypoint == _waypoints[_waypoints.Count - 1])
            {
                _nextWaypoint = _waypoints[0];
            }
            else
            {
                _nextWaypoint = _waypoints[_waypoints.IndexOf(_nextWaypoint) + 1];
            }
            targetPosition = _nextWaypoint.position;
        }

        private void OnDrawGizmosSelected()
        {
            if (_nextWaypoint == null)
            {
                return;
            }

            var prevColor = Gizmos.color;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, _nextWaypoint.position);
            Gizmos.color = prevColor;
        }
    }
}
