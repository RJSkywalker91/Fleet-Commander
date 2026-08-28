using System;
using UnityEngine;

public class Squadron : MonoBehaviour
{
  public string Id { get; private set; }
  public SquadronDefinition Definition { get; private set; }

  public float CurrentHealth { get; private set; }
  public float CurrentShields { get; private set; }
  public float MoveSpeed { get; private set; }
  private Vector3? targetPosition;
  
  public void Initialize(SquadronDefinition definition)
  {
    if (definition == null)
    {
      throw new InvalidOperationException(
        "Cannot Initialize a squadron without a definition."
      );
    }
    if (definition.hullIntegrity <= 0 || definition.damage <= 0 || definition.shields < 0)
    {
      throw new ArgumentOutOfRangeException(
        "Definition cannot have a Hull Integretiy less than 1, Damage less than 1, or Shields less than 0."
      );
    }
    Id = Guid.NewGuid().ToString();
    Definition = definition;
    CurrentHealth = definition.hullIntegrity;
    CurrentShields = definition.shields;
    MoveSpeed = definition.speed;
  }

  public void Update()
  {
    if (targetPosition == null)
      return;

    transform.position = Vector3.MoveTowards(
      transform.position,
      targetPosition.Value,
      MoveSpeed * Time.deltaTime
    );

    if (transform.position == targetPosition.Value)
    {
      targetPosition = null;
    }
  }

  public void MoveTo(Vector3 position)
  {
    targetPosition = position;
  }

  public void TakeDamage(float amount)
  {
    float shieldDamage = Mathf.Min(CurrentShields, amount);
    CurrentShields -= shieldDamage;

    float remainingDamage = amount - shieldDamage;
    CurrentHealth -= remainingDamage;
  }
  
  private void OnDrawGizmos()
  {
    if (targetPosition == null)
      return;

    Gizmos.DrawLine(transform.position, targetPosition.Value);
  }
}