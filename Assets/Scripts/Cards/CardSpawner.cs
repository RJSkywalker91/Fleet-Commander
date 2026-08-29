using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private CardView cardPrefab;

    public CardView Spawn(CardDefinition definition, Vector3 position)
    {
        CardInstance instance = new(definition);
        CardView view = Instantiate(cardPrefab, position, Quaternion.identity);
        view.Initialize(instance);
        
        return view;
    }
}