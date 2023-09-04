using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text maxHealthText;
        [SerializeField] private TMP_Text maxSpeedText;

        [SerializeField] private Button buyButton;
        [SerializeField] private Button useButton;

        [SerializeField] private string textBeforeMaxHealth;
        [SerializeField] private string textBeforeMaxSpeed;

        public void SetItem(CarProperties properties, bool showUseButton)
        {
            properties = Instantiate(properties);
            nameText.text = properties.name;
            maxHealthText.text = textBeforeMaxHealth + properties.maxHealth.ToString();
            maxSpeedText.text = textBeforeMaxSpeed + properties.maxSpeed.ToString();
            
            buyButton.gameObject.SetActive(!showUseButton);
            useButton.gameObject.SetActive(showUseButton);
        }
    }
}