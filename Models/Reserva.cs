namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é suficiente
            if (hospedes.Count <= Suite.Capacidade)
            {
                // Ok! Pode cadastrar
                Hospedes = hospedes;
            }
            else
            {
                // A capacidade não permite essa quantidade → gera erro
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total sem desconto
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se ficar 10 dias ou mais, aplica desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Multiplica por 90% (ou seja, aplica 10% de desconto)
            }

            return valor;
        }
    }
}
