using System;

namespace ConsoleApp1.functions
{
    public static class ReconhecedorLinguagens
    {
        private static readonly string alfabeto = "ab";

        public static void Reconhecer()
        {
            while (true)
            {
                Utils.Escrever("=== Reconhecedor de Linguagens ===");
                Utils.Escrever("1. L_par_a (numero par de 'a's)");
                Utils.Escrever("2. L = ab* (inicia com 'a' seguido de zero ou mais 'b's)");
                Utils.Escrever("3. Voltar");
                Utils.Escrever("Escolha uma opcao: ", false);
                string opcao = Utils.Ler();

                switch (opcao)
                {
                    case "1":
                        Utils.Limpar();
                        ReconhecerLParA();
                        break;
                    case "2":
                        Utils.Limpar();
                        ReconhecerABEstrela();
                        break;
                    case "3":
                        Utils.Limpar();
                        return;
                    default:
                        Utils.Escrever("Opcao invalida!");
                        break;
                }
            }
        }

        // Reconhece L_par_a (número par de 'a's)
        private static void ReconhecerLParA()
        {
            Utils.Escrever("Digite uma cadeia: ", false);
            string cadeia = Utils.Ler();

            if (!ValidarAlfabeto(cadeia))
                return;

            int contadorA = 0;
            foreach (char c in cadeia)
            {
                if (c == 'a') contadorA++;
            }
            
            string resultado = (contadorA % 2 == 0) ? "ACEITA" : "REJEITA";
            Utils.Escrever(resultado);
            
            Utils.Escrever("Pressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
        }

        // Reconhece L = ab* (inicia com 'a' seguido de zero ou mais 'b's)
        private static void ReconhecerABEstrela()
        {
            Utils.Escrever("Digite uma cadeia: ", false);
            string cadeia = Utils.Ler();

            if (!ValidarAlfabeto(cadeia))
                return;

            bool aceita = false;
            if (cadeia.Length > 0 && cadeia[0] == 'a')
            {
                aceita = true;
                for (int i = 1; i < cadeia.Length; i++)
                {
                    if (cadeia[i] != 'b')
                    {
                        aceita = false;
                        break;
                    }
                }
            }
            
            string resultado = aceita ? "ACEITA" : "REJEITA";
            Utils.Escrever(resultado);
            
            Utils.Escrever("Pressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
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
    }
}