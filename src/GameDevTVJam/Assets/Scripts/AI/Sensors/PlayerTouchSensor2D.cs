//using System;
//using UnityEngine;

//namespace Assets.Scripts.AI.Sensors
//{
//    class PlayerTouchSensor2D //: TouchSensor2D
//    {
//        [Header("Debug PlayerTouchSensor2D")]
//        [SerializeField]
//        private PlayerToTestSensor _player;
//        public PlayerToTestSensor Player { get => _player; set => _player = value; }

//        protected override void OnTouchEnter2D(GameObject other)
//        {
//            PlayerToTestSensor p = other.GetComponentInParent<PlayerToTestSensor>();
//            this.Player = p ?? throw new Exception("We should have caught this in CanTouch");
//        }

//        protected override void OnTouchExit2D(GameObject other)
//        {
//            PlayerToTestSensor p = other.GetComponentInParent<PlayerToTestSensor>();
//            if (p == null)
//                throw new Exception("We should have caught this in CanTouch");
//            this.Player = null;
//        }

//        protected override bool CanTouch2D(GameObject other) => other.GetComponentInParent<PlayerToTestSensor>() != null;

//    }
//}
