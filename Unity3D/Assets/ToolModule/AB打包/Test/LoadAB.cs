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
                abList[i] = await LoadAssetBundle(abName[i]);
            }
            GameObject Cube1 = await LoadResource<GameObject>(abList[0], "Cube 1");
            Instantiate(Cube1, parent);
            GameObject Cube2 = await LoadResource<GameObject>(abList[0], "Cube 2");
            Instantiate(Cube2, parent);
            GameObject Cube3 = await LoadResource<GameObject>(abList[0], "Cube 3");
            Instantiate(Cube3, parent);

            GameObject Cube = await LoadResource<GameObject>(abList[1], "Cube");
            Instantiate(Cube, parent);

            GameObject sphere = await LoadResource<GameObject>(abList[2], "Sphere");
            Instantiate(sphere, parent);

            Texture Texture = await LoadResource<Texture>(abList[3], "TextureAB");
            RawImage.texture = Texture;
        }

        private async UniTask<AssetBundle> LoadAssetBundle(string abName)
        {
            string path = Path.Combine(Application.dataPath, localBundlePath, abName);

            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path))
            {
                await request.SendWebRequest().ToUniTask(ReportProgress("远程下载"));

                if (request.result == UnityWebRequest.Result.Success)
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
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
            AssetBundleRequest assetRequest = bundle.LoadAssetAsync<T>(assetName);
            await assetRequest.ToUniTask();

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