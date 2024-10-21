using System;

namespace Prime
{
    internal class Ventana
    {
        public int Ancho { get; set; }
        public int Alto { get; set; }

        public Ventana(int ancho, int alto)
        {
            Ancho = ancho;
            Alto = alto;
            InitVentana();
        }

        private void InitVentana() 
        {
            Console.SetWindowSize(Ancho, Alto);
            Console.Title = "Prime";
        }
    }
}