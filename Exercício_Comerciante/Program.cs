using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Exercício_Comerciante
{
    // Um comerciante deseja fazer o levantamento do lucro que ele comercializa.  
    // Para isto, mandou digitar um conjunto de N mercadorias, cada uma contendo nome, preço de compra e preço de venda das mesmas.
    // Fazer um programa que leia tais dados e determine e escreva quantas mercadorias proporcionaram:

    // Lucro < 10 %
    // 10 % <= lucro <= 20 %
    // lucro > 20 %

    // Determine e escreva também o valor total de compra e de venda de toda as mercadorias, assim como o lucro total.

    public class produto
    {
        public string nome { get; set; }
        public double precoCompra;
        public double precoVenda;

        public double lucro(double precoCompra, double precoVenda)
        {
            return precoVenda / precoCompra;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int i, reserva, lucroAcima = 0, lucroAbaixo = 0, lucroMedia = 0;
            double lucroTotal = 0, precototalVendas = 0, precototalCompras = 0;
            char respostaUser, respostaUser2;

            var produto = new produto();
            List<produto> produtos = new List<produto>();

            do
            {
                // Menu de interação com o usuário
                Console.WriteLine("Deseja fazer o relatório? S/N:");
                respostaUser = Convert.ToChar(Console.ReadLine());

                if (respostaUser != 'S' && respostaUser != 's' && respostaUser != 'n' && respostaUser != 'N')
                {
                    Console.WriteLine("\n\nResposta inválida, tente novamente.");
                    Console.Clear();
                }
                if (respostaUser == 'S' || respostaUser == 's')
                {
                    Console.Clear();
                    Console.WriteLine("Qual a quantidade de mercadorias a serem adicionadas?");
                    i = Convert.ToInt32(Console.ReadLine());
                    reserva = i;
                    
                    // Cadastro de Produtos
                    for (i = 0; i < reserva; i++)
                    {
                        produto Produto = new produto();
                        produtos.Add(Produto);
                        Console.WriteLine($"Digite o nome do {i + 1}º produto: ");
                        produtos[i].nome = Console.ReadLine();
                        Console.WriteLine($"Digite o preço de compra do {produtos[i].nome}: ");
                        produtos[i].precoCompra = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Digite o preço de venda do {produtos[i].nome}: ");
                        produtos[i].precoVenda = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();
                    }
                    Console.Clear();
                    Console.WriteLine("Deseja listar as mercadorias? S/N");
                     respostaUser2 = Convert.ToChar(Console.ReadLine());

                    //Listagem de produtos
                    if (respostaUser2 == 's' || respostaUser2 == 'S')
                    {
                        for (i = 0; i < reserva; i++)
                        {
                            Console.WriteLine($"Nome do produto:{produtos[i].nome} \nPreço de compra:{produtos[i].precoCompra} \nPreço de venda:{produtos[i].precoVenda}\n\n");
                            
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();

                    //Cálculo de Lucros acima, abaixo e medianos.
                    for (i = 0; i < reserva; i++)
                    {
                        precototalCompras = precototalCompras + produtos[i].precoCompra;
                        precototalVendas = precototalVendas + produtos[i].precoVenda;
                        lucroTotal = precototalVendas - precototalCompras;

                        if (produto.lucro(produtos[i].precoCompra, produtos[i].precoVenda) > 1.2)
                        {
                            lucroAcima++;
                        }
                        if (produto.lucro(produtos[i].precoCompra, produtos[i].precoVenda) < 1.2 && produto.lucro(produtos[i].precoCompra, produtos[i].precoVenda) >= 1.1)
                        {
                            lucroMedia++;
                        }
                        if (produto.lucro(produtos[i].precoCompra, produtos[i].precoVenda) < 1.1)
                        {
                            lucroAbaixo++;
                        }
                    }
                    
                    Console.WriteLine("Relatório:\n\n");
                    Console.WriteLine($"Lucro abaixo de 10%: {lucroAbaixo}\nLucro entre 10% e 20%: {lucroMedia}\nLucro acima de 20%: {lucroAcima}" +
                        $"\nValor total de compra: {precototalCompras}\nValor total de venda: {precototalVendas}\nLucro total: {lucroTotal}");
                }
            } while (respostaUser != 'n' && respostaUser != 'N');

            
            }
        }
    }





