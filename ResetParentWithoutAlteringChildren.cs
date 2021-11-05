/*
MIT License

Copyright 2021 ScruffyRules

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScruffyRules
{
    public class ResetParentWithoutAlteringChildren : Editor
    {
        [MenuItem("CONTEXT/Transform/Reset Position Without Altering Children")]
        public static void ResetPosition(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) { alteredTransforms.Add(child); }

            Vector3 offset = transform.position;

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Position Without Altering Children");

            transform.localPosition = Vector3.zero;
            offset = transform.position - offset;

            foreach (Transform child in transform)
            {
                child.position = child.position - offset;
            }
        }
        [MenuItem("CONTEXT/Transform/Reset Rotation Without Altering Children")]
        public static void ResetRotation(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Quaternion> quaternions = new List<Quaternion>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                quaternions.Add(child.rotation);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Rotation Without Altering Children");

            transform.localRotation = Quaternion.identity;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).rotation = quaternions[i];
            }
        }
        [MenuItem("CONTEXT/Transform/Reset Scale Without Altering Children")]
        public static void ResetScale(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Vector3> scales = new List<Vector3>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                scales.Add(child.lossyScale);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Scale Without Altering Children");

            transform.localScale = Vector3.one;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localScale = Vector3.one;
                child.localScale = new Vector3(scales[i].x/child.lossyScale.x, scales[i].y/child.lossyScale.y, scales[i].z/child.lossyScale.z);
            }
        }
        [MenuItem("CONTEXT/Transform/Reset ALL Without Altering Children")]
        public static void ResetALL(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Vector3> scales = new List<Vector3>();
            List<Vector3> positions = new List<Vector3>();
            List<Quaternion> quaternions = new List<Quaternion>();

            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                positions.Add(child.position);
                scales.Add(child.lossyScale);
                quaternions.Add(child.rotation);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset ALL Without Altering Children");

            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localScale = Vector3.one;
                child.localScale = new Vector3(scales[i].x/child.lossyScale.x, scales[i].y/child.lossyScale.y, scales[i].z/child.lossyScale.z);
                child.SetPositionAndRotation(positions[i], quaternions[i]);
            }
        }
        [MenuItem("CONTEXT/RectTransform/Reset Position Without Altering Children")]
        public static void ResetRPosition(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) { alteredTransforms.Add(child); }

            Vector3 offset = transform.position;

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Position Without Altering Children");

            transform.localPosition = Vector3.zero;
            offset = transform.position - offset;

            foreach (Transform child in transform)
            {
                child.position = child.position - offset;
            }
        }
        [MenuItem("CONTEXT/RectTransform/Reset Rotation Without Altering Children")]
        public static void ResetRRotation(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Quaternion> quaternions = new List<Quaternion>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                quaternions.Add(child.rotation);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Rotation Without Altering Children");

            transform.localRotation = Quaternion.identity;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).rotation = quaternions[i];
            }
        }
        [MenuItem("CONTEXT/RectTransform/Reset Scale Without Altering Children")]
        public static void ResetRScale(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Vector3> scales = new List<Vector3>();
            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                scales.Add(child.lossyScale);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset Scale Without Altering Children");

            transform.localScale = Vector3.one;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localScale = Vector3.one;
                child.localScale = new Vector3(scales[i].x/child.lossyScale.x, scales[i].y/child.lossyScale.y, scales[i].z/child.lossyScale.z);
            }
        }
        [MenuItem("CONTEXT/RectTransform/Reset ALL Without Altering Children")]
        public static void ResetRALL(MenuCommand menuCommand)
        {
            Transform transform = menuCommand.context as Transform;

            List<Transform> alteredTransforms = new List<Transform>();
            List<Vector3> scales = new List<Vector3>();
            List<Vector3> positions = new List<Vector3>();
            List<Quaternion> quaternions = new List<Quaternion>();

            alteredTransforms.Add(transform);
            foreach (Transform child in transform) {
                alteredTransforms.Add(child);
                positions.Add(child.position);
                scales.Add(child.lossyScale);
                quaternions.Add(child.rotation);
            }

            Undo.RegisterCompleteObjectUndo(alteredTransforms.ToArray(), "Reset ALL Without Altering Children");

            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localScale = Vector3.one;
                child.localScale = new Vector3(scales[i].x/child.lossyScale.x, scales[i].y/child.lossyScale.y, scales[i].z/child.lossyScale.z);
                child.SetPositionAndRotation(positions[i], quaternions[i]);
            }
        }
    }
}
#endif // UNITY_EDTIOR