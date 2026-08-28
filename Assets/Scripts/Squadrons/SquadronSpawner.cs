using System;
using UnityEngine;

public class SquadronSpawner : MonoBehaviour
{
    public Squadron Spawn(SquadronDefinition definition, Vector3 position)
    {
        GameObject obj = Instantiate(
            definition.prefab,
            position,
            Quaternion.identity
        );

        if (!obj.TryGetComponent<Squadron>(out var squadron))
        {
          throw new InvalidOperationException(
            $"Prefab for {definition.squadronName} does not contain a Squadron component."
          );
        }
        squadron.Initialize(definition);

        return squadron;
    }
}