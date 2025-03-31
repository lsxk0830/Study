using SimpleFrame;
using UnityEngine;

namespace Unity3D.Base.InspectorExample
{
    public class InspectorExample2 : MonoBehaviour
    {
        [Header("这个不能放私有的上面,序列化了都不行")]
        [LabelText("数量1")] public int Count1;

        [LabelText("数量2")] private int Count2;
        [SerializeField][LabelText("数量3")] private int Count3;

        public Type myType;
    }

    public enum Type
    {
        [InspectorName("第一")]
        One,
        [InspectorName("第二")]
        Two
    }
}