using System;
using System.Collections.Generic;

namespace ConsoleApp1.functions
{
    // AV2 Item 5 - Simulador de AFD de casos fixos
    public static class SimuladorAFD
    {
        // AFD que aceita cadeias terminadas em 'b'
        private static readonly Dictionary<(int, char), int> transicoes = new Dictionary<(int, char), int>
        {
            { (0, 'a'), 0 },
            { (0, 'b'), 1 },
            { (1, 'a'), 0 },
            { (1, 'b'), 1 }
        };
        
        private static readonly HashSet<int> estadosFinais = new HashSet<int> { 1 };
        private static readonly int estadoInicial = 0;

        // Simula execução do AFD sobre entrada
        public static void Simular()
        {
            Utils.Escrever("=== Simulador de AFD ===");
            Utils.Escrever("AFD: aceita cadeias que terminam com 'b' sobre Σ={a,b}");
            Utils.Escrever("Estados: {0, 1} | Inicial: 0 | Final: {1}");
            
            Utils.Escrever("Digite uma cadeia: ", false);
            string cadeia = Utils.Ler();
            
            if (!ValidarAlfabeto(cadeia))
            {
                Utils.Escrever("Cadeia inválida para o alfabeto {a,b}");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
                return;
            }
            
            ExecutarAFD(cadeia);
            
            Utils.Escrever("Pressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
        }
        
        // Executa AFD mostrando transições passo a passo
        private static void ExecutarAFD(string cadeia)
        {
            int estadoAtual = estadoInicial;
            
            Utils.Escrever($"\nEstado inicial: {estadoAtual}");
            
            for (int i = 0; i < cadeia.Length; i++)
            {
                char simbolo = cadeia[i];
                
                if (transicoes.ContainsKey((estadoAtual, simbolo)))
                {
                    int proximoEstado = transicoes[(estadoAtual, simbolo)];
                    Utils.Escrever($"δ({estadoAtual}, '{simbolo}') = {proximoEstado}");
                    estadoAtual = proximoEstado;
                }
                else
                {
                    Utils.Escrever($"Transição indefinida para δ({estadoAtual}, '{simbolo}')");
                    Utils.Escrever("REJEITA");
                    return;
                }
            }
            
            bool aceita = estadosFinais.Contains(estadoAtual);
            string resultado = aceita ? "ACEITA" : "REJEITA";
            Utils.Escrever($"Estado final: {estadoAtual}");
            Utils.Escrever(resultado);
        }
        
        // Valida se cadeia pertence ao alfabeto {a,b}
        private static bool ValidarAlfabeto(string cadeia)
        {
            foreach (char c in cadeia)
            {
                if (c != 'a' && c != 'b')
                {
                    return false;
                }
            }
            return true;
        }
    }
}