using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private SquadronSpawner squadronSpawner;

    [SerializeField] private CardSpawner cardSpawner;

    [SerializeField] private BattleGrid battleGrid;

    [SerializeField] private CardDefinition test;

    private void OnCardPlayed(Card card)
    {
      Debug.Log($"Played {card.Definition.displayName}");
      if (card.Definition is SquadronCardDefinition squadronCard)
      {
        Vector3 spawnPosition = battleGrid.GetCellCenter(0, 0);
        Squadron squadron = squadronSpawner.Spawn(
          squadronCard.squadron,
          spawnPosition
        );
        Destroy(card.gameObject);
        squadron.MoveTo(battleGrid.GetCellCenter(5, 2));
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