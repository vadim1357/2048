using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlay : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRender;
    public int powerOfTwo;

    [SerializeField] private List<CellStyle> cellStyles;
    public void SwipeLeft()
    {

    }
    public void ApplyStyle(int styleIndex)
    {
        var style = GetCellStyleByIndex(styleIndex);   
    }
    private CellStyle GetCellStyleByIndex(int StyleIndex)
    {
        throw new System.NotImplementedException();
    }

}


[System.Serializable]
public class CellStyle
{
    
    public Material material;
    public Color color;
}
