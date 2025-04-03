using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using UnityEngine.UI;
using SimpleFrame;

namespace Unity3D.Demo.AB
{
    public class LoadAB : MonoBehaviour
    {
        private string localBundlePath = "ToolModule/AB打包/AB/StandaloneWindows64"; //本地AB包路径

        [LabelText("加载AB包父物体")] public Transform parent;
        [LabelText("加载显示图片")] public RawImage RawImage;

        private string[] abName = new string[]
        {
            "unity3d.demo.ab.group.go",
            "unity3d.demo.ab.cube",
            "unity3d.demo.ab.sphere.go",
            "unity3d.demo.ab.texture"
        };
        private AssetBundle[] abList = new AssetBundle[4];

        private async void Start()
        {
            for (int i = 0; i < abList.Length; i++)
            {
                Debug.Log($"正在加载第{i}个ab包");
                abList[i] = await LoadAssetBundle(abName[i]);
            }
            Debug.Log($"加载第{0}个ab包的资源.Cube 1");
            GameObject Cube1 = await LoadResource<GameObject>(abList[0], "Cube 1");
            Instantiate(Cube1, parent);
            Debug.Log($"加载第{0}个ab包的资源.Cube 2");
            GameObject Cube2 = await LoadResource<GameObject>(abList[0], "Cube 2");
            Instantiate(Cube2, parent);
            Debug.Log($"加载第{0}个ab包的资源.Cube 3");
            GameObject Cube3 = await LoadResource<GameObject>(abList[0], "Cube 3");
            Instantiate(Cube3, parent);
            Debug.Log($"加载第{1}个ab包的资源.Cube");
            GameObject Cube = await LoadResource<GameObject>(abList[1], "Cube");
            Instantiate(Cube, parent);
            Debug.Log($"加载第{2}个ab包的资源.Sphere");
            GameObject sphere = await LoadResource<GameObject>(abList[2], "Sphere");
            Instantiate(sphere, parent);
            Debug.Log($"加载第{3}个ab包的资源.TextureAB");
            Texture Texture = await LoadResource<Texture>(abList[3], "TextureAB");
            RawImage.texture = Texture;
        }

        private async UniTask<AssetBundle> LoadAssetBundle(string abName)
        {
            string path = Path.Combine(Application.dataPath, localBundlePath, abName);

            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path))
            {
                Debug.Log($"加载：{abName}");
                await request.SendWebRequest().ToUniTask(ReportProgress("远程下载"));
                await UniTask.Delay(3000);
                if (request.result == UnityWebRequest.Result.Success)
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                    Debug.Log($"{abName}加载完成");
                    if (bundle == null) throw new FileNotFoundException($"AB包不存在或损坏: {abName}");
                    return bundle;
                }
            }
            return null;
        }

        /// <summary>
        /// 从AB包加载资源
        /// </summary>
        public async UniTask<T> LoadResource<T>(AssetBundle bundle, string assetName) where T : UnityEngine.Object
        {
            Debug.Log($"{bundle.name}加载：{assetName}");
            AssetBundleRequest assetRequest = bundle.LoadAssetAsync<T>(assetName);
            await assetRequest.ToUniTask();
            await UniTask.Delay(3000);
            Debug.Log($"{bundle.name}加载完成：{assetName}");
            T asset = assetRequest.asset as T;

            if (asset == null) throw new InvalidCastException($"资源类型不匹配: {assetName} 不是 {typeof(T).Name}");

            return asset;
        }

        /// <summary>
        /// 进度报告生成器
        /// </summary>
        private IProgress<float> ReportProgress(string operationName)
        {
            return Progress.Create<float>(progress =>
            {
                Debug.Log($"{operationName}进度: {progress * 100:F1}%");
            });
        }
    }
}