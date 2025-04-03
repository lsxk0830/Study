using SimpleFrame;
using UnityEngine;

namespace Unity3D.Demo.UniformMotion
{
    /// <summary>
    /// 点对点匀速移动
    /// </summary>
    public class PointToPointMover : MonoBehaviour
    {
        public enum MoveMode // 移动模式
        {
            [InspectorName("单次")] Once,
            [InspectorName("循环")] Loop,
            [InspectorName("往返")] PingPong
        }

        [Header("路径点设置")]
        [LabelText("目标点坐标")] public Vector3 pointB; //目标点坐标

        [Header("移动参数设置")]

        [LabelText("移动速度（单位/秒）")] public float speed = 5f;
        [LabelText("移动模式选择")] public MoveMode moveMode = MoveMode.Once;
        [LabelText("到达判定阈值（避免无限接近）")] public float arrivalThreshold = 0.1f;

        private Vector3 pointA; // 起始点缓存
        private Vector3 currentTarget;// 当前目标点
        private bool isMoving = true; // 移动状态开关
        private float sqrArrivalThreshold; // 平方阈值（性能优化）

        private void Start()
        {
            // 初始化时记录起点并计算平方阈值
            pointA = transform.position;
            currentTarget = pointB;
            sqrArrivalThreshold = arrivalThreshold * arrivalThreshold;// 预计算平方阈值（比Vector3.Distance更高效）

            GlobalMono.Instance.OnUpdate += OnUpdate;
        }

        private void OnUpdate()
        {
            if (!isMoving) return;

            // 计算移动步长
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards
            (
                transform.position,
                currentTarget,
                step
            );

            // 使用平方距离比较提高性能
            if ((transform.position - currentTarget).sqrMagnitude <= sqrArrivalThreshold)
            {
                HandleArrival();
            }
        }

        private void HandleArrival()
        {
            switch (moveMode)
            {
                case MoveMode.Once:
                    isMoving = false;
                    break;
                case MoveMode.Loop:
                    transform.position = pointA;
                    break;
                case MoveMode.PingPong:
                    (currentTarget, pointB, pointA) = (pointA, pointA, pointB);// 使用元组快速交换目标点（C# 7.0特性）
                    break;
            }
        }

        // 编辑器可视化
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan; // 设置可视化颜色
            Gizmos.DrawSphere(pointB, 0.2f);// 绘制目标点球体
            Gizmos.DrawLine(Application.isPlaying ? pointA : transform.position, pointB);// 绘制移动路径线（运行时显示实际起点，编辑模式显示当前位置）
        }
    }
}