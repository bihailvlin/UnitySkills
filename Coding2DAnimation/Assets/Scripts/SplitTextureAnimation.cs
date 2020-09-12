using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplitTextureAnimation : MonoBehaviour
{
    /// <summary>
    /// 图片有多少行
    /// </summary>
    public int rows;

    /// <summary>
    /// 图片有多少列
    /// </summary>
    public int cols;

    /// <summary>
    /// 图片的总数
    /// </summary>
    public int TotalNumbers;

    /// <summary>
    /// 得到图片渲染的组件
    /// </summary>
    private SpriteRenderer _spriteRender;

    /// <summary>
    /// 图片的集合
    /// </summary>
    public List<Sprite> ListSprites;

    /// <summary>
    /// 运行时帧数一直增加
    /// </summary>
    private int FrameNumbers;

    /// <summary>
    /// 间隔0.1秒刷新一张图片
    /// </summary>
    private const float intervalTime = 0.1f;

    /// <summary>
    /// 运行时减少的帧数
    /// </summary>
    private float interval;

    /// <summary>
    /// 图片的Y轴是否翻转
    /// </summary>
    public bool IsFilpedY;

    /// <summary>
    /// 是否定格图片
    /// </summary>
    public bool IsFreezeFrame;

    /// <summary>
    /// 定格图片时，显示图片的第几帧
    /// </summary>
    public int FreezeFrameNumber;

    /// <summary>
    /// 是否立即暂停动画
    /// </summary>
    public bool IsStopImmediaterly;

    /// <summary>
    /// 是否消耗游戏物体
    /// </summary>
    public bool IsDestroy;
    void Awake()
    {
        _spriteRender = this.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        FrameNumbers = 0;
        interval = intervalTime;
        TotalNumbers = rows * cols;
    }
    void Update()
    {
        interval -= Time.deltaTime;
        int current = 0;
        if (!IsStopImmediaterly)
        {
            if (interval <= 0)
            {
                FrameNumbers++;//一直不断增加
                current = FrameNumbers % TotalNumbers;//取余数 得到图片的索引
                _spriteRender.sprite = ListSprites[current];
                interval = intervalTime;
            }
            if (IsFilpedY)
            {
                current = FrameNumbers % TotalNumbers;//取余数 得到图片的索引
                int rowNumber = cols * (rows - 1 - current / cols);//由于翻转的图片是从左到右 从下往上，这里找到行的总是
                int colNumber = current % cols;//列数
                _spriteRender.sprite = ListSprites[rowNumber + colNumber];//行+列得到图片的索引
            }
        }
        

        if (IsFreezeFrame && current - 1 == FreezeFrameNumber)
        {//是否定格
            IsStopImmediaterly = true;
        }
        //动画播放到最后一张是否销毁物体
        if (current == TotalNumbers-1  && IsDestroy)
            Destroy(this.gameObject);
    }
}
