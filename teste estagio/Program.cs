using Newtonsoft.Json;
using System.Globalization;
using teste_estagio;




// PRIMEIRA QUESTÃO-----------------------------------------------------------------------------------
int INDICE = 13;
int SOMA = 0;
int K = 0;

while(K< INDICE)
{
    K=K+1;
    SOMA=SOMA+K;
    Console.WriteLine(SOMA);
}



//SEGUNDA QUESTÃO-----------------------------------------------------------------------------------
static void Fibonacci()
{
    Console.Write("\ninforme um numero\n");

    // verificamos se o que foi informado pode ser passado para INT
    if(int.TryParse(Console.ReadLine(), out int num))
    {
        
        if (PertenceFibonacci(num))
        {
            Console.WriteLine($"Numero informado pertence a Fibonacci {num}\n");
        }else
        {
            Console.WriteLine($"Numero informado não pertence a Fibonacci {num}\n");
        }

    }
    // caso não seja
    else
    {
        Console.WriteLine("Insira um caractere numerico \n");
    }

    static bool PertenceFibonacci(int numero)
    {
        //numero 0 e 1 pertencem
        if (numero == 0 || numero == 1) 
        {
            return true;
        }

        int num1F = 0;
        int num2f = 1;

        int fib = num1F + num2f;

        //enquanto fib for menor ou igual a numero o laço se repete
        while (fib <= numero)
        {
            //caso fib(sequencia de fibonacci) for igualmente a numero o retorno é verdadeiro
            if (fib == numero) { return true; }

            //primeiro laço = num1f recebe o valor de num2f( 1 ) 
            //segundo laço = num1f recebe o valor 1
            //terceiro laço = num1f recebe o valor 2
            num1F = num2f;

            //primeiro laço = num2f recebe o valor de fib ( 1 )
            //segundo laço = num2f recebe o valor 2
            //terceiro laço = num2f recebe o valor 3
            num2f = fib;

            //primeiro laço = fib recebe o valor dos dois numF ( 2 )
            //segundo laço = fib recebe o valor 3
            //terceiro laço = fib recebe o valor 5
            fib = num1F + num2f;
            
        }

        //caso fib for maior que numero é retornado falso
        return false;
    }

}

Fibonacci();




//TERCEIRA QUESTÃO-----------------------------------------------------------------------------------
static void DiaValores()
{
    //Utilizando o arquivo json dentro da pasta json
    string jsonCaminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados.json");

    static List<Model> desJson(string jsonCaminho)
    {
        //verificando se o arquivo existe
        if (!File.Exists(jsonCaminho))
        {
            //caso não exista
            Console.WriteLine("Arquivo não localizado\n");
            return new List<Model>();
        }

        //caso exista ele faz a leitura do arquivo
        string jsonRead = File.ReadAllText(jsonCaminho);

        //e retorna um json convert em modelo de lista criado pela classe Model.cs
        return JsonConvert.DeserializeObject<List<Model>>(jsonRead)!;
    }

    //uma nova lista com Model recebe o arquivo deserializado
    List<Model> valoresDia = desJson(jsonCaminho);

    //a variavel recebe todos os valores onde são maiores que 0 em forma de lista
    var ValoresWithOut0 = valoresDia.Where(x => x.valor > 0).ToList();

    //valida se a variavel recebem algum valor
    if(ValoresWithOut0.Count > 0)
    {
        //a double recebe o valor minimo de x(ValoresWithOut0)
        double menorValor = ValoresWithOut0.Min(x => x.valor);

        //a double recebe o valor maximo de x(ValoresWithOut0)
        double maiorValor = ValoresWithOut0.Max(x => x.valor);

        //a double recebe o valor Medio(avarage) de x(ValoresWithOut0)
        double mediaValor = ValoresWithOut0.Average(x => x.valor);

        //int recebe o contador de dias que possuem valor maior que a media
        int acimaMedia = ValoresWithOut0.Count(x => x.valor > mediaValor);

        Console.WriteLine($"Menor valor do arquivo {menorValor}");
        Console.WriteLine($"Maior valor do arquivo {maiorValor}");
        Console.WriteLine($"Media de valores do arquivo {mediaValor}");
        Console.WriteLine($"Dias acima da media {acimaMedia}\n");

    }
    else
    {
        //caso o if for = a 0 ocorre a seguinte mensagem.
        Console.WriteLine("Não foram encontrados valores acima de 0.0\n");
    }

}

DiaValores();


//QUARTA QUESTÃO-----------------------------------------------------------------------------------

static void PercentualEstados()
{
    string SP = "67.836,43";
    string RJ = "36.678,66";
    string MG = "29.229,88";
    string ES = "27.165,48";
    string ot = "19.849,53";

    //Transformando o valor em decimal
    static decimal formatarDecimal(string num)
    {
        string format = num.Replace(".", "").Replace(",", "");
        decimal vardecimal = decimal.Parse(format, CultureInfo.InvariantCulture);
        return vardecimal;
    }

    //atribuindo valor decimal
    decimal spDec = formatarDecimal(SP);
    decimal rjDec = formatarDecimal(RJ);
    decimal mgDec = formatarDecimal(MG);
    decimal esDec = formatarDecimal(ES);
    decimal otDec = formatarDecimal(ot);

    //calculo total
    decimal total = spDec + rjDec + mgDec + esDec + otDec;

    //calculando percentual, recebe o valor que cada estado possui e o valor total
    static string PercentualCalculado(decimal valor, decimal total)
    {
        //calculo
        decimal percentual = (valor / total) * 100;

        //formatação para string
        string resultadoFormatado = percentual.ToString("#,##0.00", new CultureInfo("pt-BR"));

        //retorna valor em string
        return resultadoFormatado;
    }

    string resultSP = PercentualCalculado(spDec, total);
    string resultRJ = PercentualCalculado(rjDec, total);
    string resultMG = PercentualCalculado(mgDec, total);
    string resultES = PercentualCalculado(esDec, total);
    string resultOT = PercentualCalculado(otDec, total);

    Console.WriteLine($"Percentual de SP {resultSP}%");
    Console.WriteLine($"Percentual de RJ {resultRJ}%");
    Console.WriteLine($"Percentual de MG {resultMG}%");
    Console.WriteLine($"Percentual de ES {resultES}%");
    Console.WriteLine($"Percentual de outros estados {resultOT}%\n");

}

PercentualEstados();



//QUINTA QUESTÃO-----------------------------------------------------------------------------------

static void InverterString()
{
    Console.WriteLine("Digite uma palavra\n");
    string palavra = Console.ReadLine()!;

    static string Inverter(string palavra)
    {
        //criando um array de characteres
        char[] palavraChar = palavra.ToCharArray();

        int i = 0;
        int x = palavraChar.Length - 1;

        while ( i < x)
        {
            //char ch recebe o valor que esta inserido no array na posição de i
            char ch = palavraChar[i];
            //a posição i recebe o valor da posição x
            palavraChar [i] = palavraChar[x];
            //a posicao x recebe o valor do char ch
            palavraChar[x] = ch;

            i++;
            x--;
        }
    
        return new string(palavraChar);
    }

    string result = Inverter(palavra);

    Console.WriteLine($"Palavra invertida: {result}\n");

}

InverterString();