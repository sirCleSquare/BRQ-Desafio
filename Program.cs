using System;

namespace Desafio_IMC
{
    internal class Program
    {
        // OBJETIVO: Diagnóstico prévio para o programa de emagrecimento
        // CRIAÇÃO : 14/06/2022
        // AUTOR   : Valtécio CS
        static void Main(string[] args)
        {
            // Notação Húngara para nomeação de variáveis para identificar o tipo de dados
            string sNome;
            string sSexo;
            byte bIdade;
            float fAltura;
            float fPeso;
            float fIMC;
            string sCategoria;
            string sRiscos;
            string sRecomendacaoInicial;
            bool bValidaCampo;

            Console.WriteLine("PARA O PROGRAMA DE EMAGRECIMENTO");
            Console.WriteLine("");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            Console.WriteLine("");

            // DIGITAÇÃO DOS DADOS

            // Nome
            bValidaCampo = false;
            do
            {
                Console.Write("Nome".PadRight(15) + ": ");
                sNome = Console.ReadLine();
           
                if (string.IsNullOrEmpty(sNome))
                {
                    Console.Write("ERRO: Informe o nome. [ENTER] para continuar ");
                    Console.ReadLine();
                }
                else
                // Colocar try exception 
                //if verificar se é só número  num outro else
                    bValidaCampo = true;


            }while (bValidaCampo == false);

            // Sexo
            bValidaCampo = false;
            do
            {
                Console.Write("Sexo (F/M)".PadRight(15) + ": ");
                sSexo = Console.ReadLine();

                if (sSexo.Trim().ToUpper() == "F" ||
                    sSexo.Trim().ToUpper() == "M" )

                    bValidaCampo = true;
                else
                    {
                        Console.Write("ERRO: Sexo inválido (F/f:Feminino ou M/m;Masculino). [ENTER] para continuar ");
                        Console.ReadLine();

                        bValidaCampo = false;
                    }

            } while (bValidaCampo == false);

            // Idade
            bValidaCampo = false;
            do
            {
                Console.Write("Idade".PadRight(15) + ": ");
                bIdade = byte.Parse(Console.ReadLine());

                if (bIdade >= 1 && bIdade <= 130)
                    bValidaCampo = true;
                else
                    { 
                        Console.Write("ERRO: Idade fora dos limites (1 e 130). [ENTER] para continuar ");
                        Console.ReadLine();
                    }

            } while (bValidaCampo == false);

            // altura em metros
            bValidaCampo = false;
            do
            {
                Console.Write("Altura (m)".PadRight(15) + ": ");
                fAltura = float.Parse(Console.ReadLine());

                if (fAltura >= 0.5 && fAltura <= 2.80)
                    bValidaCampo = true;
                else
                {
                    Console.Write("ERRO: Altura fora dos limites (0,5m e 2,80m). [ENTER] para continuar ");
                    Console.ReadLine();
                }

            } while (bValidaCampo == false);

            // Peso em Kilogramas
            bValidaCampo = false;
            do
            {
                Console.Write("Peso (kg)".PadRight(15) + ": ");
                fPeso = float.Parse(Console.ReadLine());

                if (fPeso >= 2.5f && fPeso <= 410.0f)
                    bValidaCampo = true;
                else
                {
                    Console.Write("ERRO: Peso fora dos limites (2,5 Kg e 410 Kg).  [ENTER] para continuar ");
                    Console.ReadLine();
                }

            } while (bValidaCampo == false);

            // Categoria
            Console.Write("Categoria".PadRight(15) + ": ");

            if (bIdade < 12)
                sCategoria = "Infantil";
            else
            if (bIdade < 21)
                sCategoria = "Juvenil";
            else
            if (bIdade < 65)
                sCategoria = "Adulto";
            else
            if (bIdade < 130)   // delimitando um limite razoável de idade digitada
                sCategoria = "Idoso";
            else
                sCategoria = "Idade inválida (acima do limite de 130)";

            Console.Write(sCategoria);

            Console.WriteLine("\n\n");
            Console.WriteLine("IMC Desejável  : Entre 20 e 24");

            // CÁLCULOS
            fIMC = fPeso / (float)Math.Pow(fAltura, 2);

            Console.WriteLine("");
            Console.Write("Resultado IMC".PadRight(15) + ": ");
            Console.WriteLine(fIMC.ToString("0.00"));

            // Riscos & Recomendação
            switch (fIMC)
            {
                case < 20:
                    sRiscos = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";
                    sRecomendacaoInicial = "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional .";
                    break;
                case < 25:
                    sRiscos = "Seu peso está ideal para suas referências.";
                    sRecomendacaoInicial = "Mantenha uma dieta saudável e faça seus exames periódicos.";
                    break;
                case < 30:
                    sRiscos = "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
                    sRecomendacaoInicial = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante";
                    break;
                case < 35:
                    sRiscos = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
                    sRecomendacaoInicial = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista (endócrino).";
                    break;
                default:
                    sRiscos = "Obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                    sRecomendacaoInicial = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista (endócrino).";
                    break;
            }

            Console.WriteLine("");
            Console.Write("Riscos".PadRight(15) + ": ");
            Console.WriteLine(sRiscos);

            Console.WriteLine("");
            Console.Write("Recomendação inicial : ");
            Console.WriteLine(sRecomendacaoInicial);

        }

    }
}
