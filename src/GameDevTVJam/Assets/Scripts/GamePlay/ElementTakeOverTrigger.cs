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

        void OnTriggerEnter(Collider collider)
        {
            SwitchElement(collider.gameObject);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            SwitchElement(collider.gameObject);
        }

        void OnCollisionEnter(Collision collision)
        {
            SwitchElement(collision.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            SwitchElement(collision.gameObject);
        }

        public void SwitchElement(GameObject gameObject)
        {
            var element = gameObject.GetComponentInChildren<Element>();
            if (element == null) return;
            if (this.Element == null) return;
            if (!element.AllowSwitching) return;
            if (element.ElementalValue != null)
            {
                if (element.ElementalValue.type == Element.type)
                {
                    return;
                }
            }

            element.ElementalValue = this.Element;
            element.ClearIgnoredColliders();
        }
    }
}
