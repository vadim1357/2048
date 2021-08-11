using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellPlay : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRender;
    
    [SerializeField] private Rigidbody rigid;

    [SerializeField] private List<CellStyle> cellStyles;
    [SerializeField] private int speed;

    public Vector3 Velocity { get; private set; }

    public int index;
    public int PowerOfTwo 
    {
        get
        {
            return index;
        }
    }
    private void OnEnable()
    {
        int rn = Random.Range(0, 5);
        
        if (rn == 1)
        {
            index = 1;
        }
        else
        {
            index = 0;
        }
        
        ApplyStyle(index);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // надо убрать 41-44!
        {
            NextIndex();
        }
        if(rigid.velocity != Velocity)
        {
            rigid.velocity = Vector3.zero;
        }
    }
    public void SwipeLeft()
    {
        rigid.velocity = Vector3.left*speed;
        Velocity = Vector3.left * speed;
    }
    public void SwipeRight()
    {
        rigid.velocity = Vector3.right * speed;
        Velocity = Vector3.right * speed;
    }
    public void SwipeUp()
    {
        rigid.velocity = Vector3.up * speed;
        Velocity = Vector3.up * speed;
    }
    public void SwipeDown()
    {
        rigid.velocity = Vector3.down * speed;
        Velocity = Vector3.down * speed;
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
    public void NextIndex()
    {
        index++;
        ApplyStyle(index);
    }
    public bool IsMoving()
    {
        return rigid.velocity.magnitude > 0.01f; 
    }
}


[System.Serializable]
public class CellStyle
{
    
    public Material material;
    public Color color;
}
