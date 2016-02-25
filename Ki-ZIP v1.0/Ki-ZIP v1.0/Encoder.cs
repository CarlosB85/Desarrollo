using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ki_ZIP_v1._0
{
    public class Encoder
    {

        private KinectSensor sensor;
        private byte[] colorPixels;        

        public Encoder()
        {
        }

        public void iniciarVariables()
        {

            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                Console.WriteLine("Eligiendo Sensor");
                Console.CursorTop = Console.CursorTop -= 1;
                Console.CursorLeft = 50;
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("OK");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO");
                    Console.ResetColor();
                }

                Console.WriteLine("Habilitando Flujos");

                if (this.sensor != null)
                {
                    Console.WriteLine("Flujo de Color");
                    Console.CursorTop = Console.CursorTop -= 1;
                    Console.CursorLeft = 50;
                    this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(this.sensor.ColorStream.IsEnabled ? "OK" : "NO");
                    Console.ResetColor();
                    Console.WriteLine("Flujo de Profundidad");
                    Console.CursorTop = Console.CursorTop -= 1;
                    Console.CursorLeft = 50;
                    this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(this.sensor.DepthStream.IsEnabled ? "OK" : "NO");
                    Console.ResetColor();
                    Console.WriteLine("Flujo de Skeleton");
                    Console.CursorTop = Console.CursorTop -= 1;
                    Console.CursorLeft = 50;
                    this.sensor.SkeletonStream.Enable();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(this.sensor.SkeletonStream.IsEnabled ? "OK" : "NO");
                    Console.ResetColor();
                    Console.WriteLine("Flujo de Infrarojo");
                    Console.CursorTop = Console.CursorTop -= 1;
                    Console.CursorLeft = 50;
                    this.sensor.ColorStream.Enable(ColorImageFormat.InfraredResolution640x480Fps30);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(this.sensor.ColorStream.IsEnabled ? "OK" : "NO");
                    Console.ResetColor();

                }
            }
        }

        public void estado()
        {
            Console.WriteLine("Estado Sensor");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(this.sensor.Status);
            Console.ResetColor();
            Console.WriteLine("Flujo de Color");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            escribirRespuesta(this.sensor.ColorStream.IsEnabled);
            Console.WriteLine("Flujo de Profundidad");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            escribirRespuesta(this.sensor.DepthStream.IsEnabled);
            Console.WriteLine("Flujo de Skeleton");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            escribirRespuesta(this.sensor.SkeletonStream.IsEnabled);
            Console.WriteLine("Flujo de Infrarojo");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            escribirRespuesta(this.sensor.ColorStream.IsEnabled);
            Console.WriteLine("Sensor transmitiendo");
            Console.CursorTop = Console.CursorTop -= 1;
            Console.CursorLeft = 50;
            escribirRespuesta(this.sensor.IsRunning);
        }

        public void arrancar()
        {
            if (this.sensor != null)
            {
                Console.WriteLine("Iniciando transmision");
                Console.CursorTop = Console.CursorTop -= 1;
                Console.CursorLeft = 50;
                this.sensor.Start();
                escribirRespuesta(sensor.IsRunning);
                this.colorPixels = new byte[this.sensor.ColorStream.FramePixelDataLength];
                Console.WriteLine("Adjuntando metodo de captura");                
                this.sensor.ColorFrameReady += this.SensorColorFrameReady;
                Console.CursorTop = Console.CursorTop -= 1;
                Console.CursorLeft = 50;
                escribirRespuesta(true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sensor no conectado");
                Console.ResetColor();
            }
        }

        public void salir()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deteniendo flujo");
            this.sensor.Stop();
        }

        private void escribirRespuesta(bool respuesta)
        {
            if (respuesta)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("OK");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO");
                Console.ResetColor();
            }
        }

        #region metodos eventos
        private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    // Write the pixel data into our bitmap
                    this.colorBitmap
                        //WritePixels(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),this.colorPixels, this.colorBitmap.PixelWidth * sizeof(int),0);
                }
            }
        }
        #endregion
    }
}
