using UnityEngine;
using System.Collections;

/// <summary>
/// 更换图片的动画
/// </summary>
public class ReplaceImagesAnimation : MonoBehaviour
{
    /// <summary>
    /// 图片数组
    /// </summary>
    public Texture[] Sprites;

    /// <summary>
    /// 动画帧数
    /// </summary>
    public float spriteframe = 20;

    /// <summary>
    /// 运行的帧数
    /// </summary>
    private int Index = 0;

    /// <summary>
    /// 计时器
    /// </summary>
    private float timer = 0.0f;

    /// <summary>
    /// 图片索引
    /// </summary>
    private int spriteIndex = 0;

    /// <summary>
    /// 图片X的反方向
    /// </summary>
    public bool negativeDirectionX;

    /// <summary>
    /// X的反方向
    /// </summary>
    Vector3 ScaleNegativeX;

    /// <summary>
    /// X的正方向
    /// </summary>
    Vector3 ScalePositiveX;
	
    /// <summary>
    /// 是否立即停止
    /// </summary>
    public bool IsStopImmediaterly;

    /// <summary>
    /// 在特定的帧数停止
    /// </summary>
    public bool IsFreezeFrame;

    /// <summary>
    /// 动画定格在第几帧
    /// </summary>
    public int FreezeFrameNumber = 0;

    /// <summary>
    /// 是否消耗动画
    /// </summary>
    public bool destroy;
	
    void Start()
    {
        ScaleNegativeX = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        ScalePositiveX = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

    }

    void Update()
    {// 
        if (!IsStopImmediaterly)
        {
            timer += Time.deltaTime;
            if (timer > (1f / spriteframe))
            {//每一帧
                Index++;
                timer = 0;
                spriteIndex = Index % Sprites.Length;//得到图片的索引
                //this.GetComponent<SpriteRenderer>().sprite = Sprites[spriteIndex];
                GetComponent<Renderer>().material.mainTexture = Sprites[spriteIndex];
            }
        }
        if (negativeDirectionX)
        {//反方向
            this.transform.localScale = ScaleNegativeX;
        }
        else
        {//正方向
            this.transform.localScale = ScalePositiveX;
        }
        if (IsFreezeFrame && spriteIndex == FreezeFrameNumber)
        {//是否定格
            IsStopImmediaterly = true;
        }
        //动画播放到最后一张是否销毁物体
        if (spriteIndex == Sprites.Length - 1 && destroy)
            Destroy(this.gameObject);
    }
}
