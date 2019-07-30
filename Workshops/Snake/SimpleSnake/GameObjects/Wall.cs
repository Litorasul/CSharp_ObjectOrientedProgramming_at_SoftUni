namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.TopY == 0 || snakeHead.LeftX == 0
                || snakeHead.LeftX == this.LeftX - 1 || snakeHead.TopY == this.TopY;
        }
    }
}
