using System;
using System.Collections.Generic;

namespace ConsoleApp1.functions
{
    // AV2 Item 4 - Detector ingênuo de loop + reflexão
    public static class DetectorLoop
    {
        // Executa detector de loop com processo discreto passo a passo
        public static void Detectar()
        {
            Utils.Escrever("=== Detector Ingênuo de Loop ===");
            Utils.Escrever("Processo discreto: contador com operações aritméticas");
            
            Utils.Escrever("Digite o limite de passos: ", false);
            int limite = LerNumeroPositivo();
            
            Utils.Escrever("Digite o valor inicial: ", false);
            int valorInicial = LerNumeroPositivo();
            
            ExecutarDeteccao(valorInicial, limite);
            
            Utils.Escrever("\n=== REFLEXÃO ===");
            Utils.Escrever("FALSOS POSITIVOS: Detector pode sinalizar loop quando processo");
            Utils.Escrever("apenas revisita estado temporariamente sem entrar em ciclo infinito.");
            Utils.Escrever("FALSOS NEGATIVOS: Pode não detectar loops que ocorrem após");
            Utils.Escrever("o limite de passos ou com estados muito complexos.");
            
            Utils.Escrever("\nPressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
        }
        
        // Executa processo discreto lembrando estados visitados
        private static void ExecutarDeteccao(int valorInicial, int limite)
        {
            HashSet<int> estadosVisitados = new HashSet<int>();
            int estadoAtual = valorInicial;
            int passo = 0;
            
            Utils.Escrever($"\nIniciando com valor: {estadoAtual}");
            
            while (passo < limite)
            {
                passo++;
                
                if (estadosVisitados.Contains(estadoAtual))
                {
                    Utils.Escrever($"LOOP DETECTADO no passo {passo}!");
                    Utils.Escrever($"Valor repetido: {estadoAtual}");
                    return;
                }
                
                estadosVisitados.Add(estadoAtual);
                Utils.Escrever($"Passo {passo}: {estadoAtual}");
                
                estadoAtual = ProximoEstado(estadoAtual, passo);
            }
            
            Utils.Escrever($"Limite de {limite} passos atingido. Nenhum loop detectado.");
        }
        
        // Calcula próximo estado do processo discreto
        private static int ProximoEstado(int valor, int passo)
        {
            return (passo % 3) switch
            {
                1 => (valor * 2) % 10,
                2 => (valor + 3) % 8,
                0 => (valor - 1 + 10) % 10,
                _ => valor
            };
        }
        
        private static int LerNumeroPositivo()
        {
            while (true)
            {
                string entrada = Utils.Ler();
                if (int.TryParse(entrada, out int valor) && valor > 0)
                    return valor;
                Utils.Escrever("Digite um número positivo: ", false);
            }
        }
    }
}