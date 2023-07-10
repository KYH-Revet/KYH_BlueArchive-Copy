using System.IO;
using UnityEditor;

public class AssetBundleBuildManager
{
    [MenuItem("Mytool/AssetBundle Build")]
    public static void AssetBundleBuild()
    {
        string directory = "./Bundle";

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        EditorUtility.DisplayDialog("���� ���� ����", "���� ���� ���带 �Ϸ��߽��ϴ�", "�Ϸ�");
    }
}
