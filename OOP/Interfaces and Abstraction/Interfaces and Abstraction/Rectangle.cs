﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_Abstraction
{
    public class Rectangle
    {
        private IDrawer drawer;

        public Rectangle(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void Draw(int row, int col, int width, int height)
        {
            int x = row;
            int y = col;
            char Edge = '#';
            string Message = "Hello";

            int LastIndex = 0;
            Console.SetCursorPosition(x, y);
            for (int h_i = 0; h_i <= height; h_i++)
            {
                if (LastIndex != -1)
                {
                    int seaindex = (LastIndex + (width - 1));
                    if (seaindex >= Message.Length - 1)
                        seaindex = Message.Length - 1;
                    int newIndex = Message.LastIndexOf(' ', seaindex);
                    if (newIndex == -1)
                        newIndex = Message.Length - 1;
                    string substr = Message.Substring(LastIndex, newIndex - LastIndex);
                    LastIndex = newIndex;
                    Console.SetCursorPosition(x + 1, y + h_i);
                    Console.Write(substr);
                }
                for (int w_i = 0; w_i <= width; w_i++)
                {

                    if (h_i % height == 0 || w_i % width == 0)
                    {
                        Console.SetCursorPosition(x + w_i, y + h_i);
                        Console.Write(Edge);
                    }


                }

            }
        }
    }
}
