using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Предназначен для хранения всей основной логики игры "Tetris".
/// </summary>
public class GameManager : MonoBehaviour
{		
    // Ссылки на ширину и высоту.
    public static int width = SettingBoard.widthBoard;
    public static int height = SettingBoard.heightBoard;

    // Через сколько секунд начнет движение Tetramino,
    // 0 - движение начнется сразу после загрузки сцены.	
	float lastFall = 0;
	
    // Игровая доска в виде двумерного массива (ширина и высота соответственно).
    // public Transform[,] gameGrid = new Transform[width, height];
    
	// Метод проверки Tetramino.
	bool CheckPosition() {
		
		foreach (Transform tetramino in transform) {
			
			Vector2 vectorRound = GridBoard.roundoffCoordinates(tetramino.position);

			// Проверка, находится ли фигура внутри игровой доски.
			if(!GridBoard.insideBorder(vectorRound)){
				// Debug.Log ("Tetramino NOT in the game board!");
				return false;
			}

			// Проверка чего?
			/*
			if (GridBoard.gameGrid[(int)vectorRound.x, (int)vectorRound.y] != null &&
				GridBoard.gameGrid[(int)vectorRound.x, (int)vectorRound.y].parent != transform)
			{
				Debug.Log ("Что то проверил и это пошло не так");
				return false;
			}
			*/
		}

		return true;
		
	}

	// Метод проверки левой границы игровой доски для Режима 1
	void CheckLeftBorder(){
		// Движение влево на 1 единицу
		transform.position += new Vector3(-1, 0, 0);

		// только для Mode 1
		// Проверка позиции Tetramino
		if (CheckPosition ()) {

		} else {
			transform.position += new Vector3(1, 0, 0);
		}
	}

	// Метод проверки првой границы игровой доски для Режима 1
	void CheckRightBorder(){
		// Движение вправо
		transform.position += new Vector3(1, 0, 0);

		// только для Mode 1 ------------------------------------
		// Проверка позиции Tetramino
		if (CheckPosition ()) {

		} else {
			transform.position += new Vector3(-1, 0, 0);
		}
	}
    
	// Метод прохождения левой границы игровой доски для Режима 2
	void MoveOutLeftBorder(){
		// Движение влево на 1 единицу
		transform.position += new Vector3(-1, 0, 0);

		// countBlockInTetramino - содержит число дочерних элементов
		int countBlockInTetramino = transform.childCount;
		// Debug.Log("Количество дочерних объектов: " + countBlockInTetramino);

        if (transform.CompareTag("Tetramino")) {
            for (int i = 0; i <= countBlockInTetramino; i++)
		    {   

			    // childXCoord - координата по X дочернего элемента			                
			    int childXCoord =  (int)transform.GetChild (i).transform.position.x;
			    
                Debug.Log("childXCoord: " + childXCoord);

			    // если дочерний элемент выходит за границу игровой доски по X
			    if (childXCoord == -1)
			    {
				    // то он появляется с другой стороны
				    transform.GetChild(i).transform.position += new Vector3(width + 1, 0, 0);
			    }
		    }
        } else {
            Debug.Log("No child");
        }        
	}

	// Метод прохождения правой границы игровой доски для Режима 2
	void MoveOutRightBorder(){
		// Движение влево на 1 единицу
		transform.position += new Vector3(1, 0, 0);

		// countBlockInTetramino - содержит число дочерних элементов
		int countBlockInTetramino = transform.childCount;
		// Debug.Log("Количество дочерних объектов: " + countBlockInTetramino);

        // transform.CompareTag("block")
        if(countBlockInTetramino > 0) {
            for (int i = 0; i <= countBlockInTetramino; i++)
		    {   
			    // childXCoord - координата по X дочернего элемента
			    int childXCoord =  (int)transform.GetChild (i).transform.position.x;
			    
                // Debug.Log("childXCoord: " + childXCoord);

			    // если дочерний элемент выходит за границу игровой доски по X
			    if (childXCoord == (width - 1))
			    {
				    // то он появляется с другой стороны
				    transform.GetChild(i).transform.position += new Vector3(0 - width, 0, 0);
			    }
		    }
        // } else {
        //    Debug.Log("No child");
        } 		
	}

	void Start()
	{
						
	}
        
	
	void Update()
	{
        
		// Move Left
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			// Mode 1
			CheckLeftBorder ();

			// Mode 2 
			// MoveOutLeftBorder();

            
        }

		// Move Right
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			// Mode 1
			CheckRightBorder ();

			// Mode 2
			// MoveOutRightBorder();
            
        }

		// Rotate
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.Rotate(0, 0, -90);
            
            if (CheckPosition ()) {

		    } else {			
                transform.Rotate(0, 0, 90);
		    }
        }




		// Fall 
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1)
		{
			// Mode 1 ------------------------------------
            transform.position += new Vector3(0, -1, 0);

			// только для Mode 1
			// Проверка позиции Tetramino
			if (CheckPosition ()) {

			} else {
				transform.position += new Vector3(0, 1, 0);

                // Создается новый элемент
                // CreateTetramino.SpawnTetraminoMode1();
                
			}

			// Mode 2 ------------------------------------
			/*
            int yCoord = (int)transform.position.y;

            if (yCoord == 0)
            {
                transform.position += new Vector3(0, 19, 0);
            }
			*/

			lastFall = Time.time;
		}
	}
}
