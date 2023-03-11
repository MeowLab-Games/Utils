using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace MeowLab.Utils.Editor
{
    public class DropdownPopup<T> : AdvancedDropdown where T : IDropdownItem
    {
        public Action<int, T> OnItemSelected;
        private IReadOnlyList<T> _data;
        private Dictionary<AdvancedDropdownItem, T> _cache;


        public DropdownPopup(IReadOnlyList<T> data) : base(new AdvancedDropdownState()) {
            _data = data;
            _cache = new Dictionary<AdvancedDropdownItem, T>();
            minimumSize = new Vector2(minimumSize.x, EditorGUIUtility.singleLineHeight * (data.Count + 10));
        }


        protected override AdvancedDropdownItem BuildRoot() {
            _cache.Clear();
            var root = new AdvancedDropdownItem("Items");
            for (var i = 0; i < _data.Count; i++) {
                var item = new AdvancedDropdownItem(_data[i].Name);
                _cache.Add(item, _data[i]);
                root.AddChild(item);
            }

            return root;
        }


        protected override void ItemSelected(AdvancedDropdownItem item) {
            base.ItemSelected(item);
            OnItemSelected?.Invoke(_cache.Keys.ToList().IndexOf(item), _cache[item]);
        }
    }



    public interface IDropdownItem
    {
        public string Name { get; set; }
    }



    public class DropDownItem<T> : IDropdownItem
    {
        public T Data { get; set; }
        public string Name { get; set; }


        public DropDownItem(T data, string name) {
            Data = data;
            Name = name;
        }
    }
}