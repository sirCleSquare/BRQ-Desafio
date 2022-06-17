using System;
using System.Text.RegularExpressions;

namespace Desafio_IMC
{
    internal class Program
    {
        /*
         OBJETIVO   : Diagnóstico prévio para o programa de emagrecimento
         CRIAÇÃO    : 14/06/2022
         AUTOR      : Valtécio CS
         TAREFAS    : Tela; Digitação de dados; Cálculos; Exibição de resultados; validação de campos
         PENDÊNCIAS : 
         VERSÃO     : 9.4
        */
        static void Main(string[] args)
        {
            // Notação Húngara para nomeação de variáveis para identificar o tipo de dados
            string sNome;
            string sSexo;
            int iIdade = 0;
            float fAltura = 0;
            float fPeso = 0;
            float fIMC;
            string sCategoria;
            string sRiscos;
            string sRecomendacaoInicial;

            Console.WriteLine("PROGRAMA DE EMAGRECIMENTO");
            Console.WriteLine("");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            Console.WriteLine("");

            #region DIGITAÇÃO DOS DADOS/CAMPOS

            // Nome
            do
            {
                Console.Write("Nome".PadRight(15) + ": ");
                sNome = Console.ReadLine();

            } while (ValidaNome(sNome) == false);

            // Sexo
            do
            {
                Console.Write("Sexo (F/M)".PadRight(15) + ": ");
                sSexo = Console.ReadLine();

            } while (ValidaSexo(sSexo) == false);

            // Idade
            do
            {
                try
                {
                    Console.Write("Idade (anos)".PadRight(15) + ": ");

                }
                catch (Exception)
                {
                }

            } while (ValidaIdade(iIdade) == false);

            // altura em metros
            do
            {
                try
                {
                    Console.Write("Altura (m)".PadRight(15) + ": ");
                    fAltura = float.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

            } while (ValidaAltura(fAltura) == false);

            do
            {
                try
                {
                    Console.Write("Peso (kg)".PadRight(15) + ": ");
                    fPeso = float.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

            } while (ValidaPeso(fPeso) == false);


            // Categoria
            Console.Write("Categoria".PadRight(15) + ": ");

            switch (iIdade)
            {
                case < 12:
                    sCategoria = "Infantil";
                    break;
                case < 21:
                    sCategoria = "Juvenil";
                    break;
                case < 65:
                    sCategoria = "Adulto";
                    break;
                case < 130:
                    sCategoria = "Idoso";
                    break;
                default:
                    sCategoria = "Idade inválida (acima do limite de 130:";
                    break;

            }
            
            Console.Write(sCategoria);
            #endregion

            Console.WriteLine("\n\n");
            Console.WriteLine("IMC Desejável  : Entre 20 e 24");

            #region Cálculos
            fIMC = fPeso / (float)Math.Pow(fAltura, 2);

            Console.WriteLine("");
            Console.Write("Resultado IMC".PadRight(15) + ": ");
            Console.Write(fIMC.ToString("0.00")+"   ");

            #region algo a mais (não solicitado oficialmente)
            if (fIMC < 20)
               Console.Write("[Abaixo do Peso ideal]");
            else
            if (fIMC < 25)
                Console.Write("[Peso Normal]");
            else
            if (fIMC < 30)
                Console.Write("[Excesso de peso]");
            else
            if (fIMC < 35)
                Console.Write("[Obesidade]");
            else
                Console.Write("[Super obesidade]");
            #endregion

            Console.WriteLine("");
            #endregion

            #region Riscos & Recomendação
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

            #endregion
            // ROTINAS / MÉTODOS / FUNÇÕES / PROCEDIMENTOS

            #region Validações de Campos

            static bool ValidaNome(string sNome)
            {
                bool bValidaCampo = true;   // True se validação ocorreu sem encontrar erros

                if (sNome.Trim() == "")     // Se foi digitado pelo menos um espaço em branco ou pressionado o [ENTER]
                {
                    Console.Write("ERRO: Informe o nome. [ENTER] para continuar ");
                    Console.ReadLine();
                    bValidaCampo = false;
                }
                else
                {
                    if (sNome.Length > 60)
                    {
                        Console.Write("ERRO: Tamanho máximo é 60 caracteres. [ENTER] para continuar ");
                        Console.ReadLine();
                        bValidaCampo = false;
                    }
                    else
                    {
                        Regex padrao = new Regex(@"[A-Za-z]");

                        if (!padrao.IsMatch(sNome))
                        {
                            Console.Write("ERRO: Digite somente letras ou espaços. [ENTER] para continuar ");
                            Console.ReadLine();
                            bValidaCampo = false;
                        }

                    }

                }

                return bValidaCampo;
            }

            static bool ValidaSexo(string sSexo)
            {
                bool bValidaCampo = true;      // True se validação ocorreu sem encontrar erros

                if (sSexo.Trim().ToUpper() != "F" && sSexo.Trim().ToUpper() != "M")
                {
                    Console.Write("ERRO: Sexo inválido (F/f:Feminino ou M/m;Masculino). [ENTER] para continuar ");
                    Console.ReadLine();

                    bValidaCampo = false;
                }

                return bValidaCampo;

            }

            static bool ValidaIdade(int idade)
            {
                bool bValidaCampo = true;       // True se validação ocorreu sem encontrar erros

                //iIdade = int.Parse(Console.ReadLine());

                if (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.Write("ERRO: Digite apenas números inteiros. [ENTER] para continuar ");
                    Console.ReadLine();
                    bValidaCampo = false;
                }
                else
                    if (idade < 1 || idade > 130)   // Limites considerados aceitáveis
                    {
                        Console.Write("ERRO: Idade fora dos limites (1 e 130). [ENTER] para continuar ");
                        Console.ReadLine();
                        bValidaCampo = false;
                    }

                return bValidaCampo;
            }

            static bool ValidaAltura(float altura)
            {
                bool bValidaCampo = true;	    // True se validação ocorreu sem encontrar erros

                if (altura < 0.2 || altura > 2.70)  // Limites considerados aceitáveis
                {
                    Console.Write("ERRO: Altura fora dos limites (0,2m e 2,80m). [ENTER] para continuar ");
                    Console.ReadLine();
                    bValidaCampo = false;
                }

                return bValidaCampo;

            }

            static bool ValidaPeso(float peso)
            {
                bool bValidaCampo = true;	    // True se validação ocorreu sem encontrar erros

                if (peso < 0.5f || peso > 410.0f)   // Limites considerados aceitáveis
                {
                    Console.Write("ERRO: Peso fora dos limites (0,5 Kg e 410 Kg).  [ENTER] para continuar ");
                    Console.ReadLine();
                    bValidaCampo = false;
                }
                
                return bValidaCampo;

            }
            #endregion

        }

    }
}
