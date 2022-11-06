using OpenTK;
using System;
using System.Drawing;

namespace Crainiciuc_Filaret_Niculai
{
    class Randomizer
    {
        private Random r;
        private const int LOW_INT_VAL = -25;
        private const int HIGH_INT_VAL = 25;

        public Randomizer()
        {
            r = new Random();
        }

        public Color RandomColor()
        {
            int genR = r.Next(0, 256);
            int genG = r.Next(0, 256);
            int genB = r.Next(0, 256);

            Color color = Color.FromArgb(genR, genG, genB);
            
            return color;
        }

        public Vector3 RandomPoint()
        {
            int a = r.Next(LOW_INT_VAL, HIGH_INT_VAL);
            int b = r.Next(LOW_INT_VAL, HIGH_INT_VAL);
            int c = r.Next(LOW_INT_VAL, HIGH_INT_VAL);

            Vector3 vector = new Vector3(a, b, c);

            return vector;
        }

        public Vector3 RandomPoint(int special)
        {
            int a = r.Next(-1 * special, special);
            int b = r.Next(-1 * special, special);
            int c = r.Next(-1 * special, special);

            Vector3 vector = new Vector3(a, b, c);

            return vector;
        }
        public int RandomPozitiveInt(int upperLimit)
        {
            return r.Next(0, upperLimit);
        }
    }
}
