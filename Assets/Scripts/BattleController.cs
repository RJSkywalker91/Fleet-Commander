using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    private SquadronSpawner squadronSpawner;

    [SerializeField]
    private CardSpawner cardSpawner;

    [SerializeField]
    private CardDefinition test;

    private void OnCardPlayed(Card card)
    {
      Debug.Log($"Played {card.Definition.displayName}");
      if (card.Definition is SquadronCardDefinition squadronCard)
      {
        Squadron squadron = squadronSpawner.Spawn(
          squadronCard.squadron,
          Vector3.zero
        );
        Destroy(card.gameObject);
        squadron.MoveTo(new Vector3(5, 2, 0));
      }
    }

    private void Start()
    {
      CreateCard(test);
    }

    public void CreateCard(CardDefinition definition)
    {
      Card card = cardSpawner.Spawn(definition, Vector3.zero);
      card.Played += OnCardPlayed;
    }

}