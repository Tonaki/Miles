using UnityEngine;
using System.Collections;

public class MeshCutter : MonoBehaviour 
{

	
	[ SerializeField ]
	private float interval = 0.3f;


	private bool fillSectionalView = false;


	private bool cutting = false;
	private Vector3 entryPoint = Vector3.zero;
	private float canCutTime = 0;


	public delegate void CutMeshDelegate( GameObject newObj, GameObject baseObj );
	public CutMeshDelegate cutObjectHandle = null;

	

	void Start()
	{

		cutObjectHandle = ( obj, baseObj )=>
		{

			Rigidbody rig = obj.AddComponent< Rigidbody >();
			rig.AddExplosionForce( 10, baseObj.transform.position, 10 );

		};

	}

	
	void OnTriggerEnter( Collider col )
	{

		if( canCutTime > Time.timeSinceLevelLoad ){

			return;

		}

		if( col.tag != "CutObject" ){

			return;

		}

		Mesh mesh = GetMesh( col.gameObject );

		if( mesh == null ){

			return;

		}

		entryPoint = col.collider.ClosestPointOnBounds( transform.position );

		cutting = true;

	}


	void OnTriggerExit( Collider col )
	{

		if( cutting == false ){

			return;

		}

		Mesh mesh = GetMesh( col.gameObject );

		Vector3 exitPoint = col.collider.ClosestPointOnBounds( transform.position );
		Transform baseTransform = col.transform;

		int meshVerticesLength = mesh.vertexCount;
		Vector3[] newVertices1 = mesh.vertices, newVertices2 = mesh.vertices;

		Material[] materials = col.renderer.materials;

		Vector3 cutNormal = Vector3.Cross( ( entryPoint - exitPoint ).normalized, new Vector3( 0, 0, 1 ) );
		Plane splitterPlane = new Plane( cutNormal, ( entryPoint + exitPoint ) * 0.5f );

		if( fillSectionalView ){

			Vector3 splitterNormal = splitterPlane.normal;

			for( int i = 0; i < meshVerticesLength; i++ ){

				if( splitterPlane.GetSide( baseTransform.TransformPoint( mesh.vertices[ i ] ) ) ){

					newVertices1[ i ] = baseTransform.InverseTransformPoint( baseTransform.TransformPoint( mesh.vertices[ i ] ) - splitterPlane.GetDistanceToPoint( baseTransform.TransformPoint( mesh.vertices[ i ] ) ) * splitterNormal );

				}else{

					newVertices2[ i ] = baseTransform.InverseTransformPoint( baseTransform.TransformPoint( mesh.vertices[ i ] ) - splitterPlane.GetDistanceToPoint( baseTransform.TransformPoint( mesh.vertices[ i ] ) ) * splitterNormal );

				}

			}

		}else{

			for( int i = 0; i < meshVerticesLength; i++ ){

				Vector3 inverseTransFormPoint = baseTransform.InverseTransformPoint( ( entryPoint + exitPoint ) * 0.5f );

				if( splitterPlane.GetSide( baseTransform.TransformPoint( mesh.vertices[ i ] ) ) ){

					newVertices1[ i ] = inverseTransFormPoint;

				}else{

					newVertices2[ i ] = inverseTransFormPoint;

				}

			}

		}

		SetupCutMesh( baseTransform, materials, mesh, newVertices1 );
		SetupCutMesh( baseTransform, materials, mesh, newVertices2 );

		Destroy( col.gameObject );

		cutting = false;

		canCutTime = Time.timeSinceLevelLoad + interval;

	}


	private Mesh GetMesh( GameObject col )
	{

		SkinnedMeshRenderer skinedMesh = col.GetComponentInChildren< SkinnedMeshRenderer >();

		if( skinedMesh != null ){

			return skinedMesh.sharedMesh;

		}

		MeshFilter meshFilter = col.GetComponentInChildren< MeshFilter >();

		if( meshFilter != null )
		{

			return meshFilter.mesh;

		}

		return null;

	}


	private GameObject SetupCutMesh( Transform baseTransform, Material[] materials, Mesh mesh, Vector3[] vertices )
	{

		GameObject obj = new GameObject( baseTransform.name );

		obj.tag = "CutObject";

		obj.transform.position = baseTransform.position;
		obj.transform.rotation = baseTransform.rotation;
		obj.transform.localScale = baseTransform.localScale;

		MeshFilter meshFilter = obj.AddComponent< MeshFilter >();
		MeshCollider meshCollider = obj.AddComponent< MeshCollider >();
		MeshRenderer meshRenderer = obj.AddComponent< MeshRenderer >();
		Mesh newMesh = ( Mesh )GameObject.Instantiate( mesh );

		AutoDelete auto = obj.AddComponent< AutoDelete >();
		auto.deleteTime = 10.0f;

		newMesh.vertices = vertices;

		meshFilter.mesh = newMesh;
		meshCollider.sharedMesh = newMesh;
		meshRenderer.materials = materials;
		meshCollider.convex = true;

		if( cutObjectHandle != null ){

			cutObjectHandle( obj, baseTransform.gameObject );

		}

		return obj;

	}

}