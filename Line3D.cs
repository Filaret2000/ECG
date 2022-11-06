using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace Crainiciuc_Filaret_Niculai
{
    class Line3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private bool visibility;
        private Color color;
        private float width;
        private const float MAX_SIZE = 5.0f;
        private const float DEFAULT_SIZE = 1.0f;

        public Line3D(Randomizer r)
        {
            pointA = new Vector3(0, 0, 0);
            pointB = new Vector3(10, 0, 0);
            visibility = true;
            color = r.RandomColor();
            width = DEFAULT_SIZE;
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.LineWidth(width);
                GL.Begin(PrimitiveType.Lines);

                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);

                GL.End();
            }
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleWidth()
        {
            if (width == DEFAULT_SIZE)
                width = MAX_SIZE;
            else
                width = DEFAULT_SIZE;
        }

        public void DiscoMode(Randomizer r)
        {
            color = r.RandomColor();
        }
    }
}
