using System;

namespace ConsoleApp1.functions
{
    // Item 1 - Verificador de alfabeto e cadeia em Σ={a,b}
    public static class VerificadorAlfabeto
    {
        private static readonly string alfabeto = "ab";

        // Valida se um símbolo pertence ao alfabeto {a,b}
        public static void ValidarSimbolo()
        {
            Utils.Escrever("Digite um símbolo: ", false);
            string simbolo = Utils.Ler();
            
            if (string.IsNullOrEmpty(simbolo) || simbolo.Length != 1)
            {
                Utils.Escrever("Entrada inválida. Digite apenas um símbolo.");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                return;
            }
            
            bool pertence = alfabeto.Contains(simbolo);
            string resultado = pertence ? "válido" : "inválido";
            Utils.Escrever($"Símbolo '{simbolo}': {resultado}");
        }

        // Valida se uma cadeia pertence a Σ*
        public static void ValidarCadeia()
        {
            Utils.Escrever("Digite uma cadeia: ", false);
            string cadeia = Utils.Ler();
            
            if (string.IsNullOrEmpty(cadeia))
            {
                Utils.Escrever("Cadeia vazia: válida");
            }
            else
            {
                bool cadeiaValida = true;
                foreach (char simbolo in cadeia)
                {
                    if (!alfabeto.Contains(simbolo))
                    {
                        cadeiaValida = false;
                        break;
                    }
                }
                string resultado = cadeiaValida ? "válida" : "inválida";
                Utils.Escrever($"Cadeia '{cadeia}': {resultado}");
            }
            
            Utils.Escrever("Pressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
        }
    }
}