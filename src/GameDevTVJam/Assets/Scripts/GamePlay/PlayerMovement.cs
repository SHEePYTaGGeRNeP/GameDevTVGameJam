using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Control options")]
        [SerializeField]
        private float _speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            this._rigidbody = this.GetComponentInChildren<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 moveDir = new Vector2(x, y);
            if (Mathf.Abs(x) + Mathf.Abs(y) > 1) moveDir = moveDir.normalized;
            this._rigidbody.velocity = new Vector2(moveDir.x * this._speed, moveDir.y * this._speed);
        }
    }
}
