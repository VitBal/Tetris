using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Настройка ширины и высоты игровой доски.
/// </summary>
public class SettingBoard : MonoBehaviour
{
	/// <summary>
	/// Ширина игрового поля.
	/// </summary>
	public static int widthBoard;

	/// <summary>
	/// Высота игровго поля.
	/// </summary>
	public static int heightBoard;

	/// <summary>
	/// Значение выбранного режима игры.
	/// </summary>
	// public static bool gameMode;

	/// <summary>
	/// Выбор режима игры.
	/// </summary>
	public void ValueChanged()
	{		
		if (GetComponent<Dropdown>().value == 0)
		{
			Debug.Log("Выбран режим 1");
			// Инициализация данных игровой доски режима 1.
			widthBoard = 10;
			heightBoard = 20;
		}
		else if (GetComponent<Dropdown>().value == 1)
		{
			Debug.Log("Выбран режим 2");
			// Инициализация данных игровой доски режима 2.
			widthBoard = 12;
			heightBoard = 20;
        }	 
	}

    void OnEnable()
    {
        ValueChanged();
    }
		
}
