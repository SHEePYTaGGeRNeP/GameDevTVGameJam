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

            this.transform.position += new Vector3(x * this._speed * Time.deltaTime, y * this._speed * Time.deltaTime, 0);
        }
    }
}
