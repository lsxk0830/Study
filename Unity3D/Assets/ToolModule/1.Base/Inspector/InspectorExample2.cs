using SimpleFrame;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity3D.Base.InspectorExample
{
    public class InspectorExample2 : MonoBehaviour
    {
        [LabelText("数量1")] public int Count1;
        [LabelText("数量2")] private int Count2;
        [SerializeField][LabelText("数量3")] private int Count3;
    }
}