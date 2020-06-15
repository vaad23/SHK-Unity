using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> DamageTaking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            DamageTaking?.Invoke(this);
    }
}
