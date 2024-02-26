using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Start is called before the first frame update
void Start()
{

}
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    