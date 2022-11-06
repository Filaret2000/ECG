using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Crainiciuc_Filaret_Niculai
{
    class Point3D
    {
        private Vector3 position;
        private bool visibility;
        private Color color;
        private float size;
        private const float MAX_SIZE = 15.0f;
        private const float DEFAULT_SIZE = 1.0f;

        public Point3D(Randomizer r)
        {
            position = new Vector3(1, 0, 0);
            visibility = true;
            color = r.RandomColor();
            size = DEFAULT_SIZE;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleSize()
        {
            if (size == DEFAULT_SIZE)
                size = MAX_SIZE;
            else
                size = DEFAULT_SIZE;
        }
        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(size);
                GL.Begin(PrimitiveType.Points);

                GL.Color3(color);
                GL.Vertex3(position);

                GL.End();
            }
        }
    }
}
