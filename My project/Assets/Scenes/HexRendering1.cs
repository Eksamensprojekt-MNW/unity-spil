using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//Denne struct bruges til at mappe hvert face(Trekant)
public struct Hexface
{
    //Liste over hjønerene i x,y,z
    public List<Vector3> vertices { get; private set; }
    //Liste af int værdier til de forkelige trekanter, som sekskanten består af
    public List<int> triangles { get; private set; }
    //Liste af hvor UVS skal sidde hen
    public List<Vector2> UVS { get; private set; }

    //Definer hvad de forskellige ting er 
    public Hexface(List<Vector3> vertices, List<int> triangles, List<Vector2> UVS)
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.UVS = UVS;
    }
}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HexRendering : MonoBehaviour
{
    private Mesh Hmesh;
    private MeshFilter HmeshFilter;
    private MeshRenderer HmeshRenderer;

    private List<Hexface> hexfaces;


    public Material material;
        
    private void Awake()
    { }

    private void OnEnable()
    {
        DrawMesh();
    }
    //Tegner "faces" igen hver gang en ændring er sket 
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            DrawMesh();
        }
    }

   
    //rent faktisk tegner trekanternes "faces"
    public void DrawMesh()
    {
        DrawHexFaces();
        CombineHexcFaces();

    }
    //Setup de forskellige faces (hexface)
    private void DrawHexFaces ()
    {
        hexfaces = new List<Hexface>();

        // top faces
        for (int point = 0; point < 6;  point++)
        {
            hexfaces.Add(CreateHexface(innerRs, outerRs, height, / 2f, height / 2f, point));
        }
    }

    

    private void CombineHexcFaces()
    {
        //Laver en array for hver af de tre mesh elementer 
        List<Vector3> vertices = new List<Vector3>();
        List<int> triss = new List<int>();
        List<Vector2> UVS = new List<Vector2>();

        for (int i = 0; i < hexfaces.Count; i++)
        {
            //tilføge kanterne (vertives) og UVS
            vertices.AddRange(hexfaces[i].vertices);
            UVS.AddRange(hexfaces[i].UVS);

            //tilføge, men offset trekanterne (triangles)
            int offset = (4 * i);

            foreach (int triangle in hexfaces[i].triangles)
            {
                triss.Add (triangle + offset);

            }

            Hmesh.vertices = vertices.ToArray();
            Hmesh.triangles = triss.ToArray();
            Hmesh.uv = UVS.ToArray();
            Hmesh.RecalculateNormals();

        }
    }


    //Hvordan bliver en Hexface lavet. Kan justere indre og udre radius, samthøjden på dem. int point hjælper med at forbinde trekanterene.
    //revers bool hjælper med at flippe ting rundt, hvilket gør det nemmere at spejler hexfaces 
    private Hexface CreateHexface(float innerR, float outerR, float height1, float heihgt2, int point, bool revers = false)
    {
        Vector3 Point1 = Getpoints(innerR, heihgt2, point);
        Vector3 Point2 = Getpoints(innerR, heihgt2, (point < 5) ? point + 1 : 0);
        Vector3 Point3 = Getpoints(outerR, height1, (point < 5) ? point + 1 : 0);
        Vector3 Point4 = Getpoints(outerR, height1, point);


        List<Vector3> vertices = new List<Vector3>() { Point1, Point2, Point3, Point4 };
        List<int> triangles = new List<int>() { 0, 1, 2, 3, 4 };
        List<Vector2> UVS = new List<Vector2>() { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };
        if (revers) 
        {
            vertices.Reverse();
        }


        return new Hexface( vertices, triangles, UVS);


    }

    //bruger trigonomatri til at finde placeringen af de forskellige kanter 
    protected Vector3 Getpoints(int index, float size, float height)
    {

        float angleD = 60 * index;
        float angleR = Mathf.PI / 180 * angleD;
        return new Vector3((size * Mathf.Cos(angleR)), height, size * Mathf.Sin(angleR));

    }


}
    