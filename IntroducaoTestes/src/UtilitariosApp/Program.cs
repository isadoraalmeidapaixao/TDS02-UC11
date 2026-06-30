using UtilitariosApp;

/*
Calculadora c1 = new Calculadora();

var resultado = c1.Somar(14, 17);
var resultado2 = c1.Multiplicar(14, 17);


Console.WriteLine($"O resultado da soma é: {resultado}");
Console.WriteLine($"O resultado da multiplicação é: {resultado2}");
*/

// == Testes com Clientes e Endereço ==
var gerenciador = new GerenciadorClientes();

var endereco1 = new Endereco("Rua B", 123, "São Paulo", "SP");
var endereco2 = new Endereco("Travessa X", 44, "São Paulo", "SP");

var cliente1 = new Cliente(1, "Silva", "jsilva@mail.com", endereco1);
var cliente2 = new Cliente(1, "Marcio", "jsilva@mail.com", endereco2);
var cliente3 = new Cliente(1, "Luana", "jsilva@mail.com", endereco2);

//Console.WriteLine(cliente1.ObterInformacoes());
gerenciador.AdicionarCliente(cliente1);
gerenciador.AdicionarCliente(cliente2);
gerenciador.AdicionarCliente(cliente3);

gerenciador.RemoverPorId(1);

Console.WriteLine($"Total de Clientes: {gerenciador.ContarClientes()}");
Console.WriteLine($"Procurando Id 2: {gerenciador.ProcurarPorId(3)?.Nome}");
Console.WriteLine();
Console.WriteLine(cliente1.ObterInformacoes());
Console.WriteLine(gerenciador.ProcurarPorId(1)?.ObterInformacoes());