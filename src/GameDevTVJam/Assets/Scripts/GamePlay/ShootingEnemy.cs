using Assets.Scripts.AI.Sensors;
using Assets.Scripts.GamePlay.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField]
        private Gun _gun;

        [SerializeField]
        private SightSensor2D _sensor;

        [SerializeField]
        private float _rotationSpeed = 5f;


        private void Update()
        {
            if (_sensor.RaycastsThatHit.Count == 0)
            {
                return;
            }
            for (int i = 0; i < _sensor.RaycastsThatHit.Count; i++)
            {
                if (_sensor.RaycastsThatHit[i].Value.Item2.GetComponentInParent<Player>() == null)
                {
                    continue;
                }

                Vector3 vectorToTarget = _sensor.RaycastsThatHit[i].Value.Item2.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
                _gun.Shoot();
            }
        }
    }
}
