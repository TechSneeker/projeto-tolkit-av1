using ConsoleApp1.functions;

bool emExecucao = true;

while (emExecucao)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Verificador: símbolo e cadeia (Sigma = {a,b})");
    Console.WriteLine("2. Classificador: T.I.N");
    Console.WriteLine("3. Decisor: termina com 'b'?");
    Console.WriteLine("4. Avaliador proposicional: básico");
    Console.WriteLine("5. Reconhecedor: L_par_a e ab*");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine() ?? string.Empty;
    switch (opcao)
    {
        case "1":
            Utils.Limpar();
            VerificadorAlfabeto.ValidarSimbolo();
            VerificadorAlfabeto.ValidarCadeia();
            break;
        case "2":
            Utils.Limpar();
            ClassificadorTIN.IniciarQuestionario();
            break;
        case "3":
            Utils.Limpar();
            DecisorTerminaComB.TerminaComB();
            break;
        case "4":
            Utils.Limpar();
            AvaliadorProposicional.Avaliar();
            break;
        case "5":
            Utils.Limpar();
            ReconhecedorLinguagens.Reconhecer();
            break;
        case "6":
            emExecucao = false;
            break;
    }
}