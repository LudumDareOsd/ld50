using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    public GameObject tower;
    public int price;
    public int addedCostPerTower;
    private GameObject outline;
    private GameObject priceText;
    private Image image;
    private Color startColor;

    private void Awake() {
        this.outline = transform.Find("Outline").gameObject;
        this.outline.SetActive(false);
        UpdatePriceText();
        this.startColor = this.priceText.GetComponent<TextMeshProUGUI>().color;
        this.image = GetComponent<Image>();
    }

    void Update() {

        if (GameManager.instance.GetMoney() >= price) {
            this.image.color = new Color(1f, 1f, 1f);
            this.priceText.GetComponent<TextMeshProUGUI>().color = this.startColor;
        } else {
            this.image.color = new Color(0.5f, 0.5f, 0.5f);

            this.priceText.GetComponent<TextMeshProUGUI>().color = this.startColor / 2;
        }
    }

    private void UpdatePriceText()
    {

        this.priceText = transform.Find("Price").gameObject;
        this.priceText.GetComponent<TextMeshProUGUI>().text = price.ToString();
    }

    public int TowerBought()
    {
        price += addedCostPerTower;
        UpdatePriceText();
        return price;
    }

    public void OnPointerClick(PointerEventData eventData) {

        if (GameManager.instance.gameOver) {
            return;
        }

        if(GameManager.instance.GetMoney() >= price) {
            var selectTower = new SelectedTower();
            selectTower.name = tower.name;
            selectTower.uiName = gameObject.name;
            selectTower.price = price;
            selectTower.sprite = tower.GetComponentInChildren<SpriteRenderer>().sprite;
            selectTower.position = tower.transform.position;

            PlayerManager.instance.SelectTower(selectTower);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (GameManager.instance.gameOver) {
            return;
        }

        if (GameManager.instance.GetMoney() >= price) {
            this.outline.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        this.outline.SetActive(false);
    }
}
