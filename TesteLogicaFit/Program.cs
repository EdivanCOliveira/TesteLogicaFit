using System;
using System.Text;

namespace TesteLogicaFit
{
    class Program
    {

        static void Main(string[] args)
        {
           
            //Teste para número primo
            RetornoPrimo retornoPrimo = ValidaNumeroPrimo(21);
            Console.WriteLine($"O número {retornoPrimo.NroValidado} é primo? {retornoPrimo.EPrimo}");
            Console.WriteLine($"Número de interações necessárias para validação: {retornoPrimo.NroInteracoes} ");

            //Validação de palindromo
            bool resultado = EPalavraPalindromo("edivan");
            Console.WriteLine($"A palavra em questão é palindromo?  {resultado} ");

            //Validação de coordenadas para o exercício do bot
            bool resultado2 = ValidaCoordenadas(1, 1, 4, 4);
            Console.WriteLine($"É possível o bot atingir essas coordenadas?  {resultado} ");

        }


        private static RetornoPrimo ValidaNumeroPrimo(int nroEntrada)
        {
            //Existiam outras regras que eu poderia ter usados para diminuir o número de interações, porém usei apenas o que estava disponível no descritivo da questão
            //divisão por 1 e por ele mesmo.

            RetornoPrimo retorno = new RetornoPrimo();
            int contador = 1;
            int resto = 0;
            retorno.NroValidado = nroEntrada;

            while (retorno.EPrimo == null)
            {
                //Verifica o resto da divisão
                resto = nroEntrada % contador;

                if (resto == 0 && (nroEntrada == contador))
                {
                    retorno.EPrimo = true;
                    retorno.NroInteracoes = contador;
                    return retorno;
                }
                else if (resto == 0 && (contador > 1))
                {
                    retorno.EPrimo = false;
                    retorno.NroInteracoes = contador;
                    return retorno;
                }
                else
                {
                    contador++;
                }
            }

            return retorno;


        }

        private static bool EPalavraPalindromo(string palavraEntrada)
        {
            //Replace(" ","") => Retirei os espaços da frase de entrada antes de iniciar o processo
            //ToLower() => Padronizei todas as letras para minúsculo
            char[] entrada = palavraEntrada.Replace(" ", "").ToLower().ToCharArray();
            char[] saida = new char[entrada.Length];

            //Criando um array invertido
            for (int i = 0; i < entrada.Length; i++)
            {
                saida[entrada.Length - i - 1] = entrada[i];
            }

            //Comparando os arrays para validar Palindromo
            for (int i = 0; i < entrada.Length; i++)
            {
                if (saida[i] != entrada[i])
                {
                    return false;
                }
            }

            return true;

        }


        private static bool ValidaCoordenadas(int x_inicial, int y_inicial, int x_final, int y_final)
        {
            //Movimento para cima
            //(x, x+y)

            //Movimento para direita
            //(x+y, y)

            int x = x_inicial;
            int y = y_inicial;

            //Validando dados de entrada
            if (x_inicial > x_final || y_inicial > y_final)
            {
                //O bot não volta casas e a coordenada final é menor que a inicial
                return false;

            }

            if (x_inicial == x_final && y_inicial == y_final)
            {
                //Se as coordenadas de entrada forem iguais returne verdadeiro
                return true;
            }

            //Parte 1 => movimentando bot para cima
            while (y < y_final)
            {
                y = x + y;
            }

            //Parte 2 => movimentando bot para direita
            while (x < x_final)
            {
                x = x + y;
            }


            if (x != x_final || y != y_final)
            {
                 x = x_inicial;
                 y = y_inicial;

                //Parte 2 => movimentando bot para direita
                while (x < x_final)
                {
                    x = x + y;
                }
                //Parte 1 => movimentando bot para cima
                while (y < y_final)
                {
                    y = x + y;
                }

            }


            //Validando o resultado final
            if (x == x_final && y == y_final)
            {
                return true;
            }

            return false;

        }



        //Classe usada para retorno da validação do número primo.
        private class RetornoPrimo
        {
            public bool? EPrimo { get; set; }
            public int NroInteracoes { get; set; }

            public int NroValidado { get; set; }

        }

    }

}
