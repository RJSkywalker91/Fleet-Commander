using System;
using UnityEngine;

public class CardView : MonoBehaviour
{
    private CardInstance instance;
    public event Action<CardView> Played;

    public void Initialize(CardInstance card)
    {
        instance = card;
    }

    public CardDefinition GetDefinition() => instance.Definition;

    private void OnMouseDown()
    {
        Played?.Invoke(this);
    }

    // [SerializeField] private TMP_Text nameText;
    // [SerializeField] private TMP_Text costText;
    // [SerializeField] private SpriteRenderer artwork;

    // public void Initialize(CardDefinition definition)
    // {
    //     nameText.text = definition.cardName;
    //     costText.text = definition.cost.ToString();
    //     artwork.sprite = definition.artwork;
    // }
}
