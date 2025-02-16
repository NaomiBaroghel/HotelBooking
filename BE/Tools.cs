﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BE
{
        static class Tools
        {
            public static string ToStringProperty<T>(this T t)
            {
                string str = "";
                foreach (PropertyInfo item in t.GetType().GetProperties())
                    str += "\n" + item.Name + ": " + item.GetValue(t, null);
                return str;
            }

        public static T[] Flatten<T>(this T[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            T[] arrFlattened = new T[rows * columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var test = arr[i, j];
                    arrFlattened[j * rows + i] = arr[i, j];
                }
            }
            return arrFlattened;
        }
        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int length = arr.GetLength(0);
            int columns = length / rows;
            T[,] arrExpanded = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arrExpanded[i, j] = arr[j * rows + i];
                }
            }
            return arrExpanded;
        }

    }

}
