using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private StarterGame _starterGame;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        _animator.SetTrigger("Appear");
        _starterGame.OnStartGame += PlayAppearingAnimation;
        _player.OnJump += PlayJumpAnimation;
        _player.Health.OnChangeHealth += PlayApplyDamageAnimation;
        _player.Health.OnDeath += PlayDeathAnimation;
    }
    private void PlayAppearingAnimation()
    {
        _animator.SetTrigger("EscapeFromEgg");
    }
    private void PlayDeathAnimation()
    {
        _animator.SetBool("Dead",true);
        _animator.SetTrigger("Death");
    }
    private void PlayApplyDamageAnimation()
    {
        _animator.SetTrigger("ApplyDamage");
    }
    private void PlayJumpAnimation()
    {
        _animator.SetTrigger("Jump");
    }
    private void OnDisable()
    {
        _player.OnJump -= PlayJumpAnimation;
        _starterGame.OnStartGame -= PlayAppearingAnimation;
        _player.Health.OnChangeHealth -= PlayApplyDamageAnimation;
        _player.Health.OnDeath -= PlayDeathAnimation;
    }
}
