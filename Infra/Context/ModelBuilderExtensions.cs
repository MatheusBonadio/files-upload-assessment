using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>().HasData(
            new Document
            {
                Id = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Title = "Relatório Financeiro 2022",
                Description = "Este é o relatório anual de desempenho financeiro da empresa para o ano de 2022. O documento contém informações detalhadas sobre receitas, despesas, lucros e perdas. Ele fornece uma visão abrangente do desempenho financeiro da empresa durante o ano, destacando os principais marcos e conquistas.",
                CreatedAt = new DateTime(2022, 1, 1, 8, 0, 0),
                UpdatedAt = new DateTime(2022, 1, 15, 16, 30, 0)
            },
            new Document
            {
                Id = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Title = "Política de Empréstimos Pessoais",
                Description = "Esta política estabelece as diretrizes para empréstimos pessoais oferecidos aos clientes individuais. Ela descreve os critérios de elegibilidade, taxas de juros, termos de pagamento e outras informações importantes. Esta política é projetada para garantir transparência e equidade no processo de empréstimo.",
                CreatedAt = new DateTime(2022, 2, 5, 14, 45, 0),
                UpdatedAt = new DateTime(2023, 3, 14, 7, 35, 0)
            },
            new Document
            {
                Id = new Guid("51cdf617-f8e2-4049-9a42-f51982b77c89"),
                Title = "Contrato de Investimento em Ações",
                Description = "Este contrato estabelece os termos e condições de investimento em ações da empresa XYZ. Ele detalha os direitos e responsabilidades das partes envolvidas, incluindo investidores e a empresa emissora. Este contrato é fundamental para garantir a clareza e a conformidade nas transações de ações.",
                CreatedAt = new DateTime(2020, 11, 5, 11, 30, 0),
                UpdatedAt = new DateTime(2021, 3, 12, 9, 10, 0)
            },
            new Document
            {
                Id = new Guid("7a1919e8-7910-45c1-9af8-f25510f14858"),
                Title = "Termos e Condições de Conta Bancária",
                Description = "Estes termos e condições gerais estabelecem os princípios que regem o relacionamento entre os titulares de contas bancárias e o banco. Eles incluem informações sobre taxas, encargos, serviços disponíveis e políticas de segurança. Os termos ajudam a garantir a transparência e a conformidade nas operações bancárias.",
                CreatedAt = new DateTime(2021, 7, 20, 14, 30, 0),
                UpdatedAt = new DateTime(2022, 8, 18, 10, 45, 0)
            },
            new Document
            {
                Id = new Guid("fd39a0f1-ffe2-4550-9135-4f87c016b6b2"),
                Title = "Política de Privacidade",
                Description = "Esta política estabelece as práticas e procedimentos de privacidade de dados adotados pelo banco. Ela descreve como as informações pessoais dos clientes são coletadas, usadas e protegidas. A política é crucial para manter a confiança dos clientes e garantir a conformidade com regulamentos de privacidade.",
                CreatedAt = new DateTime(2020, 5, 10, 9, 0, 0),
                UpdatedAt = new DateTime(2021, 9, 3, 17, 15, 0)
            },
            new Document
            {
                Id = new Guid("eae2c897-b594-4edc-aa78-2ba59001db5b"),
                Title = "Contrato de Empréstimo Empresarial",
                Description = "Este contrato define os termos e condições para empréstimos concedidos a empresas e empreendedores. Ele especifica taxas de juros, prazos de pagamento e garantias. O contrato é fundamental para estabelecer as obrigações das partes envolvidas em empréstimos comerciais.",
                CreatedAt = new DateTime(2020, 9, 15, 13, 10, 0),
                UpdatedAt = new DateTime(2021, 4, 8, 14, 55, 0)
            },
            new Document
            {
                Id = new Guid("b7e731f1-793f-4ad7-950f-b0db590f0743"),
                Title = "Relatório Trimestral de Desempenho",
                Description = "Este relatório trimestral destaca o desempenho financeiro da empresa ao longo de um trimestre específico. Ele inclui análises de receitas, despesas e lucros. Os investidores e analistas contam com este relatório para avaliar o progresso da empresa ao longo do tempo.",
                CreatedAt = new DateTime(2021, 1, 10, 10, 0, 0),
                UpdatedAt = new DateTime(2022, 1, 20, 15, 30, 0)
            },
            new Document
            {
                Id = new Guid("367b760d-3ec4-48da-bafd-bbc7aa0e49da"),
                Title = "Política de Segurança de Dados",
                Description = "Esta política descreve as medidas de segurança de dados implementadas para proteger as informações confidenciais e prevenir fraudes. Ela inclui diretrizes de segurança de rede, criptografia e gerenciamento de acesso. A política é essencial para garantir a integridade dos dados e a privacidade dos clientes.",
                CreatedAt = new DateTime(2020, 4, 3, 11, 20, 0),
                UpdatedAt = new DateTime(2021, 6, 29, 9, 5, 0)
            },
            new Document
            {
                Id = new Guid("d27cd692-50e1-455f-a180-478f594f7336"),
                Title = "Contrato de Cartão de Crédito",
                Description = "Este contrato estabelece os termos e condições para a emissão e uso de cartões de crédito. Ele detalha as taxas, limites de crédito, encargos e responsabilidades do titular do cartão. Os titulares de cartões confiam neste contrato para entender os custos e os benefícios associados ao uso do cartão.",
                CreatedAt = new DateTime(2020, 8, 7, 15, 40, 0),
                UpdatedAt = new DateTime(2021, 11, 10, 12, 20, 0)
            },
            new Document
            {
                Id = new Guid("d4cb2194-2549-4fe5-9e6a-0da2c2b99a2a"),
                Title = "Relatório Anual de Investimentos",
                Description = "Este é o relatório anual que detalha o desempenho dos investimentos e carteiras gerenciados pela empresa. Ele fornece informações sobre retornos, alocações de ativos e estratégias de investimento. Investidores e clientes confiam neste relatório para tomar decisões informadas sobre seus investimentos.",
                CreatedAt = new DateTime(2020, 2, 15, 9, 0, 0),
                UpdatedAt = new DateTime(2021, 3, 28, 16, 40, 0)
            }
        );

        modelBuilder.Entity<File>().HasData(
            new File
            {
                Id = new Guid("7be5e26d-a3b4-422f-9c03-95e4293dcc56"),
                Name = "Relatorio_Financeiro_2022",
                CreatedAt = new DateTime(2022, 1, 1, 8, 0, 0),
                DocumentId = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Extension = ".html",
                Version = 0
            },
            new File
            {
                Id = new Guid("f71f2eed-5ef3-4dce-ac65-84396ae76258"),
                Name = "Relatorio_Financeiro_2022",
                CreatedAt = new DateTime(2022, 2, 15, 16, 30, 0),
                DocumentId = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Extension = ".html",
                Version = 1
            },
            new File
            {
                Id = new Guid("f5c8c7fc-41fd-4dda-930c-ea59b0c7b6de"),
                Name = "Politica_Empréstimos_Pessoais",
                CreatedAt = new DateTime(2021, 7, 10, 12, 30, 0),
                DocumentId = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Extension = ".txt",
                Version = 0
            },
            new File
            {
                Id = new Guid("4b8a1ecc-2170-42f2-8b65-e26279d182b5"),
                Name = "Politica_Empréstimos_Pessoais",
                CreatedAt = new DateTime(2021, 8, 5, 14, 15, 0),
                DocumentId = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Extension = ".txt",
                Version = 1
            },
            new File
            {
                Id = new Guid("d7050741-5365-4f18-954c-57a4a9b95b20"),
                Name = "Contrato_Investimento_Ações",
                CreatedAt = new DateTime(2020, 6, 20, 11, 45, 0),
                DocumentId = new Guid("51cdf617-f8e2-4049-9a42-f51982b77c89"),
                Extension = ".xlsx",
                Version = 0
            },
            new File
            {
                Id = new Guid("9260c817-336c-4e49-9e83-3c1bbeb5bb1a"),
                Name = "Contrato_Investimento_Ações",
                CreatedAt = new DateTime(2020, 7, 30, 9, 10, 0),
                DocumentId = new Guid("51cdf617-f8e2-4049-9a42-f51982b77c89"),
                Extension = ".xlsx",
                Version = 1
            },
            new File
            {
                Id = new Guid("fe731f15-fc3b-4680-bf1d-f6fae7f45de7"),
                Name = "Termos_Condições_Conta_Bancária",
                CreatedAt = new DateTime(2022, 3, 5, 8, 20, 0),
                DocumentId = new Guid("7a1919e8-7910-45c1-9af8-f25510f14858"),
                Extension = ".png",
                Version = 0
            },
            new File
            {
                Id = new Guid("084c3f8d-f9c0-4bd1-b7ba-9b72107e2e2b"),
                Name = "Termos_Condições_Conta_Bancária",
                CreatedAt = new DateTime(2022, 4, 18, 14, 0, 0),
                DocumentId = new Guid("7a1919e8-7910-45c1-9af8-f25510f14858"),
                Extension = ".png",
                Version = 1
            },
            new File
            {
                Id = new Guid("9fd99ba8-0d88-42b4-9431-a7a8f3e29d90"),
                Name = "Politica_Privacidade",
                CreatedAt = new DateTime(2021, 2, 8, 10, 25, 0),
                DocumentId = new Guid("fd39a0f1-ffe2-4550-9135-4f87c016b6b2"),
                Extension = ".jpg",
                Version = 0
            },
            new File
            {
                Id = new Guid("b2d5ef9a-9f83-4665-84cc-e2ccd1a09b9e"),
                Name = "Contrato_Empréstimo_Empresarial",
                CreatedAt = new DateTime(2020, 12, 10, 13, 45, 0),
                DocumentId = new Guid("eae2c897-b594-4edc-aa78-2ba59001db5b"),
                Extension = ".docx",
                Version = 0
            },
            new File
            {
                Id = new Guid("4cb9b50b-85e0-45c2-a6a5-d9c38d7119c8"),
                Name = "Contrato_Empréstimo_Empresarial",
                CreatedAt = new DateTime(2021, 5, 15, 14, 20, 0),
                DocumentId = new Guid("eae2c897-b594-4edc-aa78-2ba59001db5b"),
                Extension = ".docx",
                Version = 1
            },
            new File
            {
                Id = new Guid("56653edf-9e2e-4bf5-828e-735e281e6c53"),
                Name = "Relatorio_Trimestral_Desempenho",
                CreatedAt = new DateTime(2020, 9, 30, 10, 15, 0),
                DocumentId = new Guid("b7e731f1-793f-4ad7-950f-b0db590f0743"),
                Extension = ".md",
                Version = 0
            },
            new File
            {
                Id = new Guid("c8ac0076-5506-4913-af40-037fbaea86ce"),
                Name = "Politica_Segurança_Dados",
                CreatedAt = new DateTime(2021, 1, 12, 9, 15, 0),
                DocumentId = new Guid("367b760d-3ec4-48da-bafd-bbc7aa0e49da"),
                Extension = ".mp3",
                Version = 0
            },
            new File
            {
                Id = new Guid("abf1e274-24e6-4cdc-8925-ad24c974935b"),
                Name = "Contrato_Cartão_Crédito",
                CreatedAt = new DateTime(2020, 2, 28, 8, 50, 0),
                DocumentId = new Guid("d27cd692-50e1-455f-a180-478f594f7336"),
                Extension = ".pptx",
                Version = 0
            },
            new File
            {
                Id = new Guid("a1e5a6eb-c8d6-47c2-8682-cb8a51c7adf5"),
                Name = "Contrato_Cartão_Crédito",
                CreatedAt = new DateTime(2020, 3, 20, 11, 30, 0),
                DocumentId = new Guid("d27cd692-50e1-455f-a180-478f594f7336"),
                Extension = ".pptx",
                Version = 1
            },
            new File
            {
                Id = new Guid("e6bdf229-832e-4c5e-9e25-fc2880ffca77"),
                Name = "Relatorio_Anual_Investimentos",
                CreatedAt = new DateTime(2020, 4, 15, 10, 0, 0),
                DocumentId = new Guid("d4cb2194-2549-4fe5-9e6a-0da2c2b99a2a"),
                Extension = ".pdf",
                Version = 0
            },
            new File
            {
                Id = new Guid("7256069b-59a3-44bd-9673-2cf97bb97041"),
                Name = "Relatorio_Anual_Investimentos",
                CreatedAt = new DateTime(2020, 5, 10, 13, 40, 0),
                DocumentId = new Guid("d4cb2194-2549-4fe5-9e6a-0da2c2b99a2a"),
                Extension = ".pdf",
                Version = 1
            },
            new File
            {
                Id = new Guid("0f03c299-d026-47c3-94aa-e80554d9ebaf"),
                Name = "Relatorio_Financeiro_2022",
                CreatedAt = new DateTime(2022, 3, 10, 14, 30, 0),
                DocumentId = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Extension = ".html",
                Version = 2
            },
            new File
            {
                Id = new Guid("2a1246ac-57e9-4c46-a9af-3231eadc0a83"),
                Name = "Relatorio_Financeiro_2022",
                CreatedAt = new DateTime(2022, 4, 20, 12, 0, 0),
                DocumentId = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Extension = ".html",
                Version = 3
            },
            new File
            {
                Id = new Guid("daa59739-133f-4bad-8b1b-7261383a7699"),
                Name = "Relatorio_Financeiro_2022",
                CreatedAt = new DateTime(2022, 3, 14, 07, 35, 0),
                DocumentId = new Guid("1d4169d5-fcf6-4bec-a4df-afe975160fa1"),
                Extension = ".html",
                Version = 4
            },
            new File
            {
                Id = new Guid("9d3c35d0-53af-4e83-82f3-1345a53046ba"),
                Name = "Politica_Empréstimos_Pessoais",
                CreatedAt = new DateTime(2021, 9, 5, 10, 15, 0),
                DocumentId = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Extension = ".txt",
                Version = 2
            },
            new File
            {
                Id = new Guid("4ba6d15e-ee3a-4620-baca-c416e6bb591d"),
                Name = "Politica_Empréstimos_Pessoais",
                CreatedAt = new DateTime(2021, 10, 10, 9, 0, 0),
                DocumentId = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Extension = ".txt",
                Version = 3
            },
            new File
            {
                Id = new Guid("7740bd5a-9c93-44b4-838c-4ef23072bf83"),
                Name = "Politica_Empréstimos_Pessoais",
                CreatedAt = new DateTime(2021, 11, 5, 18, 0, 0),
                DocumentId = new Guid("f17db8f1-1959-493e-a57d-087c51d405c8"),
                Extension = ".txt",
                Version = 4
            },
            new File
            {
                Id = new Guid("b57f657b-51d7-4e19-9245-b10e861e9d4a"),
                Name = "Contrato_Investimento_Ações",
                CreatedAt = new DateTime(2020, 8, 15, 11, 0, 0),
                DocumentId = new Guid("51cdf617-f8e2-4049-9a42-f51982b77c89"),
                Extension = ".xlsx",
                Version = 2
            }
        );
    }
}