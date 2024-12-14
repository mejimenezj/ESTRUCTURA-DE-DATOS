
namespace CalcularAreaFig{
    
    // Clase del Círculo
    public class Circulo
    {
        
        /// <summary>
        /// Encapsular dato primitivo del círculo
        /// </summary>
        private double radio;

        /// <summary>
        /// Constructor para inicializar el radio
        /// </summary>
        /// <param name="radio">Medida del radio del círculo</param>
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        /// <summary>
        /// Método para calcular el área del círculo
        /// </summary>
        /// <returns>Retorna un valor double</returns>
        public double CalcularArea()
        {
            // Fórmula: Área = π * radio^2
            return Math.PI * radio * radio;
        }

        /// <summary>
        /// Método para calcular el perímetro del círculo
        /// </summary>
        /// <returns>Retorna un valor double</returns>
        public double CalcularPerimetro()
        {
            // Fórmula: Perímetro = 2 * π * radio
            return 2 * Math.PI * radio;
        }
    }

    // Clase del Pentágono Regular
    public class Pentagono
    {
        /// <summary>
        /// Encapsular dato primitivo del pentágono 
        /// </summary>
        private double lado;

        /// <summary>
        /// Constructor para inicializar la longitud del lado
        /// </summary>
        /// <param name="lado">Medida del lado del pentágono regular</param>
        public Pentagono(double lado)
        {
            this.lado = lado;
        }

        /// <summary>
        /// Método para calcular el área del pentágono
        /// </summary>
        /// <returns>Retorna un valor double</returns>
        public double CalcularArea()
        {
            // Área = (Perímetro * Apotema) / 2
            // Apotema = lado / (2 * Math.Tan(Math.PI / 5))
            double apotema = lado / (2 * Math.Tan(Math.PI / 5));
            double perimetro = CalcularPerimetro();
            return (perimetro * apotema) / 2;
        }

        /// <summary>
        /// Método para calcular el perímetro del pentágono
        /// </summary>
        /// <returns>Retorna un valor double</returns>
        public double CalcularPerimetro()
        {
            // Fórmula: Perímetro = 5 * lado
            return 5 * lado;
        }
    }

    /// <summary>
    /// Clase principal para probar las figuras geométricas
    /// </summary>
    class Program
    {
        /// <summary>
        /// Comprobar si los métodos para obtener el área del círculo y pentágono son correctos
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Universidad Estatal Amazónica");
            // Crear un círculo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Círculo:");
            Console.WriteLine($"Área: {miCirculo.CalcularArea()}");
            Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro()}");

            // Crear un pentágono con lado 4
            Pentagono miPentagono = new Pentagono(4);
            Console.WriteLine("\nPentágono:");
            Console.WriteLine($"Área: {miPentagono.CalcularArea()}");
            Console.WriteLine($"Perímetro: {miPentagono.CalcularPerimetro()}");
        }
    }
}