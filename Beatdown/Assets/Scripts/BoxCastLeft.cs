using UnityEngine;
using System.Linq; 
using System.Collections;

public class BoxCastLeft : MonoBehaviour {

	public Rect Box; 
	public Vector2 Direction;
	public float Distance; 
	public RaycastHit2D[] hits; 
	public GameObject[] hitGO;
	public RaycastHit2D firstHit; 
	public LayerMask mask; 
	public GameObject Player;
	public bool facingLeft = false; 
	public BoxCastRight RightBox; 



	void OnDrawGizmos() { 
		if (hits != null) {
			foreach (var h in hits) { 
				Gizmos.color = Color.white; 
				Gizmos.DrawCube (h.collider.transform.position, Vector2.one * 0.16f);

			}
		}

		if (firstHit.collider != null) {
			Gizmos.color = Color.cyan; 
			Gizmos.DrawCube (firstHit.collider.transform.position, Vector2.one * 0.16f);


		}

		Gizmos.color = Color.green; 
		Gizmos.matrix = Matrix4x4.TRS ((Vector2)this.transform.position + Box.center, this.transform.rotation, Vector3.one); 
		Gizmos.DrawWireCube (Vector2.zero, Box.size); 
		Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + Box.center + Direction.normalized * Distance, this.transform.rotation, Vector3.one);
		Gizmos.DrawWireCube(Vector2.zero, Box.size); 
		Gizmos.color = Color.cyan; 
		Gizmos.matrix = Matrix4x4.TRS ((Vector2)this.transform.position + Box.center, Quaternion.identity, Vector3.one); 
		Gizmos.DrawLine (Vector2.zero, Direction.normalized * Distance); 

	}
	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag ("Player");
		RightBox = FindObjectOfType<BoxCastRight> ();

	}
	
	// Update is called once per frame
	void Update () {
		hits = Physics2D.BoxCastAll ((Vector2)this.transform.position + Box.center, 
			Box.size, this.transform.eulerAngles.z, Direction, Distance, mask); 

		firstHit = Physics2D.BoxCast ((Vector2)this.transform.position + Box.center, Box.size, this.transform.eulerAngles.z, Direction, Distance, mask);
		hitGO = hits.Where (x => x.collider != null).Select (x => x.collider.gameObject).ToArray ();
		if (firstHit == Player) {
			facingLeft = true; 
			if (facingLeft == true) { 
				RightBox.facingRight = false; 
			} 

			transform.localScale = new Vector3(-1, 1);
		
		} 

	}



}
