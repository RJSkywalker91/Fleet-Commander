using System;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public Card Spawn(CardDefinition definition, Vector3 position)
    {
        GameObject obj = Instantiate(
            definition.prefab,
            position,
            Quaternion.identity
        );

        if (!obj.TryGetComponent<Card>(out var card))
        {
          throw new InvalidOperationException(
            $"Prefab for {definition.displayName} does not contain a Card component."
          );
        }
        card.Initialize(definition);

        return card;
    }
}