using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float playerRange;
    public bool playerMeetsRequirement;

    [SerializeField]
    private Trait trait;
    [SerializeField]
    private float luminanceModifier = 1;
    private SpriteRenderer srEyes;
    private float state;

    public void Start()
    {
        this.srEyes = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (!playerMeetsRequirement)
        {
            state = Mathf.Sin(Time.time * 2) / 2 + 0.5f;
        }
        else
        {
            state = 1;
        }

        this.srEyes.color = new Color(
            trait.color.r * luminanceModifier,
            trait.color.g * luminanceModifier,
            trait.color.b * luminanceModifier,
            state
            );
    }
}
