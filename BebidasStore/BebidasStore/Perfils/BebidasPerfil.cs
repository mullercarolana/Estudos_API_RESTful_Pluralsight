using AutoMapper;

namespace BebidasStore.Perfils
{
    public class BebidasPerfil : Profile
    {
        public BebidasPerfil()
        {
            CreateMap<Entidades.Bebida, DTO.BebidaDTO>();
            CreateMap<DTO.BebidaParaCriacaoDTO, Entidades.Bebida>();
            CreateMap<DTO.BebidaParaAtualizacaoDTO, Entidades.Bebida>();
            CreateMap<Entidades.Bebida, DTO.BebidaParaAtualizacaoDTO>();

        }
    }
}
