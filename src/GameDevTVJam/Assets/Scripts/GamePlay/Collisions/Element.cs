using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Collisions
{
    public class Element : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;
        [SerializeField]
        private Collider2D _collider2D;

        [SerializeField]
        private ElementEnum _elementalValue;
        public ElementEnum ElementalValue { get => _elementalValue; set => _elementalValue = value; }

        [SerializeField]
        private bool _allowSwitching;
        public bool AllowSwitching { get => _allowSwitching; set => _allowSwitching = value; }

        [Header("DEBUG PURPOSE ONLY")]
        [SerializeField]
        private List<Collider> _ignoredColliders = new List<Collider>();
        [SerializeField]
        private List<Collider2D> _ignoredColliders2D = new List<Collider2D>();

        public void AddIgnoreCollider(Collider col)
        {
            _ignoredColliders.Add(col);
            Physics.IgnoreCollision(col, this._collider);
        }
        public void AddIgnoreCollider(Collider2D col)
        {
            _ignoredColliders2D.Add(col);
            Physics2D.IgnoreCollision(col, this._collider2D);
        }

        public void ClearIgnoredColliders()
        {
            for (int i = 0; i < _ignoredColliders.Count; i++)
            {
                Physics.IgnoreCollision(this._collider, _ignoredColliders[i], false);
            }

            for (int i = 0; i < _ignoredColliders2D.Count; i++)
            {
                Physics2D.IgnoreCollision(this._collider2D, _ignoredColliders2D[i], false);
            }
            _ignoredColliders.Clear();
            _ignoredColliders2D.Clear();
        }

    }
}
