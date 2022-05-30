using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Projectiles
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private Projectile _projectilePrefab;

        [SerializeField]
        private Transform _projectileSpawnLocation;

        [SerializeField]
        private float _reloadTime = 1f;

        [SerializeField]
        private float _remainingCooldown = 0;

        public void Shoot(Trait trait)
        {
            _remainingCooldown = Mathf.Max(_remainingCooldown - Time.deltaTime, 0);
            if (_remainingCooldown > 0)
            {
                return;
            }

            _remainingCooldown = _reloadTime;
            var projectile = GameObject.Instantiate(_projectilePrefab, _projectileSpawnLocation.position, _parent.rotation);
            projectile.CreatedBy = this.gameObject;
            projectile.transform.right = _projectileSpawnLocation.right;
            projectile.SetElement(trait);
            projectile.GetComponent<SpriteRenderer>().color = trait.color;
        }

    }
}
