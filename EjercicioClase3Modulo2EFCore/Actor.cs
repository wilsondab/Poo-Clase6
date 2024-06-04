using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EjercicioClase3Modulo2EFCore
{
    [Table("actor")]
    internal class Actor
    {
        public int id {  get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        [Column("nombre_artistico")]
        public string nombreArtistico { get; set; }

        public int edad { get; set; }

        public string nacionalidad { get; set; }

        public char genero { get; set; }

        public Actor(string nombre, string apellido, string nombreArtistico, int edad, string nacionalidad, char genero)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreArtistico = nombreArtistico;
            this.edad = edad;
            this.nacionalidad = nacionalidad;
            this.genero = genero;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine("Actor: { ");
            toString.Append("id: " + this.id);
            toString.Append(", nombre: " + this.nombre);
            toString.Append(", apellido: " + this.apellido);
            toString.AppendLine(", nombreArtistico: " + this.nombreArtistico);
            toString.Append("edad: " + this.edad);
            toString.Append(", nacionalidad: " + this.nacionalidad);
            toString.AppendLine(", genero: " + this.genero);
            toString.AppendLine("}");

            return toString.ToString();
        }
    }
}
