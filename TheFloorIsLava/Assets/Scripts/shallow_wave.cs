using UnityEngine;
using System.Collections;

public class shallow_wave : MonoBehaviour {
	int size;

    float[,] old_h, h, new_h;
    bool slower_wave = true;
    //Renderer renderer;

    // Use this for initialization
    void Start () {
		size = 120;
	
		//Resize the mesh into a size*size grid
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		mesh.Clear ();
        
		Vector3[] vertices=new Vector3[size*size];
		for (int i=0; i<size; i++)
		for (int j=0; j<size; j++) 
		{
			vertices[i*size+j].x=i*0.2f-size*0.1f;
			vertices[i*size+j].y=0;
			vertices[i*size+j].z=j*0.2f-size*0.1f;
		}
		int[] triangles = new int[(size - 1) * (size - 1) * 6];
		int index = 0;
		for (int i=0; i<size-1; i++)
		for (int j=0; j<size-1; j++)
		{
			triangles[index*6+0]=(i+0)*size+(j+0);
			triangles[index*6+1]=(i+0)*size+(j+1);
			triangles[index*6+2]=(i+1)*size+(j+1);
			triangles[index*6+3]=(i+0)*size+(j+0);
			triangles[index*6+4]=(i+1)*size+(j+1);
			triangles[index*6+5]=(i+1)*size+(j+0);
			index++;
		}
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();

        //define 3 float 2D arrays
        old_h = new float[size,size]; //prev height field
        h = new float[size, size]; //current
        new_h = new float[size, size]; //next

        //renderer = GetComponent<Renderer>();
        //Material new_material = Resources.Load("lava_material", typeof(Material)) as Material;
        //renderer.material = new_material;
        //renderer.material.mainTexture = Resources.Load("lava_texture", typeof(Texture)) as Texture;
        //Debug.Log(renderer.material.mainTexture);
    }

    void Shallow_Wave()
    {
        float rate = 0.005f;
        float damping = 0.999f;

        //compute new_h
        for (int i = 1; i < size - 1; i++)
        {
            for (int j = 1; j < size - 1; j++)
            {
                new_h[i, j] = h[i, j] + (h[i, j] - old_h[i, j]) * damping
                    + (h[i - 1, j] + h[i + 1, j] + h[i, j - 1] + h[i, j + 1]
                    - 4 * h[i, j]) * rate;
            }
        }

        //now set old_h = h, and h = new_h
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                old_h[i, j] = h[i, j];
                h[i, j] = new_h[i, j];
            }
        }
    }

	// Update is called once per frame
	void Update () 
	{
        Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;


        //Step 1: Copy vertices.y into h
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                h[i, j] = vertices[i*size + j].y;
            }
        }


        //Step 2: User interaction
        //if (Input.GetKeyDown(KeyCode.R))
        //for (int i=0; i<)
        //{
        if (slower_wave)
        {
            float m = Random.Range(0.03f, 0.05f);
            int i_rand = Random.Range(0, size - 1);
            int j_rand = Random.Range(0, size - 1);

            h[i_rand, j_rand] += m;
            //}
            slower_wave = false;
        } else
        {
            slower_wave = true;
        }


        //Step 3: Run Shallow Wave (8 times)
        for (int s = 1; s <= 8; s++)
        {
            Shallow_Wave();
        }


        //Step 4: Copy h back into mesh
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                vertices[i * size + j].y = h[i, j];
            }
        }


        //overwrite mesh.vertices and recalc norms
        mesh.vertices = vertices;
		mesh.RecalculateNormals ();
        
	}
}
