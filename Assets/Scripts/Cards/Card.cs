using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string Id { get; private set; }
    public CardDefinition Definition { get; private set; }
    public CardType Type { get; private set; }
    public string DisplayName { get; private set; }
    public int SupplyCost { get; private set; }
    public event Action<Card> Played;

    public void Initialize(CardDefinition definition)
    {
        if (definition == null)
        {
        throw new InvalidOperationException(
            "Cannot Initialize a card without a definition."
        );
        }
        if (definition.supplyCost < 0)
        {
        throw new ArgumentOutOfRangeException(
            "Definition cannot have a SupplyCost less than 0."
        );
        }
        Id = Guid.NewGuid().ToString();
        Definition = definition;
        DisplayName = definition.displayName;
        Type = definition.type;
        SupplyCost = definition.supplyCost;
    }

    private void OnMouseDown()
    {
        Played?.Invoke(this);
    }
}