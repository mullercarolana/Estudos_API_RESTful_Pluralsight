using AutoMapper;

namespace BebidasStore.Perfils
{
    public class MarcasPerfil : Profile
    {
        public MarcasPerfil()
        {
            CreateMap<Entidades.Marca, DTO.MarcaDTO>();
            CreateMap<DTO.MarcaParaManipulacaoDTO, Entidades.Marca>();
        }
    }
}
