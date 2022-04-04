using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    private SelectedTower tower;
    private GameObject selectedTower;
    private GameObject mouseCollider;
    private GameObject uppgradePrice;

    private ContactFilter2D contactFilter;
    private ContactFilter2D uppgradeContactFilter;
    private float gridSize = 0.125f;

    private List<Tower> towers = new List<Tower>();

    private void Awake() {

        if (PlayerManager.instance != null) {
            Destroy(this);
        } else {
            PlayerManager.instance = this;
            selectedTower = GameObject.Find("SelectedTower");
            mouseCollider = GameObject.Find("MouseCollider");
            uppgradePrice = GameObject.Find("UppgradePrice");

            uppgradePrice.SetActive(false);

            contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Tower"));
            contactFilter.useLayerMask = true;
            contactFilter.useTriggers = true;

            uppgradeContactFilter = new ContactFilter2D();
            uppgradeContactFilter.SetLayerMask(LayerMask.GetMask("Uppgrade"));
            uppgradeContactFilter.useLayerMask = true;
            uppgradeContactFilter.useTriggers = true;
        }
    }

    public void AddTower(Tower tower) {
        this.towers.Add(tower);
    }

    public void SelectTower(SelectedTower tower) {
        this.tower = tower;
        selectedTower.GetComponent<SpriteRenderer>().sprite = tower.sprite;
    }

    public void Update() {

        if(GameManager.instance.gameOver || !GameManager.instance.started) {
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        {
            var worldpos = Camera.main.ScreenToWorldPoint(mousePos);

            mouseCollider.transform.position = worldpos;
            selectedTower.transform.position = worldpos;
            selectedTower.transform.position = new Vector3(RoundToNearestGridX(selectedTower.transform.position.x + 0.125f), RoundToNearestGridY(selectedTower.transform.position.y), -1);
        }

        if (Input.GetMouseButtonDown(0)) {
            var targetCollider = mouseCollider.GetComponent<CircleCollider2D>();

            var uppcolliders = new List<Collider2D>();
            targetCollider.OverlapCollider(uppgradeContactFilter, uppcolliders);

            var uppgraded = false;

            foreach (var uppColl in uppcolliders) {
                var tower = uppColl.GetComponentInParent<Tower>();
                tower.Uppgrade();
                uppgraded = true;
            }

            var colliders = new List<Collider2D>();
            targetCollider.OverlapCollider(contactFilter, colliders);

            Tower clickedTower = null;

            if (!uppgraded) {
                foreach (var collider in colliders) {
                    var tower = collider.GetComponent<Tower>();

                    clickedTower = tower;
                    clickedTower.ShowUppgrade(uppgradePrice);

                    break;
                }
            }

            foreach (var t in towers) {
                if (!t.Equals(clickedTower)) {
                    t.HideUppgrade();

                    if (clickedTower == null) {
                        uppgradePrice.SetActive(false);
                    }
                }
            }

        }

        if (selectedTower.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Terrain", "Tower"))) {
            selectedTower.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.2f, 0.2f, 1);
        } else {
            selectedTower.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            if (Input.GetMouseButtonDown(0)) {
                if (tower != null) {
                    if (GameManager.instance.GetMoney() >= tower.price) {
                        Instantiate(Resources.Load(tower.name) as GameObject, selectedTower.transform.position, selectedTower.transform.rotation);
                        GameManager.instance.AddMoney(-tower.price);
                        tower.price = GameObject.Find(tower.uiName).GetComponent<TowerUI>().TowerBought();
                        if (GameManager.instance.GetMoney() < tower.price) {
                            tower = null;
                            selectedTower.GetComponent<SpriteRenderer>().sprite = null;
                        }
                    }

                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            tower = null;
            selectedTower.GetComponent<SpriteRenderer>().sprite = null;
            uppgradePrice.SetActive(false);
        }
    }

    public void HideAll() {
        tower = null;
        selectedTower.GetComponent<SpriteRenderer>().sprite = null;
        uppgradePrice.SetActive(false);
    }

    float RoundToNearestGridX(float pos) {
        float xDiff = pos % gridSize;
        pos -= (xDiff + 0.125f);
        if (xDiff > (gridSize / 2)) {
            pos += gridSize;
        }
        return pos;
    }

    float RoundToNearestGridY(float pos) {
        float xDiff = pos % gridSize;
        pos -= (xDiff);
        if (xDiff > (gridSize / 2)) {
            pos += gridSize;
        }
        return pos;
    }
}
