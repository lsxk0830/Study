using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.ObjectPool
{
    /// <summary>
    /// 对象池先拿后放，拿时添加标记，放时根据标记判断能否放
    /// </summary>
    public class GoPool
    {
        private static GameObject CachePanel;
        private static Dictionary<int, Queue<GameObject>> Pool = new Dictionary<int, Queue<GameObject>>();
        private static Dictionary<GameObject, int> TagDic = new Dictionary<GameObject, int>();

        /// <summary>
        /// 放入对象池
        /// </summary>
        public static void PushPoolObj(GameObject go)
        {
            if (CachePanel == null)
            {
                CachePanel = new GameObject("PoolCachePanel");
                GameObject.DontDestroyOnLoad(CachePanel);
            }

            if (go == null) return;

            go.transform.parent = CachePanel.transform;
            go.SetActive(false);

            if (TagDic.ContainsKey(go))
            {
                int tag = TagDic[go];
                TagDic.Remove(go);// 移除标记
                if (!Pool.ContainsKey(tag))
                    Pool[tag] = new Queue<GameObject>();
                Pool[tag].Enqueue(go);
            }
        }

        /// <summary>
        /// 从对象池中获取对象
        /// </summary>
        public static GameObject PullPoolGo(GameObject prefab)
        {
            int tag = prefab.GetInstanceID();
            GameObject go;
            if (Pool.ContainsKey(tag) && Pool[tag].Count > 0)
            {
                go = Pool[tag].Dequeue();
                go.SetActive(true);
            }
            else
            {
                go = GameObject.Instantiate<GameObject>(prefab);
                go.name = prefab.name + Time.time;
            }
            TagDic.Add(go, tag);
            return go;
        }

        /// <summary>
        /// 清空对象池
        /// </summary>
        public static void ClearCachePool()
        {
            Pool.Clear();
        }
    }
}