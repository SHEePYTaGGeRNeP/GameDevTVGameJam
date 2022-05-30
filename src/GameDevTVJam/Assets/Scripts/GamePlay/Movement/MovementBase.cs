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

        Rigidbody2D rb;

        public void Start()
        {
            this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        }

        protected void Halt()
        {
            Vector2 velocity;
            if ((velocity = this.rb.velocity) != Vector2.zero)
            {
                velocity = Vector2.zero;
                this.rb.velocity = velocity;
                Debug.Log(velocity);
            }

        }

        protected void MoveToTargetPosition()
        {
            if (_targetPosition == null)
            {
                return;
            }

            //float step = this._speed * Time.deltaTime;
            // Vector2.MoveTowards(this.transform.position, this.targetPosition, step);
            
            Vector2 dir = this.targetPosition - this.transform.position;
            if(dir.magnitude > 0.3f) this.rb.velocity = dir.normalized * this._speed;
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
