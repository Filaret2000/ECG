using System;

namespace Crainiciuc_Filaret_Niculai
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D fereastra = new Window3D())
            {
                fereastra.Run(60.0, 0.0);
            }
        }
    }
}
