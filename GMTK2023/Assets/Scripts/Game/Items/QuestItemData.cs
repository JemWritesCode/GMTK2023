using UnityEngine;

[CreateAssetMenu(menuName = "Game/QuestItemData")]
public class QuestItemData : ScriptableObject {
  [field: SerializeField, Header("UI")]
  public Sprite ItemSprite { get; private set; }

  [field: SerializeField]
  public string ItemName { get; private set; }

  [field: SerializeField]
  public string ItemDescription { get; private set; }
}
