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
            string sNome;
            //string sSexo;
            char cSexo;
            byte bIdade;
            float fAltura;
            float fPeso;
            float fIMC;
            string sCategoria;
            string sRiscos;
            string sRecomendacaoInicial;

            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            Console.WriteLine("");

            // Digitação dos dados
            Console.Write("Nome".PadRight(15) + ": ");
            sNome = Console.ReadLine();

            Console.Write("Sexo (F/M)".PadRight(15) + ": ");
            cSexo = char.Parse(Console.ReadLine());
            /*
            if (cSexo.ToString() == "F")
                sSexo = "Feminino";
            else
                sSexo = "Masculino";

            Console.Write(sSexo);
            */

            Console.Write("Idade".PadRight(15) + ": ");
            bIdade = byte.Parse(Console.ReadLine());

            Console.Write("Altura (m)".PadRight(15) + ": ");
            fAltura = float.Parse(Console.ReadLine());

            Console.Write("Peso (kg)".PadRight(15) + ": ");
            fPeso = float.Parse(Console.ReadLine());

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
                sCategoria = "Idade inválida (acima do limite)";

            Console.Write(sCategoria);

            Console.WriteLine("\n\n");
            Console.WriteLine("IMC Desejável  : Entre 20 e 24".PadRight(15));

            // Cálculos
            fIMC = fPeso / (float)Math.Pow(fAltura, 2);

            Console.WriteLine("");
            Console.Write("Resultado IMC".PadRight(15) + ": ");
            Console.WriteLine(fIMC.ToString(".00"));

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
