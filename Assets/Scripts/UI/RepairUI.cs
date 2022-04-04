using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RepairUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    public int price;
    private GameObject outline;
    private GameObject priceText;
    private Image image;
    private Color startColor;

    private void Awake() {
        this.outline = transform.Find("Outline").gameObject;
        this.outline.SetActive(false);

        this.priceText = transform.Find("Price").gameObject;
        this.priceText.GetComponent<TextMeshProUGUI>().text = price.ToString();
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

    public void OnPointerClick(PointerEventData eventData) {
        if (GameManager.instance.gameOver) {
            return;
        }

        if (GameManager.instance.GetMoney() >= price) {
            GameManager.instance.AddHp(20, price);
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
