using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предназначен для представления состояния
/// игровой доски в виде двумерного массива или сетки.
/// </summary>
public class GridBoard : MonoBehaviour
{
    // Ссылки на ширину и высоту.
    public static int width = SettingBoard.widthBoard;
    public static int height = SettingBoard.heightBoard;

    // Игровая доска в виде двумерного массива (ширина и высота соответственно).
    public static Transform[,] gameGrid = new Transform[width, height];

	void Update(){
		
	}

	public static bool insideBorder(Vector2 vectorPositionInBoard)
	{
		int xCoord = (int)vectorPositionInBoard.x;
		int yCoord = (int)vectorPositionInBoard.y;

		return (xCoord >= 0 && xCoord < width && yCoord >= 0);
	}

	public static Vector2 roundoffCoordinates(Vector2 vector)
	{
		// vector.x - составляющая вектора по оси Оx
		// vector.y - составляющая вектора по оси Оy
		return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
	}


	/*
    // Метод округления координат.
    // Mathf - структура общих мат. функций.
    // Round - возвращает округленное число ( в том числе случай числа заканчивающего на .5f).
    public Vector2 roundoffCoordinates(Vector2 vector)
    {
        // vector.x - составляющая вектора по оси Оx
        // vector.y - составляющая вектора по оси Оy
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    // Метод проверки: находится ли блок Mino границы внутри области
    // по x: между 0 и шириной игровой области/стакана w
    // по y: выше 0 без ограничений по высоте 

	public bool insideBorder(Vector2 vectorPositionInBoard)
    {
        int xCoord = (int)vectorPositionInBoard.x;
        int yCoord = (int)vectorPositionInBoard.y;
                
        return (xCoord >= 0 && xCoord < width && yCoord >= 0);
    }

    // Функция проверки блоков Mino	    	
    public bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {            
            Vector2 vectorRound = roundoffCoordinates(child.position);

            // Ссылка на метод insideBorder()
            // если блок не находится в области игорового поля/стакана
            // вернуть ложь
            // ! ------ если insideBorder(vectorRound) ложное, то возвращает true
            // если вне доски, то ошибка
            /*
            if (!insideBorder(vectorRound)){
                return false;
            }
            */
			/*
            // Если 
            // -----			
            if (gameGrid[(int)vectorRound.x, (int)vectorRound.y] != null &&
                gameGrid[(int)vectorRound.x, (int)vectorRound.y].parent != transform)
            {
                return false;
            }


        }
        return true;
    }


    /// <summary>
    /// Updates the grid.
    /// </summary>
    public void updateGrid()
    {
        // Удалить старые объекты с сетки игровой доски
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                if (gameGrid[x, y] != null)
                {
                    if (gameGrid[x, y].parent == transform)
                    {
                        gameGrid[x, y] = null;
                    }
                }

        // Добавить новые объекты к сетке игровой доске
        foreach (Transform child in transform)
        {
            Vector2 v = roundoffCoordinates(child.position);
            gameGrid[(int)v.x, (int)v.y] = child;
        }
    }
    */
}
