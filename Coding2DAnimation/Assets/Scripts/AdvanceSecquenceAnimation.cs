using UnityEngine;
using System.Collections;

public class AdvanceSecquenceAnimation : MonoBehaviour
{

    /// <summary>
    /// 图片是否上下颠倒了
    /// </summary>
    public bool IsTextureNegativeY = false;

    /// <summary>
    /// 用于翻转上下颠倒的图片
    /// </summary>
    int DirectionY = 1;

    /// <summary>
    /// 动画的帧数
    /// </summary>
    public int AnimationSpeed = 5;

    /// <summary>
    /// 图片的行数
    /// </summary>
    public int RowXNumber=0;//根据动画的帧数设置相应的值

    /// <summary>
    /// 图片的列数
    /// </summary>
    public int ColumnYNumber=0;

    /// <summary>
    /// 总共有多少张图片
    /// </summary>
    int totalCount = 0;

    /// <summary>
    /// 图片的宽度
    /// </summary>
    float TextureWidth = 0;

    /// <summary>
    /// 图片的高度
    /// </summary>
    float TextureHeigth = 0;

    /// <summary>
    /// 图片X方向偏移量
    /// </summary>
    float offsetX = 0;

    /// <summary>
    /// 图片Y方向的偏移量
    /// </summary>
    float offsetY = 0;

    /// <summary>
    /// 计时器
    /// </summary>
    float Timer = 0;

    /// <summary>
    /// 运行时累加动画的帧数
    /// </summary>
    int Index = 0;


    /// <summary>
    /// 是否立即停止动画
    /// </summary>
    public bool StopImmediaterly;

    /// <summary>
    /// 当前图片的索引
    /// </summary>
    int FramIndex = 0;


    /// <summary>
    /// 在特定的帧数停止
    /// </summary>
    public bool IsStopAtFrame;

    /// <summary>
    /// 动画停留在第几张图片上
    /// </summary>
    public int StopFrameNumber = 0;




    /// <summary>
    /// 图片的X是否左右相反
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
    /// 设置动画播放完之后是否销毁物体
    /// </summary>
    public bool IsDestroy;
    void Start()
    {
        totalCount = RowXNumber * ColumnYNumber;//行和列相乘得到总共的图片数量
        TextureWidth = 1.0f / RowXNumber;//图片的宽度
        TextureHeigth = 1.0f / ColumnYNumber;//图片的高度
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(TextureHeigth, TextureWidth);

        ScaleNegativeX = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        ScalePositiveX = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (!StopImmediaterly)
        {
            Timer += Time.deltaTime;
            if (IsTextureNegativeY)
            {//图片是否颠倒
                Index = (int)(Timer * AnimationSpeed) + ColumnYNumber;
                DirectionY = -1;
            }
            else
            {
                Index = (int)(Timer * AnimationSpeed);
                DirectionY = 1;
            }
            FramIndex = Index % totalCount;
            offsetX = (float)(FramIndex % ColumnYNumber) / ColumnYNumber;//X偏移
            float rowFrame = (FramIndex - FramIndex % (float)ColumnYNumber); //得到的是索引所在的行号
            offsetY = rowFrame / ColumnYNumber / RowXNumber;//Y偏移
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY * DirectionY);
        }

        if (negativeDirectionX)
        {//X的反方向
            this.transform.localScale = ScaleNegativeX;
        }
        else
        {//X的正方向
            this.transform.localScale = ScalePositiveX;
        }

        if (FramIndex == RowXNumber - 1 && IsDestroy)
            Destroy(this.gameObject); //动画播放完之后销毁

        if (StopFrameNumber != 0 && IsStopAtFrame)
        {//动画停止后定格在第StopFrameNumber张图片上。
            if (FramIndex == StopFrameNumber - 1)
            {
                StopImmediaterly = true;
            }
        }
    }
}
