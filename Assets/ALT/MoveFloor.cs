using UnityEngine;
using DG.Tweening;

public class PlatformMover : MonoBehaviour
{
	//움직이는 위치
	[SerializeField] Vector3 moveTo = Vector3.zero;
	//움직이는 시간
	[SerializeField] float moveTime = 1f;
	[SerializeField] Ease ease = Ease.InOutQuad;

	Vector3 startPosition;
	private void Start()
	{
		//시작지점에서 position까지
		startPosition = transform.position;
		Move();
	}

	private void Move()
	{
		//SetEase(ease)>움직이는 방식 
		//SetLoops(int loops,LoopType loopType)>int loops의 값을 - 1 무한 반복,LoopType은 3가지 방식중 하나인 Yoyo
		transform.DOMove(startPosition + moveTo, moveTime).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 객체가 "Player" Layer인지 확인
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 플레이어를 발판의 자식으로 설정
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // "Player" Layer에서 벗어나면 부모-자식 관계 해제
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
