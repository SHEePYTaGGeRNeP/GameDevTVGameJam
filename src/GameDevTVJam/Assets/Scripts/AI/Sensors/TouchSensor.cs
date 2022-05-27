using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI.Sensors
{
    public abstract class TouchSensor : Sensor
    {
        [Space(20)]
        [SerializeField]
        protected bool triggerSense = true;

        [SerializeField]
        protected bool collisionSense;

        [Header("Debug TouchSensor3D")]
        [SerializeField]
        protected int touchCount;

        public bool IsTouching => this.touchCount > 0;

        [SerializeField]
        private List<GameObject> _touchingGameObjects;


        protected abstract void OnTouchEnter(GameObject other);
        protected abstract void OnTouchExit(GameObject other);

        protected sealed override void UpdateSense()
        {
            this._touchingGameObjects.RemoveAll(x => x == null);
            this.touchCount = this._touchingGameObjects.Count;
        }

        protected sealed override void DebugDrawImportantGizmos()
        {
            if (this.IsTouching)
                this.DebugDrawGizmos();
        }


        private void OnTriggerEnter2D(Collider2D other) => this.CheckTouch(other.gameObject, true, true);
        private void OnTriggerEnter(Collider other) => this.CheckTouch(other.gameObject, true, true);
        private void OnCollisionEnter2D(Collision2D collision) => this.CheckTouch(collision.gameObject, false, true);
        private void OnCollisionEnter(Collision collision) => this.CheckTouch(collision.gameObject, false, true);
        private void OnTriggerExit2D(Collider2D other) => this.CheckTouch(other.gameObject, true, false);
        private void OnTriggerExit(Collider other) => this.CheckTouch(other.gameObject, true, false);
        private void OnCollisionExit2D(Collision2D collision) => this.CheckTouch(collision.gameObject, false, false);
        private void OnCollisionExit(Collision collision) => this.CheckTouch(collision.gameObject, false, false);

        private void CheckTouch(GameObject other, bool collisionWasTrigger, bool onEnter)
        {
            if ((!this.triggerSense && collisionWasTrigger) || (!this.collisionSense && !collisionWasTrigger)
                || !this.detectionMask.IsLayerInLayerMask(other.gameObject.layer)
                || !this.CanTouch(other))
                return;
            if (onEnter)
            {
                this.touchCount++;
                this._touchingGameObjects.Add(other);
                this.OnTouchEnter(other);
            }
            else
            {
                this.touchCount--;
                this._touchingGameObjects.Remove(other);
                this.OnTouchExit(other);
            }
        }
    }
}
