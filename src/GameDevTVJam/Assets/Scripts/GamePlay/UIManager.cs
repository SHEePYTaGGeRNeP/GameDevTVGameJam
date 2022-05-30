using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GamePlay
{
    internal class UIManager : MonoBehaviour
    {
        [SerializeField]
        Image[] _Keys;
        [SerializeField]
        Image[] _HP;
        [SerializeField]
        Image[] _MANA;

        public void UpdateKeys(int currKeys, int collected)
        {
            Debug.Log(collected);
            for (int i = 0; i < _Keys.Length; i++)
            {
                if (currKeys >= i + 1)
                {
                    _Keys[i].enabled = true;
                    if (collected >= i + 1) _Keys[i].color = Color.yellow;
                    else _Keys[i].color = Color.gray;
                }
                else
                {
                    _Keys[i].enabled = false;
                }
            }
        }

        public void UpdateHP(int currHP)
        {
            for (int i = 0; i < _HP.Length; i++)
            {
                if (currHP >= i + 1)
                {
                    _HP[i].enabled = true;
                }
                else
                {
                    _HP[i].enabled = false;
                }
            }
        }

        public void UpdateMANA(int currMANA)
        {
            for (int i = 0; i < _MANA.Length; i++)
            {
                if (currMANA >= i + 1)
                {
                    _MANA[i].enabled = true;
                }
                else
                {
                    _MANA[i].enabled = false;
                }
            }
        }
    }
}