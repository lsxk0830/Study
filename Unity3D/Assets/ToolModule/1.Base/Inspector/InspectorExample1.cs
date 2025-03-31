#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Unity3D.Base.InspectorExample
{
    public class InspectorExample1 : MonoBehaviour
    {
        [SerializeField] private int Id;
        [SerializeField] private string Name;
        [SerializeField] private GameObject Prefab;

        [HideInInspector] public string Note = "这个不显示在Inspector面板上";

#if UNITY_EDITOR
        [CustomEditor(typeof(InspectorExample1))]
        public class ScriptInsector : Editor
        {
            /// <summary>
            /// 所有的字段都绘制，否则会出现没绘制的不显示
            /// 推荐使用方式 SimpleFrame.LabelTextAttribute
            /// </summary>
            public override void OnInspectorGUI()
            {
                //更新最新数据
                serializedObject.Update();
                SerializedProperty property;

                //获取数据信息
                property = serializedObject.FindProperty(nameof(Id));
                //赋值数据
                property.intValue = EditorGUILayout.IntField("自定义显示主键", property.intValue);

                property = serializedObject.FindProperty(nameof(Name));
                property.stringValue = EditorGUILayout.TextField("自定义显示姓名", property.stringValue);
                property = serializedObject.FindProperty(nameof(Prefab));
                property.objectReferenceValue = EditorGUILayout.ObjectField("游戏对象", property.objectReferenceValue, typeof(GameObject), true);

                //property = serializedObject.FindProperty(nameof(Note));
                //property.stringValue = EditorGUILayout.TextField("Note笔记", property.stringValue);

                //全部保存数据
                serializedObject.ApplyModifiedProperties();
            }
        }
#endif
    }
}