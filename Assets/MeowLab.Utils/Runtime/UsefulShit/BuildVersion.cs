using System;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.UIElements;
using UnityEngine.Assertions;
#endif

namespace MeowLab.Utils
{
    public class BuildVersion : ResourceSingleton<BuildVersion>
    {
        public int Major = 1;
        public int Minor = 0;
        public int BuildIndex = 1;


        public int GetBundleVersionCode() {
            return Major * 100000 + Minor * 1000 + BuildIndex;
        }


        public string GetVersion() {
            return $"{Major}.{Minor:D2}";
        }


        public string GetFullVersion() {
            return $"{Major}.{Minor:D2}.{BuildIndex:D3}";
        }


        public string GetBuildName() {
            var str = string.Empty;
#if AMAZON
            str += "AMAZON.";
#elif AMAZON_PAID
            str += "AMAZON_PAID.";
#elif SAYKIT
            str += "SAYKIT.";\
#endif

            // var productName = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars())
            // .Aggregate(Application.productName, (current, c) => current.Replace(c, '_'));

            str += $"{ReplaceInvalidChars(Application.productName)}_";
            str += $"{GetFullVersion()}_";
            str += $"{DateTime.Now:dd.MM.yyyy_hh.mmtt}";
            str = str.Replace(" ", "");
            str = str.Replace(":", "_");
            return str;
        }


        private string ReplaceInvalidChars(string filename) {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

//
// #if UNITY_EDITOR
//         public void Setup() {
//             PlayerSettings.bundleVersion = GetVersion();
//             PlayerSettings.Android.bundleVersionCode = GetBundleVersionCode();
//             PlayerSettings.iOS.buildNumber = GetBundleVersionCode().ToString();
//             PlayerSettings.macOS.buildNumber = GetBundleVersionCode().ToString();
//         }
// #endif
    }



#if UNITY_EDITOR
    public static class BuildContextMenu
    {
        [MenuItem("Build/Copy Build Name", priority = 100)]
        public static void CopyBuildName() {
            var buildName = BuildVersion.I.GetBuildName();
            GUIUtility.systemCopyBuffer = buildName;
            Debug.Log($"{buildName} copied!");
        }


        [MenuItem("Build/Up Major", priority = 0)]
        public static void UpMajor() {
            BuildVersion.I.Major++;
            BuildVersion.I.Minor = 0;
            BuildVersion.I.BuildIndex = 1;
            SaveChanges();
        }


        [MenuItem("Build/Up Minor", priority = 1)]
        public static void UpMinor() {
            BuildVersion.I.Minor++;
            BuildVersion.I.BuildIndex = 1;
            SaveChanges();
        }


        [MenuItem("Build/Up Build Index", priority = 3)]
        public static void UpBuildIndex() {
            BuildVersion.I.BuildIndex++;
            SaveChanges();
        }


        private static void SaveChanges() {
            // BuildVersion.I.Setup();
            EditorUtility.SetDirty(BuildVersion.I);
            AssetDatabase.SaveAssetIfDirty(BuildVersion.I);
        }
    }



    public static class BuildPostProcessor
    {
        [PostProcessBuild]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
            BuildContextMenu.UpBuildIndex();
        }
    }


    //
    // [CustomEditor(typeof(BuildVersion), true)]
    // public class BuildVersionEditor : UnityEditor.Editor
    // {
    //     public override VisualElement CreateInspectorGUI() {
    //         var root = new VisualElement();
    //         InspectorElement.FillDefaultInspector(root, serializedObject, this);
    //         root.Add(SetupButton());
    //         return root;
    //     }
    //
    //
    //     private VisualElement SetupButton() {
    //         var button = new Button();
    //         button.text = "SETUP";
    //         button.clicked += () => (target as BuildVersion)?.Setup();
    //         return button;
    //     }
    // }
    
    public static class CleanupPostProcessorBuild
    {
        [PostProcessBuild(2000)]
        public static void OnPostProcessBuild(BuildTarget target, string path)
        {
#if UNITY_IOS
        Debug.Log("iOSBuildPostProcess is now postprocessing iOS Project");
 
        var projectPath = PBXProject.GetPBXProjectPath(path);
 
        var project = new PBXProject();
        project.ReadFromFile(projectPath);
 
        var targetGuid = project.GetUnityMainTargetGuid();
 
        project.SetBuildProperty(targetGuid, "SUPPORTS_MAC_DESIGNED_FOR_IPHONE_IPAD", "NO");
 
        try
        {
            var projectInString = File.ReadAllText(projectPath);
            projectInString = projectInString.Replace("SUPPORTS_MAC_DESIGNED_FOR_IPHONE_IPAD = YES;",
                $"SUPPORTS_MAC_DESIGNED_FOR_IPHONE_IPAD = NO;");
            File.WriteAllText(projectPath, projectInString);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
 
        project.WriteToFile(projectPath);
#endif
            string outputPath = path;

            try
            {
                string applicationName = Path.GetFileNameWithoutExtension(outputPath);
                string outputFolder = Path.GetDirectoryName(outputPath);
                Assert.IsNotNull(outputFolder);

                outputFolder = Path.GetFullPath(outputFolder);

                //Delete Burst Debug Folder
                string burstDebugInformationDirectoryPath = Path.Combine(outputFolder, $"{applicationName}_BurstDebugInformation_DoNotShip");

                if (Directory.Exists(burstDebugInformationDirectoryPath))
                {
                    Debug.Log($" > Deleting Burst debug information folder at path '{burstDebugInformationDirectoryPath}'...");

                    Directory.Delete(burstDebugInformationDirectoryPath, true);
                }

                //Delete il2cpp Debug Folder
                string il2cppDebugInformationDirectoryPath = Path.Combine(outputFolder, $"{applicationName}_BackUpThisFolder_ButDontShipItWithYourGame");

                if (Directory.Exists(il2cppDebugInformationDirectoryPath))
                {
                    Debug.Log($" > Deleting Burst debug information folder at path '{il2cppDebugInformationDirectoryPath}'...");

                    Directory.Delete(il2cppDebugInformationDirectoryPath, true);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"An unexpected exception occurred while performing build cleanup: {e}");
            }
        }
    }
#endif
}