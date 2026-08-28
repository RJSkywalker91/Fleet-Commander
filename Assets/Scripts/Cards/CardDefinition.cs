using UnityEngine;

public enum CardType
{
  Squadron,
  Powerup,
  Debuff
}

public class CardDefinition : ScriptableObject
{
  public CardType type;
  public string displayName;
  public int supplyCost;  
  
  public GameObject prefab;
}