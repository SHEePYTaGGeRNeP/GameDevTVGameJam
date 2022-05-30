using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _lifeTime = 5f;

        public GameObject CreatedBy { get; set; }

        private ElementTakeOverTrigger _elementTOT;

        private void Start()
        {
            this._elementTOT = this.gameObject.GetComponent<ElementTakeOverTrigger>();
        }


        private void Update()
        {
            float step = this._speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.transform.position + this.transform.right, step);
            _lifeTime -= Time.deltaTime;
            if (_lifeTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // do some damage?
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().Hit_Damage(this._elementTOT.Element);
            }

            Destroy(this.gameObject);
        }
    }
}
