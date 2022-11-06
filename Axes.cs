using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Crainiciuc_Filaret_Niculai
{
    /// <summary>
    /// Deseneaza axele. Lab3 ex 1
    /// </summary>
    class Axes
    {
        private bool visibility;
        private const float AXIS_LENGHT = 75;
        private float axisWidth;

        public Axes()
        {
            visibility = true;
            axisWidth = 1.0f;
        }

        public void ToggleVisibility()
        {
            if (visibility == true)
                visibility = false;
            else
                visibility = true;
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.LineWidth(axisWidth);

                GL.Begin(PrimitiveType.Lines);

                GL.Color3(Color.Green);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, AXIS_LENGHT, 0);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(AXIS_LENGHT, 0, 0);
                GL.Color3(Color.Blue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, AXIS_LENGHT);

                GL.End();
            }
        }
    }
}
