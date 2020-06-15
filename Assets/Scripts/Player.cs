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

    public void TakeEffect(Effect.Type type, float time, float value)
    {
        switch (type)
        {
            case Effect.Type.Speed:
                _movement.ChangeSpeed(time, value);
                break;
        }
    }
}
