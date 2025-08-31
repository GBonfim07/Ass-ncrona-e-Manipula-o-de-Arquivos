# Desafio de Processamento de Arquivos TXT

**Aluno:** Gustavo Bonfim  
**RM:** 98864  
**Turma:** 3ESR

Este projeto é um **Console Application em C#** que processa arquivos `.txt` de forma assíncrona e gera um relatório resumido com a contagem de linhas e palavras de cada arquivo.

---

## Funcionalidades

1. Solicita ao usuário o caminho de um diretório.
2. Lista todos os arquivos `.txt` encontrados no diretório informado.
3. Processa os arquivos em paralelo usando `async/await` para manter o console responsivo.
4. Exibe no console o andamento do processamento de cada arquivo.
5. Gera um relatório final (`relatorio.txt`) na pasta `export` contendo:
   - Nome do arquivo
   - Quantidade de linhas
   - Quantidade de palavras

---

## Requisitos

- .NET 6.0 ou superior
- Windows, Linux ou macOS

---

## Como executar

1. Clone ou baixe o repositório.
2. Abra o projeto em um editor compatível com C# (Visual Studio, VS Code, Rider).
3. Compile e execute o projeto.
4. Insira o caminho completo do diretório que contém os arquivos `.txt` quando solicitado.
5. Aguarde a conclusão do processamento.
6. O relatório será gerado na pasta `export` dentro do diretório da aplicação.

---

## Estrutura do Relatório

Cada linha do relatório terá o seguinte formato:

