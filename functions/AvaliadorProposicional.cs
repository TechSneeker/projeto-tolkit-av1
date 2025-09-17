using System;

namespace ConsoleApp1.functions
{

    public static class AvaliadorProposicional
    {
        // Avalia fórmulas proposicionais sobre P, Q, R
        public static void Avaliar()
        {
            Utils.Escrever("=== Avaliador Proposicional Básico ===");
            Utils.Escrever("1 - (P AND Q) OR R");
            Utils.Escrever("2 - (P -> Q) AND R");
            Utils.Escrever("Escolha uma fórmula: ", false);

            string entrada = Utils.Ler();
            if (!int.TryParse(entrada, out int opcao) || (opcao != 1 && opcao != 2))
            {
                Utils.Escrever("Opção inválida!");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
                return;
            }

            if (opcao != 1 && opcao != 2)
            {
                Utils.Escrever("Opção inválida!");
                Utils.Ler();
                return;
            }

            bool P = LerBoolean("Digite o valor de P (0 = F, 1 = V): ");
            bool Q = LerBoolean("Digite o valor de Q (0 = F, 1 = V): ");
            bool R = LerBoolean("Digite o valor de R (0 = F, 1 = V): ");

            bool resultado = opcao == 1
                ? (P && Q) || R
                : (!P || Q) && R;

            Utils.Limpar();
            Utils.Escrever($"Resultado: {resultado}");

            Utils.Escrever("Deseja exibir a tabela-verdade da fórmula escolhida? (s/n)", false);
            string resp = Utils.Ler().Trim().ToLower();

            if (resp == "s")
            {
                Utils.Limpar();
                GerarTabelaVerdade(opcao);
                Utils.Escrever("Pressione qualquer tecla para sair...");
                Utils.Ler();
            }

            Utils.Limpar();
        }

        // Lê valor booleano (0 ou 1) do usuário
        private static bool LerBoolean(string msg)
        {
            Utils.Escrever(msg, false);
            string entrada = Utils.Ler().Trim();
            
            if (entrada != "0" && entrada != "1")
            {
                Utils.Escrever("Entrada inválida. Use 0 ou 1.");
                return LerBoolean(msg);
            }
            
            return entrada == "1";
        }

        // Gera tabela-verdade completa da fórmula escolhida
        private static void GerarTabelaVerdade(int formula)
        {
            Utils.Escrever("P\tQ\tR\tResultado");
            for (int p = 0; p <= 1; p++)
            {
                for (int q = 0; q <= 1; q++)
                {
                    for (int r = 0; r <= 1; r++)
                    {
                        bool P = p == 1;
                        bool Q = q == 1;
                        bool R = r == 1;

                        bool resultado = formula == 1
                            ? (P && Q) || R
                            : (!P || Q) && R;

                        Utils.Escrever($"{P}\t{Q}\t{R}\t{resultado}");
                    }
                }
            }
        }
    }
}