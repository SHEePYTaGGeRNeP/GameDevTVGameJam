
using UnityEngine;
namespace Assets.Scripts.AI.Sensors
{
    public abstract class Sensor : MonoBehaviour
    {
        [SerializeField]
        protected LayerMask detectionMask;
        [SerializeField]
        protected LayerMask blockedMask;
        public float detectionRate = 1.0f;

        [Header("Debug Sensor")]
        [SerializeField]
        protected LayerMask combinedMask;
        [SerializeField]
        protected bool debug = true;
        [SerializeField]
        protected bool debugOnlyWhenSelected;
        [SerializeField]
        protected bool debugOnlyOnImportantValues;

        private float _elapsedTime = 0.0f;

        protected virtual void Awake()
        {
            this.combinedMask = this.detectionMask + this.blockedMask;
        }

        protected virtual void Start()
        {
            this._elapsedTime = this.detectionRate + 1f;
            this.Initialize();
        }

        protected virtual void Update()
        {
            this._elapsedTime += Time.deltaTime;
            if (this._elapsedTime < this.detectionRate)
                return;
            this._elapsedTime = 0;
            // it might change
            this.combinedMask = this.detectionMask + this.blockedMask;
            this.UpdateSense();
        }

        protected virtual void Initialize() { }
        protected abstract void UpdateSense();

        protected abstract bool CanTouch(GameObject other);

        protected void OnDrawGizmos()
        {
            if (!this.debug || this.debugOnlyWhenSelected) return;
            Color prev = Gizmos.color;
            if (this.debugOnlyOnImportantValues)
                this.DebugDrawImportantGizmos();
            else
                this.DebugDrawGizmos();
            Gizmos.color = prev;
        }

        protected void OnDrawGizmosSelected()
        {
            if (!this.debugOnlyWhenSelected) return;
            Color prev = Gizmos.color;
            if (this.debugOnlyOnImportantValues)
                this.DebugDrawImportantGizmos();
            else
                this.DebugDrawGizmos();
            Gizmos.color = prev;
        }

        protected abstract void DebugDrawGizmos();
        protected abstract void DebugDrawImportantGizmos();

    }
}
