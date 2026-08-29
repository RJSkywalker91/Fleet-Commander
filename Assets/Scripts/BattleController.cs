using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private SquadronSpawner squadronSpawner;

    [SerializeField] private CardSpawner cardSpawner;

    [SerializeField] private BattleGrid battleGrid;

    [SerializeField] private CardDefinition test;

    private void OnCardPlayed(CardView view)
    {
      CardInstance instance = view.GetInstance();
      Debug.Log($"Played {instance.Definition.displayName}");
      if (instance.Definition is SquadronCardDefinition squadronCard)
      {
        Vector3 spawnPosition = battleGrid.GetCellCenter(0, 0);
        Squadron squadron = squadronSpawner.Spawn(
          squadronCard.squadron,
          spawnPosition
        );
        Destroy(view.gameObject);
        squadron.MoveTo(battleGrid.GetCellCenter(5, 2));
      }
    }

    private void Start()
    {
      CreateCard(test);
    }

    public void CreateCard(CardDefinition definition)
    {
      CardView view = cardSpawner.Spawn(definition, Vector3.zero);
      view.Played += OnCardPlayed;
    }

}