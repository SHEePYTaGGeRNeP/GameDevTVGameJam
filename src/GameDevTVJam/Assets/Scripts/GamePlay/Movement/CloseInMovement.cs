using Assets.Scripts.AI.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Movement
{
    public class CloseInMovement : MovementBase
    {
        [SerializeField]
        private PlayerTouchSensor2D _playerSensor;

        private void Update()
        {
            if (_playerSensor.Player == null)
            {
                return;
            }
            targetPosition = _playerSensor.Player.transform.position;
            MoveToTargetPosition();
        }
    }
}
