using System;

namespace ConsoleApp1.functions
{
    public static class ReconhecedorPodeNaoTerminar
    {
        private static readonly string alfabeto = "ab";

        public static void Reconhecer()
        {
            Utils.Escrever("=== Reconhecedor que pode não terminar ===");
            Utils.Escrever("L_ab (cadeias com 'ab')");
            Utils.Escrever("Digite uma cadeia: ", false);

            string cadeia = Utils.Ler();
            if (string.IsNullOrEmpty(cadeia))
            {
                Utils.Escrever("NAO");
            }
            else if (!ValidarAlfabeto(cadeia))
            {
                Utils.Escrever("Cadeia inválida para o alfabeto {a,b}");
            }
            else
            {
                Utils.Escrever("Informe o limite de passos: ", false);
                int limite = LerNumeroPositivo();
                string resultado = ReconhecerLComAB(cadeia, limite);
                Utils.Escrever(resultado, true);

                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
            }

        }
        
        private static string ReconhecerLComAB(string cadeia, int limite)
        {
            int passos = 0;
            int i = 0;

            while (true)
            {

                passos++;

                if (i < cadeia.Length - 1)
                {
                    if (cadeia[i] == 'a' && cadeia[i + 1] == 'b')
                    {
                        return $"ACEITA (substring 'ab' encontrada em {passos} passos)";
                    }
                    i++;
                }
                else
                {
                    i = 0;
                }

                if (passos >= limite)
                {
                    return "Limite de passos atingido, execução interrompida!)";
                }
            }
        }

        // Valida se cadeia pertence ao alfabeto antes do reconhecimento
        private static bool ValidarAlfabeto(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                Utils.Escrever("Cadeia vazia nao eh valida.");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
                return false;
            }

            foreach (char simbolo in cadeia)
            {
                if (!alfabeto.Contains(simbolo))
                {
                    Utils.Escrever($"Simbolo '{simbolo}' nao pertence ao alfabeto {{a,b}}.");
                    Utils.Escrever("Pressione qualquer tecla para continuar...");
                    Utils.Ler();
                    Utils.Limpar();
                    return false;
                }
            }
            return true;
        }
        private static int LerNumeroPositivo()
        {
            while (true)
            {
                string? texto = Console.ReadLine();
                if (int.TryParse(texto, out int valor) && valor > 0)
                {
                    return valor;
                }
                Console.WriteLine("Digite um número positivo: ");
            }
        }
    }
}