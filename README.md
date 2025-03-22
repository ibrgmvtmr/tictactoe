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
