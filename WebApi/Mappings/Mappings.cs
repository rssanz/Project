using AutoMapper;
using DataEntities.Domain;
using DataEntities.DTO;

namespace WebApi.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Rate, RateDTO>();
            CreateMap<Transaction, TransactionDTO>();
        }
    }
}
