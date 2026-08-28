using UnityEngine;

[CreateAssetMenu(
  fileName = "NewSquadronCard",
  menuName = "Game/Cards/Squadron"
)]
public class SquadronCardDefinition : CardDefinition
{
  public SquadronDefinition squadron;
}