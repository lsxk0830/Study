using UnityEditor;
using System.IO;
using UnityEngine;

namespace Unity3D.Demo.AB
{
    public class AssetBundleBuilder : Editor
    {
        private const string BasePath = "Assets/ToolModule/AB打包/AB";
        private const BuildAssetBundleOptions DefaultOptions = BuildAssetBundleOptions.ChunkBasedCompression; // 指定压缩类型


        [MenuItem("Unity3D.Demo/AB打包/创建Android_AB包")]
        static void BuildForAndroid()
        {
            BuildAssetBundles(BuildTarget.Android);
        }

        [MenuItem("Unity3D.Demo/AB打包/创建IOS_AB包")]
        static void BuildForIOS()
        {
            BuildAssetBundles(BuildTarget.iOS);
        }

        [MenuItem("Unity3D.Demo/AB打包/创建Windows_AB包")]
        static void BuildForWindows()
        {
            BuildAssetBundles(BuildTarget.StandaloneWindows64);
        }

        private static void BuildAssetBundles(BuildTarget target)
        {
            string platformFolder = target.ToString();
            string outputPath = Path.Combine(BasePath, platformFolder);

            try
            {
                if (!Directory.Exists(outputPath)) // 确保目录存在
                    Directory.CreateDirectory(outputPath);

                // 执行打包
                BuildPipeline.BuildAssetBundles(outputPath, DefaultOptions, target);
                Debug.Log($"<color=green>✅ AssetBundle 打包完成！平台：{target}</color>");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"<color=red>❌ 打包失败（{target}):{e.Message}</color>");
            }

            AssetDatabase.Refresh();
        }
    }
}