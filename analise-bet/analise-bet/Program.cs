//Analise Bet
string mensagemDeBoasVindas = "Bem vindo ao Análise Bet";
//List<string> listaDeJogadores = new List<string>{"Ronaldinho Gaucho", "Diego Maradona", "Neymar Jr"};  
Dictionary<string, List<int>> jogadoresRegistrados = new Dictionary<string, List<int>>();
jogadoresRegistrados.Add("Ronaldinho Gaucho", new List<int> { 10, 8, 7 });
jogadoresRegistrados.Add("Diego Maradona", new List<int>());
jogadoresRegistrados.Add("Neymar Jr", new List<int>{9, 7, 8});
void ExibirLogo()
{
    Console.WriteLine(@"
░█████╗░███╗░░██╗░█████╗░██╗░░░░░██╗░██████╗███████╗  ██████╗░███████╗████████╗
██╔══██╗████╗░██║██╔══██╗██║░░░░░██║██╔════╝██╔════╝  ██╔══██╗██╔════╝╚══██╔══╝
███████║██╔██╗██║███████║██║░░░░░██║╚█████╗░█████╗░░  ██████╦╝█████╗░░░░░██║░░░
██╔══██║██║╚████║██╔══██║██║░░░░░██║░╚═══██╗██╔══╝░░  ██╔══██╗██╔══╝░░░░░██║░░░
██║░░██║██║░╚███║██║░░██║███████╗██║██████╔╝███████╗  ██████╦╝███████╗░░░██║░░░
╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚══════╝╚═╝╚═════╝░╚══════╝  ╚═════╝░╚══════╝░░░╚═╝░░░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\n1 - Registrar um jogador");
    Console.WriteLine("2 - Exibir jogadores");
    Console.WriteLine("3 - Avaliar jogador");
    Console.WriteLine("4 - Exibir média de avaliações do jogador");
    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 0: Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}");
            break;
        case 1: RegistrarJogador();
            break;
        case 2: ExibirJogadores();
            break;
        case 3: AvaliarJogador();
            break;
        case 4: CalcularMediaDoJogador();
            break;
        default: Console.WriteLine("Opção Inválida");
            break;
    }
}

void RegistrarJogador()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Jogadores");
    Console.Write("\nDigite o nome do jogador: ");
    string nomeDoJogador = Console.ReadLine()!;
    jogadoresRegistrados.Add(nomeDoJogador, new List<int>());
    Console.WriteLine($"O jogador {nomeDoJogador} foi registrado com sucesso");
    Thread.Sleep(2000);
    Console.Clear() ;
    ExibirOpcoesDoMenu();
}

void ExibirJogadores()
{
    Console.Clear();
    ExibirTituloDaOpcao("Jogadores Registrados");
    //for (int i = 0; i <  listaDeJogadores.Count; i++)
    //{
    //    Console.WriteLine(listaDeJogadores[i]);
    //}

    foreach (string jogador in jogadoresRegistrados.Keys)
    {
        Console.WriteLine($"Jogador: {jogador}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadRight(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarJogador()
{
    //digite qual jogador deseja avaliar
    //se o jogador existir no dicionario>atribuir nota
    //se não volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Jogador");
    Console.Write("Digite o nome do jogador que deseja avaliar: ");
    string nomeDoJogador = Console.ReadLine()!;

    if (jogadoresRegistrados.ContainsKey(nomeDoJogador))
    {
        Console.Write($"\nDigite uma nota para o jogador {nomeDoJogador}: ");
        int nota = int.Parse(Console.ReadLine()!);
        jogadoresRegistrados[nomeDoJogador].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o jogador {nomeDoJogador}. ");
        Thread.Sleep(5000);
        Console.Clear() ;
        ExibirOpcoesDoMenu();
    }else
    {
        Console.WriteLine($"\nO Jogador {nomeDoJogador} não foi encontrado");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void CalcularMediaDoJogador()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média do Jogador");
    Console.Write("Digite o nome do jogador que deseja obter a média: ");
    string nomeDoJogador = Console.ReadLine()!;

    if (jogadoresRegistrados.ContainsKey(nomeDoJogador))
    {
        List<int> notasDoJogador = jogadoresRegistrados[nomeDoJogador];
        Console.WriteLine($"A média de notas do jogador {nomeDoJogador} é {notasDoJogador.Average()}");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Jogador não encontrado.");
        Console.WriteLine("Digite qualquer tecla para voltar.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();