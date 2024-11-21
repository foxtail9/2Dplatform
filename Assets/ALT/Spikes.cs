using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	public int damage;
	public float damageRate;


	List<IDamageable> things = new List<IDamageable>();

	void Start()
	{
		InvokeRepeating("DealDamage", 0, damageRate);
	}
	void DealDamage()
	{
		for (int i = 0; i < things.Count; i++)
		{
			things[i].TakePhysicalDamage(damage);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out IDamageable damagable))
		{
			things.Add(damagable);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent(out IDamageable damagable))
		{
			things.Remove(damagable);
		}
	}
	public interface IDamageable
	{
		void TakePhysicalDamage(int damage);
	}
}
