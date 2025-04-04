using UnityEngine;

namespace Unity3D.Demo.ObjectPool
{
    public class GoPoolTest : MonoBehaviour
    {
        public GameObject Sphere;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject TempSphere = GoPool.PullPoolGo(Sphere);

                TempSphere.transform.SetParent(transform);
                TempSphere.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}