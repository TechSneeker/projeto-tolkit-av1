using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1.functions
{
    public class Item
    {
        public string Identificador { get; set; } = "";
        public string Enunciado { get; set; } = "";
        public string CategoriaCorreta { get; set; } = "";
    }

    public class RespostaProblemaXInstancia
    {
        public Item Item { get; set; } = new Item();
        public required string escolha;
    }

    public static class ClassificadorProblemaXInstancia
    {
        private static readonly List<RespostaProblemaXInstancia> RespostasProblemaXInstancia = new List<RespostaProblemaXInstancia>();

        public static void IniciarQuestionario()
        {
            RespostasProblemaXInstancia.Clear();
            Utils.Escrever("-------- Problema × Instância --------");
            Utils.Escrever("P = Problema | I = Instância");

            List<Item> itens = CarregarItens();

            if (itens.Count == 0)
            {
                Utils.Escrever("Nenhum item foi carregado.");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
                return;
            }

            for (int i = 0; i < itens.Count; i++)
            {
                Utils.Escrever($"Identificador: {itens[i].Identificador}");
                Utils.Escrever($"Enunciado: {itens[i].Enunciado}");
                Utils.Escrever("Escolha a classificação correta (P, I): ", false);

                bool respostaValida = ColetarResposta(itens[i]);
                if (!respostaValida)
                {
                    Utils.Escrever("Resposta inválida. Por favor, responda com 'T', 'I' ou 'N'.");
                    i--;
                    Utils.Ler();
                }
                Utils.Limpar();
            }

            Utils.Limpar();

            int acertos = 0;
            int total = RespostasProblemaXInstancia.Count;

            Utils.Escrever("=== Resultados ===");
            foreach (RespostaProblemaXInstancia respostaProblemaXInstancia in RespostasProblemaXInstancia)
            {
                bool acertou = respostaProblemaXInstancia.escolha == respostaProblemaXInstancia.Item.CategoriaCorreta;
                if (acertou) acertos++;

                string status = acertou ? "ACERTO" : "ERRO";
                Utils.Escrever($"{respostaProblemaXInstancia.Item.Identificador}: {status}");
            }

            Utils.Escrever($"Resumo: {acertos}/{total} acertos");

            Utils.Escrever("Pressione qualquer tecla para sair...");
            Utils.Ler();

            Utils.Limpar();
        }

        private static bool ColetarResposta(Item item)
        {
            string respostaChar = Utils.Ler();

            string respostaPadronizada = ConverterResposta(respostaChar);
            if (respostaPadronizada == null)
            {
                return false;
            }

            RespostaProblemaXInstancia RespostaProblemaXInstancia = new()
            {
                Item = item,
                escolha = respostaPadronizada
            };

            RespostasProblemaXInstancia.Add(RespostaProblemaXInstancia);
            return true;
        }

        private static string? ConverterResposta(string respostaProblemaXInstancia)
        {
            return respostaProblemaXInstancia.ToLower() switch
            {
                "p" => "problema",
                "i" => "instancia",
                _ => null,
            };
        }

        /// Carrega problemas do arquivo JSON
        private static List<Item> CarregarItens()
        {
            try
            {
                string caminhoProjeto = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                string caminhoArquivo = Path.Combine(caminhoProjeto, "data", "itens.json");
                string jsonContent = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<Item>>(jsonContent) ?? new List<Item>();
            }
            catch
            {
                return new List<Item>();
            }
        }
    }
}