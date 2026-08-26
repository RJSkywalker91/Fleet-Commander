using UnityEngine;

public class BattleGrid : MonoBehaviour
{
    [SerializeField] private int width = 16;
    [SerializeField] private int height = 9;
    private float cellHeight;
    private float cellWidth;

    public Vector3 GetWorldPosition(int x, int y)
    {
        return transform.position + new Vector3(
            x * cellWidth,
            y * cellHeight,
            0
        );
    }

    public Vector3 GetCellCenter(int x, int y)
    {
        float heightMidpoint = cellHeight / 2f;
        float widthMidpoint = cellWidth / 2f;
        return GetWorldPosition(x, y) + new Vector3(widthMidpoint, heightMidpoint, 0);
    }

    private void CalculateGrid()
    {
        Camera cam = Camera.main;

        if (cam == null)
            return;

        float cameraHeight = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeight * cam.aspect;

        cellWidth = cameraWidth / width;
        cellHeight = cameraHeight / height;

        transform.position = new Vector3(
            cam.transform.position.x - cameraWidth / 2f,
            cam.transform.position.y - cameraHeight / 2f,
            0
        );
    }

    private void Start()
    {
        CalculateGrid();
    }

    private void OnDrawGizmos()
    {
        CalculateGrid();

        if (cellHeight <= 0 || cellWidth <= 0)
            return;

        for (int x = 0; x <= width; x++)
        {
            Gizmos.DrawLine(
                GetWorldPosition(x, 0),
                GetWorldPosition(x, height)
            );
        }
        for (int y = 0; y <= height; y++)
        {
            Gizmos.DrawLine(
                GetWorldPosition(0, y),
                GetWorldPosition(width, y)
            );
        }
    }
}
