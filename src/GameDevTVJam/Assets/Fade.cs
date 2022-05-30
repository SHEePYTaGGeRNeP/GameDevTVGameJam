using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image _img;
    [SerializeField]
    float _speed = 1;

    void Start()
    {
        this._img = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this._img.color.a > 0)
        {
            this._img.color = new Color(
                this._img.color.r,
                this._img.color.g,
                this._img.color.b,
                this._img.color.a - (this._speed * Time.deltaTime)
                );
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
