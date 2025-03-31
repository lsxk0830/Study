using System.Collections;
using Tool;
using UnityEngine;

namespace Test
{
    public class GoPoolPrefab : MonoBehaviour
    {
        private Rigidbody Rigidbody;
        void OnEnable()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Rigidbody.velocity = new Vector3(5, 0, 0);
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            yield return new WaitForSeconds(3);
            GoPool.PushPoolObj(gameObject);
        }
    }
}