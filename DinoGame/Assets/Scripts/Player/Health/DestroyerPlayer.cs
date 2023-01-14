using UnityEngine;

public class DestroyerPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void Start()
    {
        _player.Health.OnDeath += RemovePlayer;
    }
    private void RemovePlayer()
    {
        _player.MovementInformation.Rigidbody2D.velocity = Vector2.zero;
        _player.IMovable = null;
        _player.MovementInformation.Rigidbody2D.gravityScale = 0;
    }
    private void OnDisable()
    {
        _player.Health.OnDeath -= RemovePlayer;
    }
}
