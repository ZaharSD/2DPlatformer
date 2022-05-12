
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	[SerializeField] private Text _amountCherry;

	private int _cherries = 0;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Cherry"))
		{
			SoundManager.Play("Collect");
			
			other.gameObject.SetActive(false);
			_cherries++;
			_amountCherry.text = "Cherries: " + _cherries;
		}
	}
}
