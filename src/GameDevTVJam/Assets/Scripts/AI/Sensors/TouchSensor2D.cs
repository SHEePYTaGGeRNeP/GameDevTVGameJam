//using UnityEngine;

//namespace Assets.Scripts.AI.Sensors
//{
//    [RequireComponent(typeof(Collider))]
//    public abstract class TouchSensor2D : TouchSensor
//    {
//        private Collider2D _thisCollider;

//        protected override void Awake()
//        {
//            base.Awake();
//            this._thisCollider = this.GetComponent<Collider2D>();
//        }

//        protected override void DebugDrawGizmos()
//        {
//            if (Application.isPlaying)
//                Gizmos.color = this.IsTouching ? Color.red : Color.green;
//            else
//                Gizmos.color = Color.grey;
//            if (this._thisCollider is BoxCollider2D box)
//                Gizmos.DrawWireCube(this.transform.position + box.center, box.size);
//            else if (this._thisCollider is CircleCollider2D circle)
//                Gizmos.DrawWireSphere(new Vector3(this.transform.position + circle.center, circle.radius);
//            else if (this._thisCollider is CapsuleCollider2D capsule)
//            {
//                // draw some spheres to fake capsule
//                for (float position = -capsule.height / 2f + capsule.radius;
//                    position < (capsule.height / 2f); position += (int)capsule.radius)
//                {
//                    switch (capsule.direction)
//                    {
//                        case 0: //x
//                            Gizmos.DrawWireSphere(
//                                this.transform.position + capsule.center + (this.transform.right * position),
//                                capsule.radius);
//                            break;
//                        case 1: //y
//                            Gizmos.DrawWireSphere(
//                                this.transform.position + capsule.center + (this.transform.up * position),
//                                capsule.radius);
//                            break;
//                        default: //z
//                            Gizmos.DrawWireSphere(
//                                this.transform.position + capsule.center + (this.transform.forward * position),
//                                capsule.radius);
//                            break;
//                    }
//                }
//            }
//        }

//    }
//}
