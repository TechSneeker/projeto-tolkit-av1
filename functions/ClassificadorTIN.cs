using System.Text.Json;

namespace ConsoleApp1.functions
{
    public class Problema
    {
        public string Identificador { get; set; } = "";
        public string Enunciado { get; set; } = "";
        public string CategoriaCorreta { get; set; } = "";
    }

    public class Resposta
    {
        public Problema Problema { get; set; } = new Problema();
        public required string escolha;
    }

    public static class ClassificadorTIN
    {
        private static readonly List<Resposta> Respostas = new List<Resposta>();

        public static void IniciarQuestionario()
        {
            Respostas.Clear();
            Utils.Escrever("-------- Questionário T.I.N --------");
            Utils.Escrever("T = Tratável | I = Intratável | N = Não computável");

            List<Problema> problemas = CarregarProblemas();
            
            if (problemas.Count == 0)
            {
                Utils.Escrever("Nenhum problema foi carregado.");
                Utils.Escrever("Pressione qualquer tecla para continuar...");
                Utils.Ler();
                Utils.Limpar();
                return;
            }

            for (int i = 0; i < problemas.Count; i++)
            {
                Utils.Escrever($"Identificador: {problemas[i].Identificador}");
                Utils.Escrever($"Enunciado: {problemas[i].Enunciado}");
                Utils.Escrever("Escolha a categoria correta (T, I, N): ", false);

                bool respostaValida = ColetarResposta(problemas[i]);
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
            int total = Respostas.Count;
            
            Utils.Escrever("=== Resultados ===");
            foreach (Resposta resposta in Respostas)
            {
                bool acertou = resposta.escolha == resposta.Problema.CategoriaCorreta;
                if (acertou) acertos++;
                
                string status = acertou ? "ACERTO" : "ERRO";
                Utils.Escrever($"{resposta.Problema.Identificador}: {status}");
            }
            
            Utils.Escrever($"Resumo: {acertos}/{total} acertos");

            Utils.Escrever("Pressione qualquer tecla para sair...");
            Utils.Ler();

            Utils.Limpar();
        }

        private static bool ColetarResposta(Problema problema)
        {
            string respostaChar = Utils.Ler();

            string respostaPadronizada = ConverterResposta(respostaChar);
            if (respostaPadronizada == null)
            {
                return false;
            }

            Resposta Resposta = new()
            {
                Problema = problema,
                escolha = respostaPadronizada
            };

            Respostas.Add(Resposta);
            return true;
        }

        private static string? ConverterResposta(string resposta)
        {
            return resposta.ToLower() switch
            {
                "t" => "tratavel",
                "i" => "intratavel",
                "n" => "nao_computavel",
                _ => null,
            };
        }

        /// Carrega problemas do arquivo JSON
        private static List<Problema> CarregarProblemas()
        {
            try
            {
                string caminhoArquivo = Path.Combine("data", "problemas.json");
                string jsonContent = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<Problema>>(jsonContent) ?? new List<Problema>();
            }
            catch
            {
                return new List<Problema>();
            }
        }
    }
}