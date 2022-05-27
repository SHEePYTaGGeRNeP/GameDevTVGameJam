using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Collisions
{
    [RequireComponent(typeof(Collider))]
    public class ElementalWall : MonoBehaviour
    {
        private Collider _collider;
        private Collider2D _collider2D;

        [SerializeField]
        private ElementEnum _elementToIgnore;
        public ElementEnum ElementToIgnore { get => _elementToIgnore; set => _elementToIgnore = value; }

        private void Awake()
        {
            this._collider = this.GetComponentInChildren<Collider>();
            this._collider2D = this.GetComponentInChildren<Collider2D>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!AllowPass(collision.gameObject))
            {
                return;
            }

            Physics.IgnoreCollision(collision.collider, this._collider);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!AllowPass(collision.gameObject))
            {
                return;
            }

            Physics2D.IgnoreCollision(collision.collider, this._collider2D);
        }

        public bool AllowPass(GameObject gameObject)
        {
            var element = gameObject.GetComponentInChildren<Element>();
            if (element == null || element.ElementalValue != _elementToIgnore)
            {
                return false;
            }

            return true;
        }
    }
}