﻿using MeowLab.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace MeowLab.Utils.Editor
{
    /// <summary>
    /// Extension methods for <see cref="SerializedObject"/> that are specially useful in combination with UIToolkit.
    /// </summary>
    public static class SerializedObjectExtensions
    {
        /// <summary>
        /// Returns whether the serialized object is considered editable.
        /// It will return false if targetObjects are marked with <see cref="HideFlags.NotEditable"/>
        /// or if there's an asset that isn't open for edit in version control.
        /// It's specially useful in combination with <see cref="Disabler"/>.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>Whether obj is editable.</returns>
        public static bool IsEditable(this SerializedObject obj)
        {
            return IsEditable(obj, StatusQueryOptions.UseCachedIfPossible);
        }

        public static bool IsEditable(this SerializedObject obj, StatusQueryOptions queryOptions)
        {
            if (obj == null) return false;

            foreach (var target in obj.targetObjects)
            {
                if (!target || (target.hideFlags & HideFlags.NotEditable) != 0
                    || (EditorUtility.IsPersistent(target) && !AssetDatabase.IsOpenForEdit(target, queryOptions)))
                    return false;
            }

            return true;
        }
    }
}