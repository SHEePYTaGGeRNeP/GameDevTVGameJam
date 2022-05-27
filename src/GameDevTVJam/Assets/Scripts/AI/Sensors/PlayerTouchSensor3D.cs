using System;
using UnityEngine;

namespace Assets.Scripts.AI.Sensors
{
    class PlayerTouchSensor3D : TouchSensor3D
    {
        [Header("Debug PlayerTouchSensor3D")]
        [SerializeField]
        private PlayerToTestSensor _player;
        public PlayerToTestSensor Player { get => _player; set => _player = value; }

        protected override void OnTouchEnter(GameObject other)
        {
            PlayerToTestSensor p = other.GetComponentInParent<PlayerToTestSensor>();
            this.Player = p ?? throw new Exception("We should have caught this in CanTouch");
        }

        protected override void OnTouchExit(GameObject other)
        {
            PlayerToTestSensor p = other.GetComponentInParent<PlayerToTestSensor>();
            if (p == null)
                throw new Exception("We should have caught this in CanTouch");
            this.Player = null;
        }

        protected override bool CanTouch(GameObject other) => other.GetComponentInParent<PlayerToTestSensor>() != null;

    }
}
