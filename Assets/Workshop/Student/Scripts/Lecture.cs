using System;
using System.Text;
using UnityEngine;


public class Lecture : MonoBehaviour
{
    private void Start()
    {
        LCT01_SyntaxArray();
        LCT02_ArrayInitialize();
        LCT03_SyntaxLoop();
        LCT04_LoopAndArray();
        LCT05_Syntax2DArray();
        LCT06_SizeOf2DArray();
        LCT07_SyntaxNestedLoop();
    }
    // ===================== LCT01 =====================
    public void LCT01_SyntaxArray()
    {
        string[] _ironManSuit = new string[2]; //ใช้ภายในฟังก์ชันนี้
        //_ironManSuit[-1] index -1 บอกว่ายังค้นหาข้อมูล
        _ironManSuit[0] = "Mark I"; //set
        _ironManSuit[1] = "Mark II";
        //_ironManSuit[1] = 'a'; ใส่ข้อมูลให้ถูก
        //_ironManSuit[2] = "Mark III"; ห้ามเกิน
        string tonyStarkWear = _ironManSuit[0]; //get
        Debug.Log("TonyStark Wear: " + tonyStarkWear);
        Debug.Log("Room size: " + _ironManSuit.Length);
        //การเข้าถึงขนาดของ Array เพื่อใช้งานร่วมกับ for
        Debug.Log(_ironManSuit[0]);
        Debug.Log(_ironManSuit[1]);
    }

    // ===================== LCT02 =====================
    public void LCT02_ArrayInitialize()
    {
        string[] spidermanSuits = new string[] { "Classic", "Black Suit", "Iron Spider" };
        string[] batmanSuits = new string[2] { "Classic batman", "White bat" };
        //วิธีการประกาศพร้อมชุดข้อมูล

        Debug.Log("Room size: " + spidermanSuits.Length);
        Debug.Log(spidermanSuits[0]);
        Debug.Log(spidermanSuits[1]);
        Debug.Log(spidermanSuits[2]);

        Debug.Log("Room size: " + batmanSuits.Length);
        Debug.Log(batmanSuits[0]);
        Debug.Log(batmanSuits[1]);
    }

    // ===================== LCT03 =====================
    public void LCT03_SyntaxLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("<10 : " + i);
        }
        Debug.Log("===================");
        for (int i = 1; i <= 10; i++)
        {
            Debug.Log("<=10 : " + i);
        }
    }

    // ===================== LCT04 =====================
    [Header("LCT04_LoopAndArray")]
    public string[] lct04_ironManSuitNames;

    public void LCT04_LoopAndArray()
    {
        Debug.Log("====== Log by One increment ======");
        for (int i = 0; i < lct04_ironManSuitNames.Length; i++) //เพิ่มทีละ 1
        {
            Debug.Log(lct04_ironManSuitNames[i]);
        }
        Debug.Log("====== Log by Two increment ======");
        for (int i = 0; i < lct04_ironManSuitNames.Length; i += 2) //เพิ่มทีละ 2
        {
            Debug.Log(lct04_ironManSuitNames[i]);
        }
    }

    // ===================== LCT05 =====================
    public void LCT05_Syntax2DArray()
    {
        int[,] my2DArray = new int[3, 3]
        {
            //col 1 2 3
            //col 0 1 2
            { 1, 2, 3 }, //row 1 0
            { 4, 5, 6 }, //row 2 1
            { 7, 8, 9 }, //row 3 2
        };

        //GetLength(0) หมายถึง Array ช่องแรก หรือ X หรือ row
        for (int row = 0; row < my2DArray.GetLength(0); row++)
        {
            string rowStr = "";
            //GetLength(1) หมายถึง Array ช่องสอง หรือ Y หรือ col
            for (int col = 0; col < my2DArray.GetLength(1); col++)
            {
                rowStr += my2DArray[row, col] + ",";
            }
            Debug.Log(rowStr);
        }
    }

    // ===================== LCT06 =====================
    [Header("LCT06_SizeOf2DArray")]
    public int[,] LCT062DArray; //จะไม่แสดงข้อมูลใน unity

    public Grid2DInt lct06_my2DArray = new Grid2DInt //ต้องใช้ตัวนี้
    {
        rows = 3,
        cols = 5,
        data = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 }
    };

    public void LCT06_SizeOf2DArray()
    {
        int[,] my2DArray = lct06_my2DArray.Get2DArray();

        int rows = my2DArray.GetLength(0);
        int cols = my2DArray.GetLength(1);
        int size = my2DArray.Length;

        Debug.Log("rows " + rows);
        Debug.Log("cols " + cols);
        Debug.Log("size " + size);
    }

    // ===================== LCT07 =====================
    [Header("LCT07_SyntaxNestedLoop")]
    public int lct07_columns;
    public int lct07_rows;

    public void LCT07_SyntaxNestedLoop()
    {
        for (int row = 0; row < lct07_rows; row++)
        {
            string rowStr = "";
            for (int col = 0; col < lct07_columns; col++)
            {
                rowStr += $"({row},{col}) ";
            }
            Debug.Log(rowStr);
        }
    }


    private void PrintBoard(string[,] board)
    {
        StringBuilder sb = new();
        for (int i = 0; i < 3; i++)
        {
            sb.AppendLine("-------------");
            sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
        }
        sb.AppendLine("-------------");
        Debug.Log(sb.ToString());
    }
}