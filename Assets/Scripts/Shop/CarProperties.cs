using UnityEngine;

[CreateAssetMenu(fileName = "Car Properties", menuName = "ScriptableObjects/Cars", order = 1)]
public class CarProperties : ScriptableObject
{
  public int ID;
  public string name;
  public int maxHealth;
  public int maxSpeed;
  public string description;
  public Sprite previewSprite;
  public int price;
}
