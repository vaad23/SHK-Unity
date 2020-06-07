using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Effect : MonoBehaviour
{
    [SerializeField] private EffectEnum _effect;
    [SerializeField] private float _time;
    [SerializeField] private float _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeEffect(_effect, _time, _value);
            gameObject.SetActive(false);
        }
    }
}
