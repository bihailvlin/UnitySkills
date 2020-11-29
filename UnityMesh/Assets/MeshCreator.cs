using UnityEngine;
using System.Collections;

public class MeshCreator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreateQuad();
        CreateCube();
        ShinningStar();
        Pyramid();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void CreateQuad()
    {
        GameObject gameObj = new GameObject("MyQuad");
        gameObj.AddComponent<MeshFilter>();
        gameObj.AddComponent<MeshRenderer>();

        MeshFilter meshFilter = gameObj.GetComponent<MeshFilter>();

        int vectorNumbers = 4;
        Vector3[] vertices = new Vector3[vectorNumbers];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 1, 0);
        vertices[2] = new Vector3(1, 1, 0);
        vertices[3] = new Vector3(1, 0, 0);

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        Vector3[] normals = new Vector3[vectorNumbers];
        normals[0] = Vector3.back;
        normals[1] = Vector3.back;
        normals[2] = Vector3.back;
        normals[3] = Vector3.back;

        Vector2[] uv = new Vector2[vectorNumbers];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.normals = normals;
        meshFilter.mesh.uv = uv;

        MeshRenderer meshRenderer = gameObj.GetComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        Texture texture2D = Resources.Load("1") as Texture;
        mat.mainTexture = texture2D;
        meshRenderer.material = mat;

        gameObj.transform.position = new Vector3(-5, 10, 0);
        gameObj.transform.localScale = new Vector3(10, 10, 1);

    }


    /// <summary>
    /// 普通的立方体
    /// </summary>
    void CreateCube()
    {
        GameObject gameObj = new GameObject("MyCube");

        gameObj.AddComponent<MeshFilter>();
        gameObj.AddComponent<MeshRenderer>();

        MeshFilter meshFilter = gameObj.GetComponent<MeshFilter>();

        int vectorNumbers = 6;
        Vector3[] vertices = new Vector3[vectorNumbers * 4];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 0, 1);
        vertices[2] = new Vector3(1, 0, 0);
        vertices[3] = new Vector3(1, 0, 1);

        vertices[4] = new Vector3(0, 1, 0);
        vertices[5] = new Vector3(0, 1, 1);
        vertices[6] = new Vector3(1, 1, 0);
        vertices[7] = new Vector3(1, 1, 1);

        vertices[8] = new Vector3(1, 0, 0);
        vertices[9] = new Vector3(1, 1, 0);
        vertices[10] = new Vector3(1, 0, 1);
        vertices[11] = new Vector3(1, 1, 1);

        vertices[12] = new Vector3(0, 0, 1);
        vertices[13] = new Vector3(0, 1, 1);
        vertices[14] = new Vector3(0, 1, 0);
        vertices[15] = new Vector3(0, 0, 0);

        vertices[16] = new Vector3(0, 0, 0);
        vertices[17] = new Vector3(0, 1, 0);
        vertices[18] = new Vector3(1, 1, 0);
        vertices[19] = new Vector3(1, 0, 0);

        vertices[20] = new Vector3(1, 0, 1);
        vertices[21] = new Vector3(1, 1, 1);
        vertices[22] = new Vector3(0, 0, 1);
        vertices[23] = new Vector3(0, 1, 1);

        int[] triangles = new int[]
        {
            1, 0, 3, 0, 2, 3,
            4, 5, 6, 5, 7, 6,
            8, 9, 10, 9, 11, 10,
            12, 13, 14, 12, 14, 15,
            16, 17, 18, 19, 16, 18,
            20, 21, 22, 21, 23, 22
        };

        Vector3[] normals = new Vector3[vectorNumbers * 4];
        normals[0] = Vector3.down;
        normals[1] = Vector3.down;
        normals[2] = Vector3.down;
        normals[3] = Vector3.down;

        normals[4] = Vector3.up;
        normals[5] = Vector3.up;
        normals[6] = Vector3.up;
        normals[7] = Vector3.up;

        normals[8] = Vector3.right;
        normals[9] = Vector3.right;
        normals[10] = Vector3.right;
        normals[11] = Vector3.right;

        normals[12] = Vector3.left;
        normals[13] = Vector3.left;
        normals[14] = Vector3.left;
        normals[15] = Vector3.left;

        normals[16] = Vector3.back;
        normals[17] = Vector3.back;
        normals[18] = Vector3.back;
        normals[19] = Vector3.back;

        normals[20] = Vector3.forward;
        normals[21] = Vector3.forward;
        normals[22] = Vector3.forward;
        normals[23] = Vector3.forward;


        Vector2[] uv = new Vector2[vectorNumbers * 4];
        uv[0] = new Vector2(0, 1);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, 1);
        uv[6] = new Vector2(1, 0);
        uv[7] = new Vector2(1, 1);

        uv[8] = new Vector2(0, 0);
        uv[9] = new Vector2(0, 1);
        uv[10] = new Vector2(1, 0);
        uv[11] = new Vector2(1, 1);

        uv[12] = new Vector2(0, 0);
        uv[13] = new Vector2(0, 1);
        uv[14] = new Vector2(1, 1);
        uv[15] = new Vector2(1, 0);

        uv[16] = new Vector2(0, 0);
        uv[17] = new Vector2(0, 1);
        uv[18] = new Vector2(1, 1);
        uv[19] = new Vector2(1, 0);

        uv[20] = new Vector2(0, 0);
        uv[21] = new Vector2(0, 1);
        uv[22] = new Vector2(1, 0);
        uv[23] = new Vector2(1, 1);

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.normals = normals;
        meshFilter.mesh.uv = uv;

        MeshRenderer meshRenderer = gameObj.GetComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        Texture texture2D = Resources.Load("2") as Texture;
        mat.mainTexture = texture2D;
        meshRenderer.material = mat;

        gameObj.transform.position = new Vector3(15, 10, 0);
        gameObj.transform.localScale = new Vector3(10, 10, 10);
    }

    /// <summary>
    /// 闪闪的星星
    /// </summary>
    void ShinningStar()
    {
        GameObject gameObj = new GameObject("MyStar");
        gameObj.AddComponent<MeshFilter>();
        gameObj.AddComponent<MeshRenderer>();

        Mesh mesh = gameObj.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices;
        Color[] colors;
        int[] triangles;

        int frequency = 10;
        Vector3 point = Vector3.up;
        Vector3 point2 = new Vector3(0, 1.5f, 0);

        int numberOfPoints = frequency * 2;
        MeshFilter meshFilter = gameObj.GetComponent<MeshFilter>();
        vertices = new Vector3[numberOfPoints + 1];
        colors = new Color[numberOfPoints + 1];

        triangles = new int[numberOfPoints * 3];
        float angle = -360f / numberOfPoints;
        colors[0] = new Color(0, 0, 0);
        for (int iF = 0, v = 1, t = 1; iF < frequency; iF++)
        {
            for (int iP = 0; iP < 2; iP += 1, v += 1, t += 3)
            {
                vertices[v] = Quaternion.Euler(0f, 0f, angle * (v - 1)) * (iP % 2 == 0 ? point : point2);
                colors[v] = (iP % 2 == 0 ? Color.red : Color.green);
                triangles[t] = v;
                triangles[t + 1] = v + 1;
            }
        }
        MeshRenderer meshRenderer = gameObj.GetComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        meshRenderer.material = mat;

        triangles[triangles.Length - 1] = 1;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        gameObj.transform.position = new Vector3(0, -2, 0);
        gameObj.transform.localScale = new Vector3(4, 4, 1);
    }


    /// <summary>
    /// 金字塔模型
    /// </summary>
    void Pyramid()
    {
        GameObject gameObj = new GameObject("MyPyramid");

        gameObj.AddComponent<MeshFilter>();
        gameObj.AddComponent<MeshRenderer>();

        MeshFilter meshFilter = gameObj.GetComponent<MeshFilter>();

        int vectorNumbers = 18;
        Vector3[] vertices = new Vector3[vectorNumbers];
        vertices[0] = new Vector3(-2, 0, 2);
        vertices[1] = new Vector3(-2, 0, -2);
        vertices[2] = new Vector3(2, 0, -2);

        vertices[3] = new Vector3(-2, 0, 2);
        vertices[4] = new Vector3(2, 0, -2);
        vertices[5] = new Vector3(2, 0, 2);

        vertices[6] = new Vector3(-2, 0, -2);
        vertices[7] = new Vector3(0, 4, 0);
        vertices[8] = new Vector3(2, 0, -2);

        vertices[9] = new Vector3(2, 0, -2);
        vertices[10] = new Vector3(0, 4, 0);
        vertices[11] = new Vector3(2, 0, 2);

        vertices[12] = new Vector3(2, 0, 2);
        vertices[13] = new Vector3(0, 4, 0);
        vertices[14] = new Vector3(-2, 0, 2);

        vertices[15] = new Vector3(-2, 0, 2);
        vertices[16] = new Vector3(0, 4, 0);
        vertices[17] = new Vector3(-2, 0, -2);

        int[] triangles = new int[]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8,9, 10, 11,12, 13, 14,15, 16, 17
        };
        Vector3 backDir = (vertices[7] - new Vector3(0, 0, -2)).normalized;
        Vector3 leftDir = (vertices[7] - new Vector3(-2, 0, 0)).normalized;
        Vector3 frontDir = (vertices[7] - new Vector3(0, 0, 2)).normalized;
        Vector3 rightDir = (vertices[7] - new Vector3(2, 0, 0)).normalized;

        Vector3[] normals = new Vector3[vectorNumbers];
        normals[0] = Vector3.down;
        normals[1] = Vector3.down;
        normals[2] = Vector3.down;
        normals[3] = Vector3.down;
        normals[4] = Vector3.down;
        normals[5] = Vector3.down;

        normals[6] = Vector3.Cross(backDir, Vector3.right);
        normals[7] = Vector3.Cross(backDir, Vector3.right);
        normals[8] = Vector3.Cross(backDir, Vector3.right);

        normals[9] = Vector3.Cross(backDir, Vector3.back);
        normals[10] = Vector3.Cross(backDir, Vector3.back);
        normals[11] = Vector3.Cross(backDir, Vector3.back);

        normals[12] = Vector3.Cross(backDir, Vector3.left);
        normals[13] = Vector3.Cross(backDir, Vector3.left);
        normals[14] = Vector3.Cross(backDir, Vector3.left);

        normals[15] = Vector3.Cross(backDir, Vector3.forward);
        normals[16] = Vector3.Cross(backDir, Vector3.forward);
        normals[17] = Vector3.Cross(backDir, Vector3.forward);


        Vector2[] uv = new Vector2[vectorNumbers];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);

        uv[3] = new Vector2(0, 0);
        uv[4] = new Vector2(1, 1);
        uv[5] = new Vector2(1, 0);

        uv[6] = new Vector2(0, 0);
        uv[7] = new Vector2(0.5f, 0.5f);
        uv[8] = new Vector2(1, 0);

        uv[9] = new Vector2(1, 0);
        uv[10] = new Vector2(0.5f, 0.5f);
        uv[11] = new Vector2(1, 1);

        uv[12] = new Vector2(1, 1);
        uv[13] = new Vector2(0.5f, 0.5f);
        uv[14] = new Vector2(0, 1);

        uv[15] = new Vector2(0, 1);
        uv[16] = new Vector2(0.5f, 0.5f);
        uv[17] = new Vector2(0, 0);

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.normals = normals;
        meshFilter.mesh.uv = uv;

        MeshRenderer meshRenderer = gameObj.GetComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        Texture texture2D = Resources.Load("Yellow") as Texture;
        mat.mainTexture = texture2D;
        meshRenderer.material = mat;

        gameObj.transform.position = new Vector3(20, -7, 0);
        gameObj.transform.localScale = new Vector3(3, 3, 3);
    }


}
