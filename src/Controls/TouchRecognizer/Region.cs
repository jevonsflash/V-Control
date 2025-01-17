namespace VControl.Controls
{
    public class Region
    {
        public Region() { }

        public Region(double sx, double ex, double sy, double ey, string name = "")
            : this()
        {
            StartX = sx;
            EndX = ex;
            StartY = sy;
            EndY = ey;
            Name = name;
        }

        public string Name { get; set; }

        public double StartX { get; set; }

        public double EndX { get; set; }

        public double StartY { get; set; }

        public double EndY { get; set; }

        public double Width => EndX - StartX;

        public double Height => EndY - StartY;

        public bool Contains(Region content)
        {
            var translationX = 0;
            var translationY = 0;
            var isXin =
                translationX >= StartX - content.Width / 2
                && translationX <= EndX - content.Width / 2;
            var isYin =
                translationY >= StartY - content.Height / 2
                && translationY <= EndY - content.Height / 2;
            return isXin && isYin;
        }

        public bool Contains(Point point)
        {
            var translationX = 0;
            var translationY = 0;
            var isXin = translationX >= StartX - point.X && translationX <= EndX - point.X;
            var isYin = translationY >= StartY - point.Y && translationY <= EndY - point.Y;
            return isXin && isYin;
        }
    }
}
