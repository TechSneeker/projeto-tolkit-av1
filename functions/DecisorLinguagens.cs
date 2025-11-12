using System;

namespace ConsoleApp1.functions
{
	public static class DecisorLinguagens
	{
		private static readonly string alfabeto = "ab";

		public static void Decidir()
		{
			while (true)
			{
				Utils.Escrever("=== Decisor de Linguagens ===");
				Utils.Escrever("1. L_fim_b (termina com 'b')");
				Utils.Escrever("2. L_mult3_b (número de 'b' múltiplo de 3')");
				Utils.Escrever("3. Voltar");
				Utils.Escrever("Escolha uma opção: ", false);
				string opcao = Utils.Ler();

				switch (opcao)
				{
					case "1":
						Utils.Limpar();
						TerminaComB();
						break;
					case "2":
						Utils.Limpar();
						BMultiploDe3();
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

		// Decide se uma cadeia sobre ? termina com 'b'
		public static void TerminaComB()
		{
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
				string resultado = cadeia.EndsWith("b") ? "SIM" : "NAO";
				Utils.Escrever(resultado);
			}

			Utils.Escrever("Pressione qualquer tecla para continuar...");
			Utils.Ler();
			Utils.Limpar();
		}

		public static void BMultiploDe3()
		{
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
				int contadorB = 0;
				foreach (char c in cadeia)
				{
					if (c == 'b') contadorB++;
				}

				string resultado = (contadorB % 3 == 0) ? "SIM" : "NAO";
				Utils.Escrever(resultado);
			}

			Utils.Escrever("Pressione qualquer tecla para continuar...");
			Utils.Ler();
			Utils.Limpar();
		}

		// Valida se todos os símbolos da cadeia pertencem ao alfabeto
		private static bool ValidarAlfabeto(string cadeia)
		{
			foreach (char simbolo in cadeia)
			{
				if (!alfabeto.Contains(simbolo))
				{
					return false;
				}
			}
			return true;
		}
	}
}