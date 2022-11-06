using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Crainiciuc_Filaret_Niculai
{
    class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private float a, b, c, d;
        private bool visibility;
        private bool alpha;
        private Color color;
        private float lineWidth;
        private float pointSize;
        private const float MAX_SIZE = 5.0f;
        private const float DEFAULT_SIZE = 1.0f;
        private Randomizer localRandom;
        private PolygonMode polygonMode;

        public Triangle3D(Randomizer r)
        {
            localRandom = r;

            pointA = r.RandomPoint();
            pointB = r.RandomPoint();
            pointC = r.RandomPoint();
            color = r.RandomColor();

            a = localRandom.RandomPozitiveInt(11) / 10.0f;
            b = localRandom.RandomPozitiveInt(11) / 10.0f;
            c = localRandom.RandomPozitiveInt(11) / 10.0f;
            d = localRandom.RandomPozitiveInt(11) / 10.0f;

            Inits();
        }

        private void Inits()
        {
            visibility = true;
            lineWidth = DEFAULT_SIZE;
            pointSize = DEFAULT_SIZE;
            polygonMode = PolygonMode.Fill;
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(pointSize);
                GL.LineWidth(lineWidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polygonMode);

                GL.Begin(PrimitiveType.Triangles);
                if (alpha == true)
                {
                    a = localRandom.RandomPozitiveInt(11) / 10.0f;
                    b = localRandom.RandomPozitiveInt(11) / 10.0f;
                    c = localRandom.RandomPozitiveInt(11) / 10.0f;
                    d = localRandom.RandomPozitiveInt(11) / 10.0f;
                    alpha = false;
                }
                GL.Color4(a, b, c, d);

                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);

                GL.End();
            }
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleLineWidth()
        {
            if (lineWidth == DEFAULT_SIZE)
                lineWidth = MAX_SIZE;
            else
                lineWidth = DEFAULT_SIZE;
        }

        public void TogglePointSize()
        {
            if (pointSize == DEFAULT_SIZE)
                pointSize = MAX_SIZE;
            else
                pointSize = DEFAULT_SIZE;
        }

        public void TogglePolygonMode()
        {
            if (polygonMode == PolygonMode.Fill)
                polygonMode = PolygonMode.Line;
            else if (polygonMode == PolygonMode.Line)
                polygonMode = PolygonMode.Point;
            else
                polygonMode = PolygonMode.Fill;
        }

        public void ToggleColor()
        {
            if (alpha == true)
                alpha = false;
            else
                alpha = true;
        }

        public void MorphTotaly()
        {
            int selectpoint = localRandom.RandomPozitiveInt(3);
            Vector3 randomPoint = localRandom.RandomPoint();

            if (selectpoint == 0)
                pointA = randomPoint;
            else if (selectpoint == 1)
                pointB = randomPoint;
            else
                pointC = randomPoint;
        }

        public void MorphPartially()
        {
            Vector3 randomPoint = localRandom.RandomPoint(10);
            pointB = randomPoint;
        }

        public void DiscoMode(Randomizer r)
        {
            color = r.RandomColor();
        }
    }
}
