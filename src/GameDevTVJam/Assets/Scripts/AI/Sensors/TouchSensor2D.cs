using UnityEngine;
using Assets.Scripts.Helpers.Classes;

namespace Assets.Scripts.AI.Sensors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class TouchSensor2D : TouchSensor
    {
        private Collider2D _thisCollider;

        protected override void Awake()
        {
            base.Awake();
            this._thisCollider = this.GetComponent<Collider2D>();
        }

        protected override void DebugDrawGizmos()
        {
            if (Application.isPlaying)
                Gizmos.color = this.IsTouching ? Color.red : Color.green;
            else
                Gizmos.color = Color.grey;
            if (this._thisCollider is BoxCollider2D box)
                Gizmos.DrawWireCube(this.transform.position + box.offset.WithZ(0), box.size);
            else if (this._thisCollider is CircleCollider2D circle)
                Gizmos.DrawWireSphere(this.transform.position + circle.offset.WithZ(0), circle.radius);
            //else if (this._thisCollider is CapsuleCollider2D capsule)
            //{
            //    // draw some spheres to fake capsule
            //    for (float position = -capsule.size.y / 2f + capsule.size;
            //        position < (capsule.height / 2f); position += (int)capsule.radius)
            //    {
            //        switch (capsule.direction)
            //        {
            //            case 0: //x
            //                Gizmos.DrawWireSphere(
            //                    this.transform.position + capsule.center + (this.transform.right * position),
            //                    capsule.radius);
            //                break;
            //            case 1: //y
            //                Gizmos.DrawWireSphere(
            //                    this.transform.position + capsule.center + (this.transform.up * position),
            //                    capsule.radius);
            //                break;
            //            default: //z
            //                Gizmos.DrawWireSphere(
            //                    this.transform.position + capsule.center + (this.transform.forward * position),
            //                    capsule.radius);
            //                break;
            //        }
            //    }
            //}
        }

    }
}
