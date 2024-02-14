using AdaFood.Domain;
using AdaFood.Domain.Interfaces;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AdaFood.Repository
{
    public class EntregadorRepository : IEntregadorRepository<Entregador>
    {
        private static string _repositoryJsonPath;
        public EntregadorRepository()
        {
            string _jsonFileName = "Data\\dados_entregadores.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _repositoryJsonPath = Path.Combine(baseDirectory, _jsonFileName).Replace("bin\\Debug\\net8.0", "");
        }
        public void Add(Entregador entregador)
        {
            var Entregadores = PegarDados();
            var entregadorExistente = Entregadores.FirstOrDefault(e => e.Cpf.Equals(entregador.Cpf));
            if (entregadorExistente is null)
            {
                Entregadores.Add(entregador);
                SalvarDados(Entregadores);
            }
            else
                throw new Exception("Já existe um entregador com este CPF.");
        }

        public Entregador? Delete(int id)
        {
            var Entregadores = PegarDados();
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));

            if (entregador != null)
                Entregadores.Remove(entregador);

            SalvarDados(Entregadores);
            return entregador;
        }

        public IEnumerable<Entregador> GetAll()
        {
            return PegarDados();
        }

        public Entregador? GetById(int id)
        {
            var Entregadores = PegarDados();
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));
            return entregador;
        }

        public Entregador? GetByCPF(string cpf)
        {
            var Entregadores = PegarDados();
            var entregador = Entregadores.FirstOrDefault(e => e.Cpf.Equals(cpf));
            return entregador;
        }

        public void Update(Entregador entregador)
        {
            var Entregadores = PegarDados();
            var entregadorAntigo = Entregadores.FirstOrDefault(e => e.Id.Equals(entregador.Id));
            entregador.Cpf = Regex.Replace(entregador.Cpf, @"\D", "");

            if (entregadorAntigo != null)
            {
                Entregadores.Remove(entregadorAntigo);
                Entregadores.Add(entregador);
                Entregadores = Entregadores.OrderBy(e => e.Id).ToList();
                SalvarDados(Entregadores);
            }
            else
                Console.WriteLine($"Não existe entregador de ID {entregador.Id}.");
        }

        private static List<Entregador>? PegarDados()
        {
            List<Entregador>? entregadores = new();

            if (File.Exists(_repositoryJsonPath))
            {
                string jsonData = File.ReadAllText(_repositoryJsonPath);
                entregadores = JsonConvert.DeserializeObject<List<Entregador>>(jsonData);
            }

            return entregadores;
        }

        private static void SalvarDados(List<Entregador> entregadores)
        {
            if (File.Exists(_repositoryJsonPath))
            {
                string novoJsonData = JsonConvert.SerializeObject(entregadores, Formatting.Indented);
                File.WriteAllText(_repositoryJsonPath, novoJsonData);
            }
        }
    }
}
