using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HepsiBuradaCase
{
    public class Rover
    {
        #region Fields
        Point position;
        CardinalDirections direction;
        Point boardSize;
        #endregion

        #region Constructor
        public Rover(int x, int y, CardinalDirections direction, int maxBoardX, int maxBoardY)
        {
            maxBoardX = maxBoardX > 0 ? maxBoardX : 1;
            maxBoardY = maxBoardY > 0 ? maxBoardY : 1;
            x = (x < 0 || x > maxBoardX) ? 0 : x;
            y = (y < 0 || y > maxBoardY) ? 0 : y;

            boardSize = new Point(maxBoardX, maxBoardY);
            position = new Point(x, y);
            this.direction = direction;
        }
        #endregion

        #region Methods
        private void RotateLeft()
        {
            switch (this.direction)
            {
                case CardinalDirections.N:
                    this.direction = CardinalDirections.W;
                    break;
                case CardinalDirections.S:
                    this.direction = CardinalDirections.E;
                    break;
                case CardinalDirections.E:
                    this.direction = CardinalDirections.N;
                    break;
                case CardinalDirections.W:
                    this.direction = CardinalDirections.S;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (this.direction)
            {
                case CardinalDirections.N:
                    this.direction = CardinalDirections.E;
                    break;
                case CardinalDirections.S:
                    this.direction = CardinalDirections.W;
                    break;
                case CardinalDirections.E:
                    this.direction = CardinalDirections.S;
                    break;
                case CardinalDirections.W:
                    this.direction = CardinalDirections.N;
                    break;
            }
        }

        private bool Move()
        {
            switch (this.direction)
            {
                case CardinalDirections.N:
                    this.position.Y += 1;
                    break;
                case CardinalDirections.S:
                    this.position.Y -= 1;
                    break;
                case CardinalDirections.E:
                    this.position.X += 1;
                    break;
                case CardinalDirections.W:
                    this.position.X -= 1;
                    break;
            }

            if (position.X > boardSize.X || position.Y > boardSize.Y || position.X < 0 || position.Y < 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Applies command to rover and returns current location and heading direction OR a string explains the exception
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public string ApplyCommands(string commands)
        {
            int commandCount = 0;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'M':
                        if (!Move())
                            return $"The rover couldnt execute the move command with index : {commandCount} (Rovers new position is : {position.X} {position.Y} but the board is : {boardSize.X} X {boardSize.Y})";
                        break;
                    default:
                        return $"The rover doesn't know the command with index {commandCount} Which is : {command}";
                }
                commandCount++;
            }
            return $"{position.X} {position.Y} {direction}";
        }
        #endregion
    }
}
