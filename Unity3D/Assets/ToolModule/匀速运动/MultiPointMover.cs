using System.Collections.Generic;
using SimpleFrame;
using UnityEngine;

namespace Unity3D.Demo.UniformMotion
{
    /// <summary>
    /// 多点匀速路径移动
    /// </summary>
    public class MultiPointMover : MonoBehaviour
    {
        public enum MoveMode // 移动模式
        {
            [InspectorName("单次")] Once,
            [InspectorName("循环")] Loop,
            [InspectorName("往返")] PingPong
        }

        [Header("路径设置")]

        [LabelText("路径点列表")] public List<Vector3> waypoints = new List<Vector3>();


        [Header("移动参数")]

        [LabelText("移动速度（单位/秒）")] public float speed = 5f;
        [LabelText("移动模式选择")] public MoveMode moveMode = MoveMode.Once;
        [LabelText("到达阈值")] public float arrivalThreshold = 0.1f;
        [LabelText("下一目标点Index")] public int targetIndex;
        [LabelText("移动方向")] public int moveDirection = 1;

        // 私有变量
        private Vector3 currentTarget;            // 当前目标点
        private float sqrArrivalThreshold;        // 平方阈值
        private bool isMoving = true;             // 移动状态
        private List<Vector3> runtimeWaypoints;   // 运行时路径副本

        private void Start()
        {
            InitializePath();
            GlobalMono.Instance.OnUpdate += OnUpdate;
        }

        /// <summary>
        /// 初始化路径
        /// </summary>
        private void InitializePath()
        {
            if (waypoints.Count < 2)
            {
                Debug.LogError("至少需要2个路径点!");
                enabled = false;
                return;
            }

            runtimeWaypoints = new List<Vector3>(waypoints);
            targetIndex = 0;
            currentTarget = runtimeWaypoints[targetIndex];
            sqrArrivalThreshold = arrivalThreshold * arrivalThreshold;
        }

        private void OnUpdate()
        {
            if (!isMoving || runtimeWaypoints == null) return;

            // 计算移动步长
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards
            (
                transform.position,
                currentTarget,
                step
            );

            // 到达检测
            if ((transform.position - currentTarget).sqrMagnitude <= sqrArrivalThreshold)
            {
                HandleWaypointArrival();
            }
        }

        /// <summary>
        /// 处理路径点到达逻辑
        /// </summary>
        private void HandleWaypointArrival()
        {
            // 更新下一个目标点索引
            targetIndex += moveDirection;

            // 不同移动模式的处理
            switch (moveMode)
            {
                case MoveMode.Once when targetIndex >= runtimeWaypoints.Count:
                    isMoving = false;
                    return;

                case MoveMode.Loop when targetIndex >= runtimeWaypoints.Count:
                    targetIndex = 0;
                    break;

                case MoveMode.PingPong:
                    if (targetIndex >= runtimeWaypoints.Count || targetIndex < 0)
                    {
                        moveDirection *= -1; // 反转方向
                        targetIndex += moveDirection * 2; // 补偿超出索引
                    }
                    break;
            }

            // 确保索引在有效范围内
            targetIndex = Mathf.Clamp(targetIndex, 0, runtimeWaypoints.Count - 1);
            currentTarget = runtimeWaypoints[targetIndex];
        }

        /// <summary>
        /// 编辑器可视化
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (waypoints == null || waypoints.Count < 1) return;

            Gizmos.color = Color.cyan;
            const float sphereSize = 0.2f;

            // 绘制所有路径点
            foreach (var point in waypoints)
            {
                Gizmos.DrawSphere(point, sphereSize);
            }

            // 绘制路径连线
            for (int i = 0; i < waypoints.Count; i++)
            {
                if (i == 0) continue;
                Gizmos.DrawLine(waypoints[i - 1], waypoints[i]);
            }

            // 绘制循环闭合线
            if (moveMode == MoveMode.Loop && waypoints.Count > 1)
            {
                Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[0]);
            }
        }

        /// <summary>
        /// 重置路径（运行时调用）
        /// </summary>
        public void ResetPath()
        {
            InitializePath();
            isMoving = true;
        }
    }
}