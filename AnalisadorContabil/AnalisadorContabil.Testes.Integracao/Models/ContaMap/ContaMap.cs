using FluentNHibernate.Mapping;

namespace AnalisadorContabil.Testes.Integracao.Models.ContaMap
{
    public class ContaMap : ClassMap<Conta>
    {
        public ContaMap()
        {
            Id(h => h.Id);

            Map(h => h.Numero);
            Map(h => h.ValorReceita);
            Map(h => h.ValorDespesa);
            Map(h => h.Empresa);
            Map(h => h.Ano);
            Map(h => h.Periodo);
        }
    }
}
