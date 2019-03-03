using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создание игровой доски.
/// </summary>
public class CreateBoard : MonoBehaviour {

    /// <summary>
    /// Единица создания всего - игрового поля, форм и т.д.
    /// </summary>
    public Transform block;
    
    /// <summary>
    /// Метод создания нижней границы игровой доски.
    /// </summary>
    void createFooter() {
        for ( int x = 0; x < SettingBoard.widthBoard; x++) {
            Instantiate (block, new Vector3 (x, -1, 0), Quaternion.identity);
        }
    }

    /// <summary>
    /// Создаем  левую границу игровой доски.
    /// </summary>
    void createLeftBorder() {
        for ( int y = -1; y < SettingBoard.heightBoard; y++) {
            Instantiate (block, new Vector3 (- 1, y, 0), Quaternion.identity);
        }   
    }

    /// <summary>
    /// Создаем  правую границу игровой доски.
    /// </summary>
    void createRightBorder() {
        for ( int y = -1; y < SettingBoard.heightBoard; y++) {
            Instantiate (block, new Vector3 (SettingBoard.widthBoard, y, 0), Quaternion.identity);
        }   
    }
        
	void Awake () {		    
        createFooter();
        createLeftBorder();
        createRightBorder();          
	}	
}
