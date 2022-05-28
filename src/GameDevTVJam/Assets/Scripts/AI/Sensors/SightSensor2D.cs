using Helpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
namespace Assets.Scripts.AI.Sensors
{
    public class SightSensor2D : Sensor
    {
        [Space(20)]
        [SerializeField]
        private Transform _parentObject;

        [Range(1, 360)]
        public float fov = 120f;

        public float viewDistance = 100;

        [Range(1, 360)]
        public int nrOfRays = 9;

        private readonly RaycastHit2D[] _rayHits = new RaycastHit2D[10];

        [Header("Debug")]
        [SerializeField]
        [Range(0, 1f)]
        [Tooltip("Show sight lines which are distance of hit/viewDistance less than this value. Only when Debug Only Important is selected")]
        protected float importantIfLessThan = 0.8f;

        [SerializeField]
        [Tooltip("True: Only draw sight lines till the target they hit. False: Draw lines as long as viewDistance")]
        private bool _drawLineDistanceHit = true;

        [SerializeField]
        private Color[] _raycastColors;

        [SerializeField]
        [Tooltip("Gradient for coloring lines based on distance. X-axis 0.0 is super close and 1.0 is far away")]
        private Gradient _colorGradient;

        /// <summary>
        /// First index is forward then left, right, left, right
        /// less than 0 means no collision.
        /// </summary>
        public ValueTuple<float, Collider2D>[] RaycastDistances { get; private set; }

        /// <summary>
        /// Index and [distance, Collider2D]
        /// </summary>
        public List<KeyValuePair<int, ValueTuple<float, Collider2D>>> RaycastsThatHit
        {
            get
            {
                if (this.RaycastDistances.IsNullOrEmpty())
                    return new List<KeyValuePair<int, ValueTuple<float, Collider2D>>>();
                List<KeyValuePair<int, ValueTuple<float, Collider2D>>> result =
                    new List<KeyValuePair<int, ValueTuple<float, Collider2D>>>();
                for (int i = 0; i < this.RaycastDistances.Length; i++)
                {
                    if (this.RaycastDistances[i].Item1 < 0)
                        continue;
                    result.Add(new KeyValuePair<int, ValueTuple<float, Collider2D>>(i,
                        this.RaycastDistances[i]));
                }
                return result;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(this._parentObject, "Please set parent");
        }

        protected override bool CanTouch(GameObject other) => !other.transform.IsTransformInMyParents(this._parentObject);

        protected override void UpdateSense()
        {
            if (this.RaycastDistances.IsNullOrEmpty() || this.RaycastDistances.Length != this.nrOfRays)
            {
                this.RaycastDistances = new ValueTuple<float, Collider2D>[this.nrOfRays];
                for (var i = 0; i < this.RaycastDistances.Length; i++)
                {
                    this.RaycastDistances[i] = ValueTuple.Create<float, Collider2D>(-1f, null);
                }
                this._raycastColors = new Color[this.nrOfRays];
            }
            Utils.FovAction(this.transform.right, this.nrOfRays, this.fov, this.RaycastAction);
        }

        private void RaycastAction(Vector2 direction, int index)
        {
            int count = Physics2D.RaycastNonAlloc(this.transform.position, direction,
                this._rayHits, this.viewDistance, this.combinedMask);
            this.RaycastDistances[index].Item1 = -1;
            this.RaycastDistances[index].Item2 = null;
            for (int i = 0; i < count; i++)
            {
                if (!this.CanTouch(this._rayHits[i].collider.gameObject))
                    continue;
                if (!this.RaycastDistances[index].Item1.AboutEqualTo(-1) &&
                    this.RaycastDistances[index].Item1 <= this._rayHits[i].distance) continue;
                this.RaycastDistances[index].Item1 = this._rayHits[i].distance;
                this.RaycastDistances[index].Item2 = this._rayHits[i].collider;
            }
            if (this.RaycastDistances[index].Item2 == null ||
                !this.blockedMask.IsLayerInLayerMask(this.RaycastDistances[index].Item2.gameObject.layer)) return;
            // if we hit a blocked layer we should set it to nothing hit.
            this.RaycastDistances[index].Item1 = -1;
            this.RaycastDistances[index].Item2 = null;

        }

        private void OnDisable()
        {
            this.RaycastDistances = null;
        }

        protected override void DebugDrawGizmos()
        {
            if (this.RaycastDistances.IsNullOrEmpty())
                this.DrawGizmosNotPlaying();
            else
                this.DrawGizmosWhilePlaying();
        }

        private float[] _copy;

        private void DrawGizmosWhilePlaying()
        {
            // if we change nrOfRays we get exceptions if we don't copy it.
            this._copy = new float[this.RaycastDistances.Length];
            Array.Copy(this.RaycastDistances.Select(x => x.Item1).ToArray(), this._copy, this.RaycastDistances.Length);
            Utils.FovAction(this.transform.right, this.nrOfRays, this.fov, this.DrawColoredLines);
        }

        private void DrawColoredLines(Vector2 direction, int index)
        {
            // We probably changed amount of rays.
            if (_copy.Length - 1 < index)
                return;
            float perc = this._copy[index] < 0 ? 1 : this._copy[index] / this.viewDistance;
            Color c;
            if (perc.AboutEqualToOrMoreThan(1))
                c = Color.white;
            else
                c = this._colorGradient.Evaluate(perc);
            Gizmos.color = c;
            this._raycastColors[index] = c;
            if (perc > this.importantIfLessThan && this.debugOnlyOnImportantValues)
                return;
            float distance = this.viewDistance;
            if (this._drawLineDistanceHit && this._copy[index] > 0)
                distance = this._copy[index];
            Gizmos.DrawLine(this.transform.position, this.transform.position + direction.WithZ(0) * distance);
        }

        private void DrawGizmosNotPlaying()
        {
            if (this.debugOnlyOnImportantValues) return;
            Gizmos.color = Color.gray;
            Utils.FovAction(this.transform.right, this.nrOfRays, this.fov,
                (direction, i) => Gizmos.DrawLine(this.transform.position,
                    this.transform.position + direction.WithZ(0) * this.viewDistance));
        }

        protected override void DebugDrawImportantGizmos()
        {
            if (!this.RaycastDistances.IsNullOrEmpty() && this.RaycastDistances.Any(x => x.Item1 > 0))
                this.DrawGizmosWhilePlaying();
        }

    }
}
