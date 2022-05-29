using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    class Player : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSystem;


        public void NewTrait(Trait trait)
        {
            ParticleSystem.MainModule settings = _particleSystem.main;
            settings.startColor = new ParticleSystem.MinMaxGradient(trait.color);
        }
    }
}
