using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellPlay : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRender;
    public int powerOfTwo;
    [SerializeField] private Rigidbody rigid;

    [SerializeField] private List<CellStyle> cellStyles;

    private int index;
    private void OnEnable()
    {
        index = 0;
        ApplyStyle(index);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            ApplyStyle(index);
        }
    }
    public void SwipeLeft()
    {
        rigid.velocity = Vector3.left*10;
    }
    public void SwipeRight()
    {
        rigid.velocity = Vector3.right * 10;
    }
    public void SwipeUp()
    {
        rigid.velocity = Vector3.up * 10;
    }
    public void SwipeDown()
    {
        rigid.velocity = Vector3.down * 10;
    }
    public void ApplyStyle(int styleIndex)
    {
        var style = GetCellStyleByIndex(styleIndex);
        meshRender.material= style.material;
        meshRender.material.color = style.color;

    }
    private CellStyle GetCellStyleByIndex(int StyleIndex)
    {
        StyleIndex %= cellStyles.Count;
        return cellStyles[StyleIndex];
    }

}


[System.Serializable]
public class CellStyle
{
    
    public Material material;
    public Color color;
}
