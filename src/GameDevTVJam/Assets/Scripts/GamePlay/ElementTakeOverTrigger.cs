using Assets.Scripts.GamePlay.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class ElementTakeOverTrigger : MonoBehaviour
    {
        [SerializeField]
        private Trait _element;
        public Trait Element { get => _element; set => _element = value; }

        [SerializeField]
        private bool _listenToTrigger = true;

        [SerializeField]
        private bool _listenToCollision = true;

        void OnTriggerEnter(Collider collider)
        {
            if (_listenToTrigger)
            {
                this.SwitchElement(collider.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (_listenToTrigger)
            {
                this.SwitchElement(collider.gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (_listenToCollision)
            {
                this.SwitchElement(collision.gameObject);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (_listenToCollision)
            {
                this.SwitchElement(collision.gameObject);
            }
        }

        public void SwitchElement(GameObject gameObject)
        {
            var element = gameObject.GetComponentInChildren<Element>();
            if (element == null) return;
            if (!element.AllowSwitching) return;
            if (element.ElementalValue == null && this._element == null) return;
            if (element.ElementalValue != null && this._element != null)
            {
                if (element.ElementalValue.type == this._element.type)
                {
                    return;
                }
            }

            element.ElementalValue = this._element;
            element.ClearIgnoredColliders();
        }
    }
}
