using static System.Console;

namespace cadastroSeries
{

class Program{

    static SerieRepositorio serie = new SerieRepositorio();
    static void Main(string[] args)
    {
        WriteLine();
        string opcaoUsuario = Menu();

        while (opcaoUsuario != "X"){
            switch(opcaoUsuario){
                case "1":
                    ListarSeries();
                    break;

                case "2":
                    InserirSerie();
                    break;

                case "3":
                    AtualizarSerie();
                    break;

                case "4":
                    ExcluirSerie();
                    break;

                case "5":
                    VisualizarSerie();
                    break;

                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = Menu();
            
        }
        WriteLine("Obrigada! Pressione qualquer tecla para continuar...");
        ReadLine();
    }

        private static void VisualizarSerie()
        {
            WriteLine("Visualizando série: ");
            WriteLine("Digite o id da Série: ");
            int id = int.Parse(ReadLine());

            var serieID = serie.RetornarporId(id);
            WriteLine(serieID);
        }

        private static void ExcluirSerie()
        {
            WriteLine("Excluindo série: ");
            WriteLine("Digite o id da Série: ");
            int id = int.Parse(ReadLine());

            serie.Excluir(id);
        }

        private static void AtualizarSerie()
        {
            WriteLine("Atualizando série: ");
            WriteLine("Digite o id da Série: ");
            int id = int.Parse(ReadLine());
              
            ListarGeneros();
              
            WriteLine("Digite o gênero:");
            int idGenero = int.Parse(ReadLine());

            WriteLine("Digite o título: ");
            string entradatitulo = ReadLine();

            WriteLine("Digite o ano:");
            int entradaano = int.Parse(ReadLine());

            WriteLine("Digite a descrição:");
            string entradadescricao = ReadLine();

            Series atualizaSerie = new Series(id: id,
                genero: (Genero)idGenero,
                titulo: entradatitulo,
                ano: entradaano, descricao: entradadescricao);

            serie.Atualizar(id,atualizaSerie);
        }

        private static void InserirSerie()
        {
            WriteLine("Inserindo série: ");

            ListarGeneros();

            WriteLine("Digite o gênero:");
            int idGenero = int.Parse(ReadLine());

            WriteLine("Digite o título: ");
            string entradatitulo = ReadLine();

            WriteLine("Digite o ano:");
            int entradaano = int.Parse(ReadLine());

            WriteLine("Digite a descrição:");
            string entradadescricao = ReadLine();

            Series novaSerie = new Series(id: serie.ProximoId(),
                genero: (Genero)idGenero,
                titulo: entradatitulo,
                ano: entradaano, descricao: entradadescricao);

            serie.Inserir(novaSerie);

        }

        private static void ListarGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
        }

        private static void ListarSeries()
        {
            WriteLine("Listando Séries:");
            var lista = serie.Lista();

            if (lista.Count == 0){
                WriteLine("Nenhuma série cadastrada!");
                return;
            }

                  
            foreach(var i in lista){
                var ativo = i.getAtivo();
                WriteLine("ID: {0} - {1}  {2}", i.getId(),i.getTitulo(),(ativo ? "" : "Excluído"));
             }
            
        }

        private static string Menu(){
        WriteLine("------------Menu------------");
        WriteLine("Digite a opção desejada: ");
        WriteLine("1 - Listar Séries: ");
        WriteLine("2 - Inserir Nova Série");
        WriteLine("3 - Atualizar Série ");
        WriteLine("4 - Excluir Série ");
        WriteLine("5 - Visualizar Série ");
        WriteLine("C - Limpar Tela ");
        WriteLine("X - Sair");
        WriteLine();

        string opcao = ReadLine().ToUpper();
        WriteLine();
        return opcao;
    }
}
}