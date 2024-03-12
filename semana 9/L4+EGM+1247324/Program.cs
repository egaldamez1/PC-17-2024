namespace semana9_LuisAguilar 
//Edson Galdamez Marcos
//1247324
//Fibonacci
{
    class semana7
 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine ("Ingrese su numero");
            int n = int.Parse(Console.ReadLine());
            int A=0, B=1, C=0, i=2, resultado=0;
            if (n > 0)
            Console.WriteLine (A);
            if (n>1)
            Console.WriteLine (B);
            while (i < n){
            C=A + B;
            resultado+=C;
            A=B;
            B=C;
            i=i+1;
            Console.WriteLine (B);
            if (i > n)
            break;
            }

        }
    }
 
}