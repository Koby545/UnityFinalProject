using UnityEngine;

public class JumpPowerUp : PowerUp
{
    public float jumpBoost = 2f;
    public float duration = 5f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.ApplyJumpBoost(jumpBoost, duration);
        }
    }
}

