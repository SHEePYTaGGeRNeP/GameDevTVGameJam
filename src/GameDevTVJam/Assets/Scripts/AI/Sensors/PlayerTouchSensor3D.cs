using Assets.Scripts.GamePlay;
using System;
using UnityEngine;

namespace Assets.Scripts.AI.Sensors
{
    class PlayerTouchSensor3D : TouchSensor3D
    {
        [Header("Debug PlayerTouchSensor3D")]
        [SerializeField]
        private Player _player;
        public Player Player { get => _player; set => _player = value; }

        protected override void OnTouchEnter(GameObject other)
        {
            Player p = other.GetComponentInParent<Player>();
            this.Player = p ?? throw new Exception("We should have caught this in CanTouch");
        }

        protected override void OnTouchExit(GameObject other)
        {
            Player p = other.GetComponentInParent<Player>();
            if (p == null)
                throw new Exception("We should have caught this in CanTouch");
            this.Player = null;
        }

        protected override bool CanTouch(GameObject other) => other.GetComponentInParent<Player>() != null;

    }
}
