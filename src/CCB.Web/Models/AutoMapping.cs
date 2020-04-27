using AutoMapper;

namespace CCB.Web.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Domain.Model.Extrato, Extrato>();
            CreateMap<Extrato, Domain.Model.Extrato>();
        }
    }
}