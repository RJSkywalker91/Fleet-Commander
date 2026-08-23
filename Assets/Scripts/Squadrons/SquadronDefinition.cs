using UnityEngine;

[CreateAssetMenu(fileName = "NewSquadron", menuName = "Game/Squadron")]
public class SquadronDefinition : ScriptableObject
{
  public string squadronName;
  public float hullIntegrity;
  public float damage;
  public float shields;
  public float speed;

  public GameObject prefab;
}