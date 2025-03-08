using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_TileView : MonoBehaviour
{
    private int widthID = -1;
    private int heightID = -1;

    public void SetID(int x, int y)
    {
        widthID = x;
        heightID = y;
    }

    public void UpdateTileView()
    {
        ColorBall_StatusManager.GridType gridStatus = ColorBall_StatusManager.Instance.GetGridType(widthID, heightID);
        Material tileMaterial = this.gameObject.GetComponent<Renderer>().material;

        switch (gridStatus)
        {
            case ColorBall_StatusManager.GridType.NormalTile:
                tileMaterial.color = Color.black;
                return;
            case ColorBall_StatusManager.GridType.RedTile:
                tileMaterial.color = Color.red;
                return;
            case ColorBall_StatusManager.GridType.BlueTile:
                tileMaterial.color = Color.blue;
                return;
        }
    }
}
