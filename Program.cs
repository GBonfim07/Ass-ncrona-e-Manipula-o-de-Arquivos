using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Desafio de Processamento de Arquivos TXT ===\n");

        // Solicita o diretório ao usuário
        Console.Write("Informe o caminho do diretório: ");
        string? dir = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
        {
            Console.WriteLine("Diretório inválido. Encerrando...");
            return;
        }

        // Busca todos os arquivos .txt no diretório
        string[] arquivos = Directory.GetFiles(dir, "*.txt", SearchOption.TopDirectoryOnly);

        if (arquivos.Length == 0)
        {
            Console.WriteLine("Nenhum arquivo .txt encontrado no diretório informado.");
            return;
        }

        Console.WriteLine("\nArquivos encontrados:");
        foreach (var arq in arquivos)
            Console.WriteLine($" - {Path.GetFileName(arq)}");

        Console.WriteLine("\nIniciando processamento...\n");

        // Lista de tarefas para processar arquivos em paralelo
        var tasks = arquivos.Select(ProcessarArquivoAsync).ToList();

        // Aguarda todas finalizarem
        var resultados = await Task.WhenAll(tasks);

        // Cria pasta export
        string pastaExport = Path.Combine(AppContext.BaseDirectory, "export");
        Directory.CreateDirectory(pastaExport);

        string caminhoRelatorio = Path.Combine(pastaExport, "relatorio.txt");

        // Gera relatório
        await File.WriteAllLinesAsync(caminhoRelatorio, resultados);

        Console.WriteLine("\n✅ Processamento concluído!");
        Console.WriteLine($"Relatório gerado em: {caminhoRelatorio}");
    }

    static async Task<string> ProcessarArquivoAsync(string caminho)
{
    string nomeArquivo = Path.GetFileName(caminho);
    Console.WriteLine($"Processando: {nomeArquivo} ...");

    string[] linhas = await File.ReadAllLinesAsync(caminho);

    int qtdLinhas = linhas.Length;
    int qtdPalavras = linhas.Sum(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);

    Console.WriteLine($"Concluído : {nomeArquivo} - {qtdLinhas} linha(s), {qtdPalavras} palavra(s).");

    string resultado = $"{nomeArquivo} - {qtdLinhas} linhas - {qtdPalavras} palavras";
    return resultado;
}

}