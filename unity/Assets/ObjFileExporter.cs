/***************************************************************
 * Description: This used to export obj file
 * Document: https://github.com/hiramtan/HiRecastnavigation
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjFileExporter
{
    /// <summary>
    /// path you want to save obj file
    /// </summary>
    private static string path = Application.dataPath + "/" + SceneManager.GetActiveScene().name + ".obj";

    [MenuItem("HiRecastnavigation/Export")]
    private static void ExportSelectionToSeparate()
    {
        List<MeshFilter> mfs = new List<MeshFilter>();
        var gos = Object.FindObjectsOfType<MeshFilter>();
        foreach (var go in gos)
        {
            var mf = (MeshFilter)go;
            if (mf != null)
            {
                mfs.Add(mf);
            }
        }
        MeshToObjFile(mfs.ToArray(), path);
    }

    private static void MeshToObjFile(MeshFilter[] mfs, string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(MeshToString(mfs));
        }
    }

    private static string MeshToString(MeshFilter[] mfs)
    {
        StringBuilder sb = new StringBuilder();
        int vertexOffset = 0;
        int normalOffset = 0;
        int uvOffset = 0;
        for (int numb = 0; numb < mfs.Length; numb++)
        {
            MeshFilter mf = mfs[numb];
            Mesh m = mf.sharedMesh;
            Material[] mats = mf.GetComponent<Renderer>().sharedMaterials;

            sb.Append("g ").Append(mf.name).Append("\n");
            foreach (Vector3 lv in m.vertices)
            {
                Vector3 wv = mf.transform.TransformPoint(lv);

                //This is sort of ugly - inverting x-component since we're in
                //a different coordinate system than "everyone" is "used to".
                sb.Append(string.Format("v {0} {1} {2}\n", -wv.x, wv.y, wv.z));
            }
            sb.Append("\n");

            foreach (Vector3 lv in m.normals)
            {
                Vector3 wv = mf.transform.TransformDirection(lv);

                sb.Append(string.Format("vn {0} {1} {2}\n", -wv.x, wv.y, wv.z));
            }
            sb.Append("\n");

            foreach (Vector3 v in m.uv)
            {
                sb.Append(string.Format("vt {0} {1}\n", v.x, v.y));
            }

            for (int material = 0; material < m.subMeshCount; material++)
            {
                sb.Append("\n");
                sb.Append("usemtl ").Append(mats[material].name).Append("\n");
                sb.Append("usemap ").Append(mats[material].name).Append("\n");
                int[] triangles = m.GetTriangles(material);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    //Because we inverted the x-component, we also needed to alter the triangle winding.
                    sb.Append(string.Format("f {1}/{1}/{1} {0}/{0}/{0} {2}/{2}/{2}\n",
                        triangles[i] + 1 + vertexOffset, triangles[i + 1] + 1 + normalOffset,
                        triangles[i + 2] + 1 + uvOffset));
                }
                vertexOffset += m.vertices.Length;
                normalOffset += m.normals.Length;
                uvOffset += m.uv.Length;
            }

        }
        return sb.ToString();
    }
}