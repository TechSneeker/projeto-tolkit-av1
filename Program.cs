using ConsoleApp1.functions;
using System;

bool emExecucao = true;

while (emExecucao)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Verificador: símbolo e cadeia (Sigma = {a,b})");
    Console.WriteLine("2. Classificador: T.I.N");
    Console.WriteLine("3. Decisor: termina com 'b'?");
    Console.WriteLine("4. Avaliador proposicional: básico");
    Console.WriteLine("5. Reconhecedor: L_par_a e ab*");
    Console.WriteLine("6. Classificador: Problema × Instância");
    Console.WriteLine("7. Decisor: L_fim_b e L_mult3_b");
    Console.WriteLine("8. Reconhecedor: que pode não terminar");
    Console.WriteLine("9. Detector ingenûo: loop e reflexão ");
    Console.WriteLine("10. Simulador: AFD ");
    Console.WriteLine("0. Sair");
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
            Utils.Limpar();
            ClassificadorProblemaXInstancia.IniciarQuestionario();
            break;
        case "7":
            Utils.Limpar();
            DecisorLinguagens.Decidir();
            break;
        case "8":
            Utils.Limpar();
            ReconhecedorPodeNaoTerminar.Reconhecer();
            break;
        case "9":
            Utils.Limpar();
            DetectorLoop.Detectar();
            break;
        case "10":
            Utils.Limpar();
            SimuladorAFD.Simular();
            break;
        case "0":
            emExecucao = false;
            break;
    }
}