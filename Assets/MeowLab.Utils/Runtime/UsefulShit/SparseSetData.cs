using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MeowLab.Utils
{
    public class SparseSetData
    {
        private int _count;
        private int[] _sparse;
        private int[] _entities;


        public SparseSetData(int initCapacity = 64) {
            _sparse = new int[initCapacity];
            _entities = new int[initCapacity];
        }


        public void Add(int e) {
            if (e >= _sparse.Length) {
                Array.Resize(ref _sparse, Mathf.NextPowerOfTwo(e + 1));
            }

            if (_count == _entities.Length) {
                Array.Resize(ref _entities, _count << 1);
            }

            _entities[_count] = e;
            _sparse[e] = ++_count;
        }


        public void Del(int e) {
            var idx = _sparse[e] - 1;
            if (_sparse[e] == 0) {
                D.LogError($"Component already deleted.");
                return;
            }

            _sparse[e] = 0;
            _count--;
            if (idx < _count) {
                _entities[idx] = _entities[_count];
                _sparse[_entities[idx]] = idx + 1;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int e) {
            return e < _sparse.Length && _sparse[e] > 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Get(int e) {
            return _sparse[e] - 1;
        }
    }



    public class SparseSetData<T>
    {
        private int _count;
        private int[] _sparse;
        private T[] _dense;
        private int[] _entities;


        public SparseSetData(int initCapacity = 64) {
            _sparse = new int[initCapacity];
            _dense = new T[initCapacity];
            _entities = new int[initCapacity];
        }


        public void Add(int e, T data) {
            if (e >= _sparse.Length) {
                Array.Resize(ref _sparse, Mathf.NextPowerOfTwo(e + 1));
            }

            if (_count == _dense.Length) {
                Array.Resize(ref _entities, _count << 1);
                Array.Resize(ref _dense, _count << 1);
            }

            _entities[_count] = e;
            _dense[_count] = data;
            _sparse[e] = ++_count;
        }


        public void Del(int e) {
            var idx = _sparse[e] - 1;
            if (_sparse[e] == 0) {
                D.LogError($"Component \"{typeof(T).Name}\" already deleted.");
                return;
            }

            _sparse[e] = 0;
            _count--;
            if (idx < _count) {
                _entities[idx] = _entities[_count];
                _dense[idx] = _dense[_count];
                _sparse[_entities[idx]] = idx + 1;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int e) {
            return e < _sparse.Length && _sparse[e] > 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get(int e) {
            return _dense[_sparse[e] - 1];
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] GetDenseArray() {
            return _dense;
        }
    }
}