using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays_PathFinding
{
    public class Point { public int X; public int Y; }
    public class Square
    {
        public bool IsOneCell;
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;
    }

    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            bool IsValid(char sign) => sign == '1';

            bool DoesExist(int index, int length) => index >= 0 && index < length;

            int MaxSquares = 0;
            int yLength = matrix.Length;
            int xLength = matrix[0].Length;

            var tempSquare = new Square();

            for (int indexY = 0; indexY < yLength; indexY++)
            {
                for (int indexX = 0; indexX < xLength; indexX++)
                {
                    // Found the initial TopLeft corner
                    if (IsValid(matrix[indexY][indexX]))
                    {
                        tempSquare = new Square();
                        tempSquare.TopLeft = new Point { X = indexX, Y = indexY };

                        var index = 1;
                        do
                        {
                            // Check if points exist
                            if (index < yLength && index < xLength
                               && DoesExist(indexX + index, matrix[indexY].Length) // Right
                               && DoesExist(indexY + index, matrix.Length) // BottomLeft
                               && DoesExist(indexY + index, matrix.Length) // BottomRig
                                )
                            {
                                if (IsValid(matrix[indexY][indexX + index])
                                    && IsValid(matrix[indexY + index][indexX])
                                    && IsValid(matrix[indexY + index][indexX + index]))
                                {
                                    // Check all cells 
                                    bool valid = true;
                                    for (int tempY = indexY; tempY <= indexY + index; tempY++)
                                        if (matrix[tempY][indexX + index] == '0')
                                        {
                                            valid = false;
                                            break;
                                        }

                                    if (valid)
                                        for (int tempX = indexX; tempX <= indexX + index; tempX++)
                                            if (matrix[indexY + index][tempX] == '0')
                                            {
                                                valid = false;
                                                break;
                                            }

                                    if (valid)
                                    {
                                        tempSquare.TopRight = new Point { X = indexX + index, Y = indexY };
                                        tempSquare.BottomLeft = new Point { X = indexX, Y = indexY + index };
                                        tempSquare.BottomRight = new Point { X = indexX + index, Y = indexY + index };
                                    }
                                    else
                                        break;
                                    index++;
                                }
                                else
                                    break;
                            }
                            else
                                break;

                        } while (true);

                        if (tempSquare.TopRight == null)
                            tempSquare.IsOneCell = true;

                        int result = 0;
                        if (!tempSquare.IsOneCell)
                        {
                            var length = ((tempSquare.TopRight.X - tempSquare.TopLeft.X) + 1);
                            result = length * length;
                        }
                        else
                            result = 1;

                        if (MaxSquares < result)
                            MaxSquares = result;
                    }
                }
            }

            return MaxSquares;
        }
    }
}
