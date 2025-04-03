using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity3D.Base.ScriptableObjectExample
{
    [CreateAssetMenu(fileName = "AssetMenu创建的资源", menuName = "Unity3D.Demo/创建ScriptableObject", order = 1)]
    public class ScriptableObjectExample : ScriptableObject
    {
        [SerializeField]
        public List<PlayerInfo> m_PlayerInfo;

        [System.Serializable]
        public class PlayerInfo
        {
            public int id;
            public string name;
        }

#if UNITY_EDITOR
        [MenuItem("Unity3D.Demo/ScriptableObject/创建ScriptableObject")]

        static void CreateScriptableObject()
        {
            //创建ScriptableObject
            ScriptableObjectExample script = ScriptableObject.CreateInstance<ScriptableObjectExample>();
            //赋值
            script.m_PlayerInfo = new List<PlayerInfo>()
            {
                new PlayerInfo() { id = 100, name = "Test0" },
                new PlayerInfo() { id = 101, name = "Test1" },
                new PlayerInfo() { id = 102, name = "Test2" }
            };

            //将资源保存到本地
            AssetDatabase.CreateAsset(script, "Assets/ToolModule/1.Base/ScriptableObject/MenuItem创建的资源.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }
}