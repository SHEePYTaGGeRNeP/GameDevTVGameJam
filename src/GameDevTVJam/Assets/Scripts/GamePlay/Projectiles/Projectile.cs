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

        public void SetElement(Trait trait)
        {
            if(this._elementTOT == null)
            {
                this._elementTOT = this.gameObject.GetComponent<ElementTakeOverTrigger>();
            }

            this._elementTOT.Element = trait;
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
            if(collision.gameObject.tag == "Player")
            {
                bool deleteOriginal;
                Player player = collision.gameObject.GetComponent<Player>();
                player.Hit_Damage(this.CreatedBy.transform, this._elementTOT.Element, out deleteOriginal);

                if (deleteOriginal)
                {
                    player.gameObject.transform.position = this.CreatedBy.transform.position;
                    this.CreatedBy.gameObject.SetActive(false);
                    Debug.Log("FKAOWJKOAJODWOJAD");
                    //GameObject.Find("GameManager").GetComponent<GameManager>().
                }
            }

            Destroy(this.gameObject);
        }
    }
}
