using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class TowerGridPlace : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PlaceIndicator; // The prefab used to indicate where you can place the turret.
    [SerializeField] private GameObject tower; // The prefab for the actual turret.
    private bool dragging = false; // A flag to determine if you're currently dragging the indicator.
    private Vector3 mousePosition; // The current mouse position in world coordinates.
    private GameObject placedIndicator; // A reference to the instantiated placement indicator.
    [SerializeField] private Tilemap gridTilemap; // Reference to your grid Tilemap where you want to snap the turret.
    private Vector3 gridCellSize = new Vector3(2f, 2f, 0f); // The size of the grid cells.
    public float tweenDuration = 0.5f; // The duration of the position tween when snapping the indicator.

    public void Update()
    {
        // Get the mouse position in world coordinates.
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        // If you're currently dragging the indicator, update its position.
        if (dragging && placedIndicator != null)
        {
            // Snap the indicator's position to the nearest grid point.
            Vector3Int cellPosition = gridTilemap.WorldToCell(mousePosition);
            Vector3 snappedPosition = gridTilemap.GetCellCenterWorld(cellPosition);

            // Use DoTween to smoothly tween the indicator's position.
            placedIndicator.transform.DOMove(snappedPosition, tweenDuration);
        }

        // If you left-click, place the turret at the indicator's position and destroy the indicator.
        if (Input.GetMouseButtonDown(0))
        {
            if (placedIndicator != null)
            {
                // Instantiate the actual turret at the position of the indicator.
                Instantiate(tower, placedIndicator.transform.position, Quaternion.identity);

                // Destroy the placement indicator.
                Destroy(placedIndicator);
            }
        }
    }

    public void TurretToMouse()
    {
        if (!dragging)
        {
            dragging = true;

            // Find the grid cell position of the mouse cursor and snap the indicator to it.
            Vector3Int cellPosition = gridTilemap.WorldToCell(mousePosition);
            Vector3 snappedPosition = gridTilemap.GetCellCenterWorld(cellPosition);

            // Instantiate the placement indicator at the snapped position.
            placedIndicator = Instantiate(PlaceIndicator, snappedPosition, Quaternion.identity);
        }
        else
        {
            // If already dragging, stop dragging.
            dragging = false;
        }
    }
}
