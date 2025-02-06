using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    public float speedBoost = 5f;
    public float duration = 5f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.ApplySpeedBoost(speedBoost, duration);
        }
    }
}
