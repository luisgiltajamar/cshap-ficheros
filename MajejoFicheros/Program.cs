using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MajejoFicheros
{
    class Program
    {
        static void Main(string[] args)
        {

            var r1 = @"c:\datos";
            if (!Directory.Exists(r1))
                Directory.CreateDirectory(r1);

            var ruta = @"c:\datos\texto.txt";


            if (!File.Exists(ruta))
            {
                File.Create(ruta).Close();
            }

            var texto = "Hola mundo en un fichero muy bonito";

            File.AppendAllText(ruta,texto);

            Console.WriteLine(File.ReadAllText(ruta));


            var str = File.OpenRead(ruta);
            var reader = new StreamReader(str);

            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
            str.Close();

          

            var strEsc = new FileStream(ruta, FileMode.Append);


            var writer = new StreamWriter(strEsc);
            writer.Write("soy edu feliz navidad");
            
            writer.Flush();
            writer.Close();

            //var bw = new BinaryWriter(strEsc);
            //bw.Write("Pepe");
            //bw.Close();
            strEsc.Close();

            var origen=new FileInfo(@"C:\datos\1.jpg");

            var streamBinario = new FileStream(origen.FullName,FileMode.Open);

            var lector = new BinaryReader(streamBinario);

            byte[] contenido=new byte[origen.Length];

            lector.Read(contenido, 0, contenido.Length);

            lector.Close();
            streamBinario.Close();

            using (var escritor = 
                new FileStream(@"c:\datos\copiado.jpg", FileMode.Create))
            {
                using (var escritorByte=new BinaryWriter(escritor))
                {
                    escritorByte.Write(contenido);
                }

            }
            



            Console.Read();





        }
    }
}
