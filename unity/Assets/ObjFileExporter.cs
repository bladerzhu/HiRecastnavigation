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
    private static string path = Application.dataPath + "/" + SceneManager.GetActiveScene().name + ".obj";

    [MenuItem("HiRecastnavigation/Export")]
    private static void ExportSelectionToSeparate()
    {
        List<MeshFilter> mfs = new List<MeshFilter>();
        var gos = Object.FindObjectsOfType<MeshFilter>();
        foreach (var go in gos)
        {
            var mf = go as MeshFilter;
            if (mf != null)
            {
                mfs.Add(mf);
            }
        }
        MeshToObjFile(mfs.ToArray(), path);
    }

    

    /// <summary>
    /// Export mesh to file
    /// </summary>
    /// <param name="mf"></param>
    /// <param name="path"></param>
    private static void MeshToObjFile(MeshFilter[] mfs, string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            //sw.Write("mtllib ./" + "mesh" + ".mtl\n");
            sw.Write(MeshToString(mfs));
        }
    }

    private static string MeshToString(MeshFilter[] mfs)
    {
        StringBuilder sb = new StringBuilder();
        for (int numb = 0; numb < mfs.Length; numb++)
        {
            MeshFilter mf = mfs[numb];
            Mesh m = mf.sharedMesh;
            Material[] mats = mf.GetComponent<Renderer>().sharedMaterials;

            sb.Append("g ").Append(mf.name).Append("\n");
            foreach (Vector3 v in m.vertices)
            {
                sb.Append(string.Format("v {0} {1} {2}\n", v.x, v.y, v.z));
            }
            sb.Append("\n");
            foreach (Vector3 v in m.normals)
            {
                sb.Append(string.Format("vn {0} {1} {2}\n", v.x, v.y, v.z));
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
                    sb.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n",
                        triangles[i] + 1, triangles[i + 1] + 1, triangles[i + 2] + 1));
                }
            }
        }
        return sb.ToString();
    }
}