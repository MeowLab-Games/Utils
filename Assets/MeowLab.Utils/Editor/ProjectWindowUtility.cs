using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MeowLab.Utils.Editor
{
    public static class ProjectWindowUtility
    {
        public static void SelectFolder(string folderPath) {
            var obj = AssetDatabase.LoadAssetAtPath<DefaultAsset>(folderPath);
            var projectBrowserType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
            var projectBrowsers = Resources.FindObjectsOfTypeAll(projectBrowserType);


            foreach (var projectBrowser in projectBrowsers) {
                var viewModeField = projectBrowserType.GetField("m_ViewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                var viewModeValue = viewModeField?.GetValue(projectBrowser);

                if (viewModeValue != null && viewModeValue.ToString() == "TwoColumns") {
                    var showFolderContents = projectBrowserType.GetMethod("ShowFolderContents", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(int), typeof(bool) }, null);
                    showFolderContents.Invoke(projectBrowser, new object[] { obj.GetInstanceID(), false });
                    return;
                }
            }
        }
    }
}