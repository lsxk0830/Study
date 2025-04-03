using System;
using SimpleFrame;
using UnityEngine;

namespace Unity3D.Base.InspectorExample
{
    /// <summary>
    /// 必须绑定BoxCollider组件
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class InspectorExample4 : MonoBehaviour
    {
        [TextArea(5, 10)] public String myStr;
        [LabelText("限制Int的范围")][Range(5, 10)] public int myInt;
        [LabelText("限制float的范围")][Range(5, 10)] public float myfloat;
        [Tooltip("鼠标悬浮提示")] public String tip;

        [LabelText("没有半透明的Color")][ColorUsage(false)] public Color color;
        [LabelText("半透明的Color")] public Color color2;
    }
}