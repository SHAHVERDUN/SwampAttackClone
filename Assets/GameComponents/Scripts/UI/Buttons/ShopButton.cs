using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private Shop _shop;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        _shop.gameObject.SetActive(false);
    }

    private void OnButtonClick()
    {
        if (_shop.gameObject.activeSelf == false)
        {
            _shop.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (_shop.gameObject.activeSelf == true)
        {
            _shop.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}