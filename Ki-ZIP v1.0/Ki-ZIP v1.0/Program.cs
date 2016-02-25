using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ki_ZIP_v1._0
{
    class Program
    {
        private Encoder _encoder;

        static void Main(string[] args)
        {
            Program pp = new Program();
            pp.iniciar();
        }

        public void iniciar()
        {
            _encoder = new Encoder();
            _encoder.iniciarVariables();

            bool noSalir = true;
            while (noSalir)
            {
                String mensaje = Console.ReadLine();
                switch (mensaje)
                {
                    case "iniciar":
                        _encoder.arrancar();
                        _encoder.estado();
                        break;

                    case "estado":
                        _encoder.estado();
                        break;

                    case "salir":
                        _encoder.salir();
                        try
                        {
                            Thread.Sleep(3000);
                        }
                        catch (Exception e)
                        {
                        }
                        noSalir = false;
                        break;

                    default:
                        Console.WriteLine("Comando no reconocido");
                        break;
                }
            }
        }

        public Program()
        {

        }
    }
}
