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

        public void Hit_Damage(Trait trait)
        {
            if(this.element.ElementalValue != trait)
            {
                Hit_Transformation(trait);
                return;
            }

            this.gameManager.UpdateHP(-1);
        }

        private void Hit_Transformation(Trait trait)
        {
            this.gameManager.UpdateMANA(-1);
            if (this.gameManager.TransformationMana <= 0)
            {
                this.NewTrait(trait);
            }
        }

        public void IncreaseKey()
        {
            this.gameManager.UpdateKeys(++this._keys);
        }
    }
}
