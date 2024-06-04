using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.

            var opciones = new DbContextOptionsBuilder<BDContext>();
            opciones.UseSqlServer("Data Source=DESKTOP-76AVVCN\\" +
                "SQLEXPRESS;Initial Catalog=SimpleIMDB;" +
                "Integrated Security=True;Trust Server Certificate=True");
            var contexto = new BDContext(opciones.Options);

            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor

            var resultado = contexto.Actores.ToList();
            resultado.ForEach(actor => Console.WriteLine(actor.ToString()));

            #endregion
            Console.WriteLine("================================================================\n");
            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor

            resultado = contexto.Actores.Where(actor => actor.genero == 'F').ToList();
            resultado.ForEach(actor => Console.WriteLine(actor.ToString()));

            #endregion
            Console.WriteLine("================================================================\n");
            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor

            resultado = contexto.Actores.Where(actor => actor.edad > 50).ToList();
            resultado.ForEach(actor => Console.WriteLine(actor.ToString()));

            #endregion
            Console.WriteLine("================================================================\n");
            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"

            resultado = contexto.Actores.Where(
                actor => actor.nombre.Equals("Julia") && actor.apellido.Equals("Roberts")
            ).ToList();
            resultado.ForEach(actor => Console.WriteLine("La edad de "+actor.nombre+" "+actor.apellido+" es: "+actor.edad));

            #endregion
            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.

            contexto.Actores.Add(new Actor("Ricardo", "Darin", "Ricardo Darin", 67, "argentino", 'M'));
            contexto.SaveChanges();
            #endregion
            Console.WriteLine("================================================================\n");
            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.

            resultado = contexto.Actores.Where(actor => !actor.nacionalidad.Contains("USA")).ToList();
            resultado.ForEach(actor => Console.WriteLine(actor.ToString()));

            #endregion
            Console.WriteLine("================================================================\n");
            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.

            resultado = contexto.Actores.Where(actor => actor.genero.Equals('M')).ToList();
            resultado.ForEach(actor => Console.WriteLine("nombre: "+actor.nombre+", apellido: "+actor.apellido));
            #endregion
        }
    }
}