using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GamePlay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        int _keys;

        [SerializeField]
        Player _player;

        public Player CurrPlayer { get { return this._player; } }

        [SerializeField]
        int _health = 3;
        [SerializeField]
        int _transformationMana = 2;

        int _healthDefault = 3;
        int _transformationManaDefault = 2;

        [SerializeField]
        UIManager _uiManager;

        public int Health { get { return this._health; } }
        public int TransformationMana { get { return this._transformationMana; } }

        public void Start()
        {
            UpdateHP(0);
            UpdateMANA(0);
            UpdateKeys(0);

            this._healthDefault = this._health;
            this._transformationManaDefault = this._transformationMana;

            this._player.gameManager = this;
        }

        public void UpdateHP(int val)
        {
            this._health += val;
            this._uiManager.UpdateHP(this._health);

            if(this._health <= 0) SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        public void UpdateMANA(int val)
        {
            this._transformationMana += val;
            this._uiManager.UpdateMANA(this._transformationMana);

            if (this._transformationMana == 0)
            {
                this._transformationMana = this._transformationManaDefault;
                this._health = this._healthDefault;
            }
        }

        public void UpdateKeys(int val)
        {
            this._uiManager.UpdateKeys(this._keys, val);

            if(this._keys == val) SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}