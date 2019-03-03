using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Предназначен для создания Tetramino.
/// </summary>
public class CreateTetramino : MonoBehaviour {

	// Набор префабов для игры режима 1.
	public GameObject[] tetraminoMode1;
	// Набор префабов для игры режима 2.
	public GameObject[] tetraminoMode2;
        
	// Создает Tetramino Режим 1
	public void SpawnTetraminoMode1(){
		
		Instantiate (tetraminoMode1 [Random.Range(0, tetraminoMode1.Length)], new Vector3 (5, 19, 0), Quaternion.identity);
		// Debug.Log ("CreateTetramino Выбран режим 1");
	}

    // Создает Tetramino Режим 2
	public void SpawnTetraminoMode2(){
	
		Instantiate (tetraminoMode2 [Random.Range(0, tetraminoMode2.Length)], new Vector3 (5, 19, 0), Quaternion.identity);
		// Debug.Log ("CreateTetramino Выбран режим 2");
	}

	// Use this for initialization
	void Start () {
		SpawnTetraminoMode1();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Это изменение для тестирования github
}
