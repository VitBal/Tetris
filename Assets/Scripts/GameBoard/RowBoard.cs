using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предназначен для манипуляции со строками в сетке игрвой доски.
/// </summary>
public class RowBoard : MonoBehaviour
{
    // Ссылки на ширину и высоту.
    public static int width = SettingBoard.widthBoard;
    public static int height = SettingBoard.heightBoard;
    
    // Ссылка на сетку игровой доски.
    public static Transform[,] gameGrid = GridBoard.gameGrid;
    
    // Функция удаления 1 строки
    // *! Функция удаления 2 строк
    public static void deleteRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(gameGrid[x, y].gameObject);
            gameGrid[x, y] = null;
        }
    }

    // Функция падения блоков, после удаления 1 строки
    // * Функция падения блоков, после удаления 2 строк
    // columnInBoard что то не оч подходит это название
    public static void fallingRow(int yCoordinateInBoard)
    {
        for (int x = 0; x < width; x++)
        {
            if (gameGrid[x, yCoordinateInBoard] != null)
            {
                // Движение блока вниз
                gameGrid[x, yCoordinateInBoard - 1] = gameGrid[x, yCoordinateInBoard];
                gameGrid[x, yCoordinateInBoard] = null;

                // Обновление позиции блоков
                gameGrid[x, yCoordinateInBoard - 1].position += new Vector3(0, -1, 0);

            }
        }
    }

    // Функция перемещающая все строки выше удаленной, а не одну
    public static void fallingAllRow(int yCoordinateRow)
    {
        for (int i = yCoordinateRow; yCoordinateRow < height; i++)
        {
            fallingRow(i);
        }
    }

    // Функция, определяющая заполнена ли 1 строка
    // * Функция заполнения 2 строк
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; x++)
            if (gameGrid[x, y] == null)
            {
                return false;
            }
        return true;
    }

    // Функция обобщающая все вспомогательные функции для удаления всех полных строк
    public static void deleteFullRows()
    {
        for (int y = 0; y < height; y++)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                fallingAllRow(y + 1);
                // Добавление очков при удалении строчки
                ScoreManager.score += (height - y) * 10;
                y--;
            }
        }
    }

    
}
