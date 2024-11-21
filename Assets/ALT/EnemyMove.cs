using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	Rigidbody2D rigid;
	Animator anim;
	SpriteRenderer spriteRenderer;
	public float speed = 1.0f;
	public int nextMove;
	public float wallCheckDistance = 0.5f; // 벽 감지 거리

	void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		Think();

		Invoke("Think", 6);
	}

	void FixedUpdate()
	{
		//Move
		rigid.velocity = new Vector2(nextMove * speed, rigid.velocity.y);

		//Platform Check
		Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
		Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
		RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
		if (rayHit.collider == null)
		{
			Turn();
		}

		// Wall Check
		CheckForWalls();
	}

	// 재귀 함수
	void Think()
	{
		//Set Next Active
		nextMove = Random.Range(-1, 2);

		//Sprite Animation
		anim.SetInteger("WalkSpeed", nextMove);

		//Flip Sprite
		if (nextMove != 0)
			spriteRenderer.flipX = nextMove == 1;

		//Recursive
		float nextThinkTime = Random.Range(2f, 5f);
		Invoke("Think", nextThinkTime);
	}

	void Turn()
	{
		nextMove *= -1;
		spriteRenderer.flipX = nextMove == 1;
		CancelInvoke();
		Invoke("Think", 6);
	}

	void CheckForWalls()
	{
		// 전방에 벽 체크
		Vector2 frontWallVec = new Vector2(rigid.position.x + nextMove * wallCheckDistance, rigid.position.y);
		Debug.DrawRay(frontWallVec, Vector2.right * nextMove, Color.blue);
		RaycastHit2D wallHit = Physics2D.Raycast(frontWallVec, Vector2.right * nextMove, wallCheckDistance, LayerMask.GetMask("Wall"));

		if (wallHit.collider != null)
		{
			Turn();
		}
	}

	// 시각적으로 탐지 범위 확인
	void OnDrawGizmosSelected()
	{
		// 벽 감지 거리 확인
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.right * nextMove * wallCheckDistance);
	}
}
