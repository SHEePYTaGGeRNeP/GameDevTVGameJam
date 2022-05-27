using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Movement
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _waypoints;

        [SerializeField]
        private float _distanceBeforeReached = 1f;


        [Header("Control options")]
        [SerializeField]
        private float _speed;

        private Transform _nextWaypoint;

        private void Awake()
        {
            _nextWaypoint = _waypoints[0];
        }

        private void Update()
        {
            if (Vector2.Distance(this.transform.position, _nextWaypoint.position) < _distanceBeforeReached)
            {
                NextWaypoint();
            }
            MoveToWaypoint();
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
        }

        private void MoveToWaypoint()
        {
            float step = this._speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, this._nextWaypoint.position, step);
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
