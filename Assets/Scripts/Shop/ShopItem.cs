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

        [SerializeField] private BuyItemButton buyItemButton;
        [SerializeField] private SetPlayerButton setPlayerButton;
       
        public void SetItem(CarProperties properties, ShopItemState state)
        {
            properties = Instantiate(properties);
            nameText.text = properties.name;
            maxHealthText.text = textBeforeMaxHealth + properties.maxHealth.ToString();
            maxSpeedText.text = textBeforeMaxSpeed + properties.maxSpeed.ToString();

            buyItemButton.SetItemID(properties.type, properties.price);
            setPlayerButton.thisButtonCarProperties = properties;
            ReloadItemButtons(state);
        }

        public void ReloadItemButtons(ShopItemState itemState)
        {
            switch (itemState)
            {
                case ShopItemState.AbleToBuy:
                    buyButton.gameObject.SetActive(true);
                    useButton.gameObject.SetActive(false); 
                    break;
                case ShopItemState.AbleToSelect:
                    buyButton.gameObject.SetActive(false);
                    useButton.gameObject.SetActive(true);
                    break;
                case ShopItemState.Selected:
                    buyButton.gameObject.SetActive(false);
                    useButton.gameObject.SetActive(false);
                    break;
            }
        }
    }
}