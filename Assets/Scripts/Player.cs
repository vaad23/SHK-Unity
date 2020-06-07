using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void TakeEffect(EffectEnum effect, float time, float value)
    {
        switch (effect)
        {
            case EffectEnum.Speed:
                _movement.ChangeSpeed(time, value);
                break;
        }
    }
}
