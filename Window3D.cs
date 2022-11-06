using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace Crainiciuc_Filaret_Niculai
{
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private Randomizer random;
        private Triangle3D triangle;
        private Axes axes;

        //DEFAULTS
        Color DEFAULT_BACKGR_COLOR = Color.BurlyWood;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            random = new Randomizer();
            axes = new Axes();
            triangle = new Triangle3D(random);

            DisplayHelp();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.ClearColor(DEFAULT_BACKGR_COLOR);

            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 eye = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if(currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BACKGR_COLOR);
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(random.RandomColor());   
            }

            if (currentKeyboard[Key.L] && !previousKeyboard[Key.L])
            {
                triangle.DiscoMode(random);
            }

            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                triangle.ToggleVisibility();
            }

            if (currentKeyboard[Key.G] && !previousKeyboard[Key.G])
            {
                triangle.ToggleLineWidth();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                triangle.TogglePointSize();
            }

            if (currentKeyboard[Key.M] && !previousKeyboard[Key.M])
            {
                triangle.MorphTotaly();
            }

            if (currentKeyboard[Key.N] && !previousKeyboard[Key.N])
            {
                triangle.MorphPartially();
            }
            if (currentKeyboard[Key.K] && !previousKeyboard[Key.K])
            {
                triangle.TogglePolygonMode();
            }

            if (currentKeyboard[Key.J] && !previousKeyboard[Key.J])
            {
                triangle.ToggleColor();
            }

            previousKeyboard = currentKeyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            axes.Draw();
            triangle.Draw();

            SwapBuffers();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n           MENIU");
            Console.WriteLine(" ESC - Parasire aplicatie");
            Console.WriteLine(" R - Resetare scena");
            Console.WriteLine(" B - Schimbare culoare background");
            Console.WriteLine(" V - Schimbare vizibilitate");
            Console.WriteLine(" G - Schimbare grosime linie");
            Console.WriteLine(" H - Schimbare dimensiune punct");
            Console.WriteLine(" M - Morph total");
            Console.WriteLine(" N - Morph partial");
            Console.WriteLine(" K - Schimbare mod polygon");
            Console.WriteLine(" J - Schimbare culoare fiecare canal");
            Console.WriteLine(" L - DISCO MODE");
        }

        public void CitireFisier()
        {
            string numeFisier;
            int nrPlayeri;
            numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
        }
    }
}
/*string numeFisier;
            int nrPlayeri;
            numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminPlayer = new AdministrarePlayer_FisierText(caleCompletaFisier);

  Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();

using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPlayeri = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                   player[nrPlayeri++] = new Players(linieFisier);
                }
            }
 
 */
