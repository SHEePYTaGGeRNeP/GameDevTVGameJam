using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField]
        private Color _lineColor;

        [Header("Control options")]
        [SerializeField]
        private float _speed;

        [Header("Debug MovementBase")]
        [SerializeField]
        private Vector3 _targetPosition;
        protected Vector3 targetPosition { get => _targetPosition; set => _targetPosition = value; }

        protected void MoveToTargetPosition()
        {
            if (_targetPosition == null)
            {
                return;
            }

            float step = this._speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetPosition, step);
        }

        private void OnDrawGizmosSelected()
        {
            if (_targetPosition == null)
            {
                return;
            }

            var prevColor = Gizmos.color;
            Gizmos.color = _lineColor;
            Gizmos.DrawLine(this.transform.position, _targetPosition);
            Gizmos.color = prevColor;
        }

    }
}
