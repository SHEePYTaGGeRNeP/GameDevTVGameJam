using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Collisions
{
    public class ElementalWall : MonoBehaviour
    {
        private Collider _collider;
        private Collider2D _collider2D;


        [SerializeField]
        private Trait _elementToIgnore;
        public Trait ElementToIgnore { get => _elementToIgnore; set => _elementToIgnore = value; }

        private void Awake()
        {
            this._collider = this.GetComponentInChildren<Collider>();
            this._collider2D = this.GetComponentInChildren<Collider2D>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (AllowPass(collision.gameObject, out var element))
            {
                element.AddIgnoreCollider(this._collider);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (AllowPass(collision.gameObject, out var element))
            {
                element.AddIgnoreCollider(this._collider2D);
            }
        }

        public bool AllowPass(GameObject gameObject, out Element element)
        {
            element = gameObject.GetComponentInChildren<Element>();
            if (element == null) return false;
            if (element.ElementalValue == null)
            {
                if (this._elementToIgnore == null) return true;
                return false;
            }
            if (this._elementToIgnore == null) return false;
            if (element.ElementalValue.type != this._elementToIgnore.type) return false;

            return true;
        }
    }
}