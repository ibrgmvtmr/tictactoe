# 🎮 Tic Tac Toe Console Application (C# MVC + xUnit)

> A console-based Tic Tac Toe game following the MVC pattern and tested with xUnit.

## 📚 Overview

This is a **console application** for playing Tic Tac Toe (also known as Noughts and Crosses) with customizable board sizes and save/load functionality.  
The project is structured using the **Model-View-Controller (MVC)** pattern and includes unit tests for the game logic using **xUnit**.

## ✨ Features

- 🟢 Selectable board sizes: **3x3**, **4x4**, or **5x5**
- 🟢 Save and load game progress (`save.txt`)
- 🟢 Win and draw detection
- 🟢 Automatic save after every turn
- 🟢 Manual save via **S** key
- 🟢 Highlight winning line on the board
- 🟢 Unit tests with **xUnit**

## 🗂 Project Structure
TicTacToe/ ├──
            Program.cs 
            View (main menu, user input) 
            GameController.cs 
            Controller (game loop, turn handling)
            TicTacToeGame.cs # Model (board logic, win checks, save/load) 
            View.cs # View helpers (rendering, messages)
            Save file (created during runtime) 
└── TicTacToe.Tests/ # Unit tests (xUnit)

## 💾 Save System

### Save file location:
The game saves progress to a plain text file named **`save.txt`** in the root directory.

### Save file format:
The save file is a plain text file with the following structure:
<size> <row1> <row2> <row3> ... ```
<size>: A single number representing the board size (e.g., 3 for a 3x3 board).

<rowX>: Each subsequent line represents one row of the board.

X and O indicate player moves.

A period (.) represents an empty cell.

##  Running the Game
###Prerequisites:
.NET 8 SDK or later

### How to run:
Open a terminal in the project root.

Execute the following command:
dotnet run --project TicTacToe

## 🧪 Running Tests
The project includes unit tests for the core game logic using xUnit.

### To run the tests:
Open a terminal in the project root.
Execute: dotnet test TicTacToe.Tests

### Tests cover:
1. Board initialization
2. Turn alternation logic
3. Win condition detection (rows, columns, diagonals)
4. Draw detection
5. Save/Load functionality

![image](https://github.com/user-attachments/assets/93dd64e6-dce5-4771-b9b5-fa74473c3005)
![image](https://github.com/user-attachments/assets/18bd4b42-6de5-4c0e-953b-1c1dc840e4a3)
![image](https://github.com/user-attachments/assets/eab0106b-3fd1-434a-90c4-30f59fd077d2)
![image](https://github.com/user-attachments/assets/02947412-d2f1-4afa-8430-52f23adb4ffd)
![image](https://github.com/user-attachments/assets/5b636873-0726-4203-a3b9-a0a4c6e19042)

#### video explanation: [Uploading video.zip…]()





