using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        int _keys;

        [SerializeField]
        Player _player;

        [SerializeField]
        int _health = 3;
        [SerializeField]
        int _transformationMana = 2;

        [SerializeField]
        UIManager _uiManager;

        public int Health { get { return this._health; } }
        public int TransformationMana { get { return this._transformationMana; } }

        public void Start()
        {
            UpdateHP(0);
            UpdateMANA(0);
            UpdateKeys(0);

            this._player.gameManager = this;
        }

        public void UpdateHP(int val)
        {
            this._health += val;
            this._uiManager.UpdateHP(this._health);
        }
        public void UpdateMANA(int val)
        {
            this._transformationMana += val;
            this._uiManager.UpdateMANA(this._transformationMana);
        }

        public void UpdateKeys(int val)
        {
            this._uiManager.UpdateKeys(this._keys, val);
        }
    }
}