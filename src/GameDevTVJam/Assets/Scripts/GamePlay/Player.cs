using Assets.Scripts.GamePlay.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class Player : MonoBehaviour
    {

        [SerializeField]
        private ParticleSystem _particleSystem;

        private Element element;

        public GameManager gameManager;

        public int Keys { get { return this._keys; } }
        [SerializeField]
        int _keys = 0;

        public void Start()
        {
            this.element = this.gameObject.GetComponent<Element>();
        }

        public void NewTrait(Trait trait)
        {
            ParticleSystem.MainModule settings = _particleSystem.main;
            settings.startColor = new ParticleSystem.MinMaxGradient(trait.color);
        }

        public void Hit_Damage(Transform position, Trait trait, out bool takeOver)
        {
            takeOver = false;
            if (this.element.ElementalValue != trait)
            {
                Hit_Transformation(position, trait, out takeOver);

                Debug.Log("takeover (damage):" + takeOver);
                return;
            }

            this.gameManager.UpdateHP(-1);
        }

        private void Hit_Transformation(Transform position, Trait trait, out bool takeOver)
        {
            takeOver = false;
            Debug.Log("pre-hit: " + this.gameManager.TransformationMana);
            this.gameManager.UpdateMANA(-1);
            Debug.Log("hit: " + this.gameManager.TransformationMana);
            Debug.Log("hit-trait: " + trait.name);

            if (this.gameManager.TransformationMana <= 0)
            {
                Debug.Log("set new trait?");
                this.NewTrait(trait);
                takeOver = true;
                Debug.Log("takeover (damage):" + takeOver);
            }
        }

        public void IncreaseKey()
        {
            this.gameManager.UpdateKeys(++this._keys);
        }
    }
}
