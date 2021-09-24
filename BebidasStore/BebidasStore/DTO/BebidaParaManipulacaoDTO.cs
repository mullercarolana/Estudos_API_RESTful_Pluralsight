using System.ComponentModel.DataAnnotations;

namespace BebidasStore.DTO
{
    public abstract class BebidaParaManipulacaoDTO
    {
        [Required(ErrorMessage = "Você deve inserir o nome da bebida.")]
        [MaxLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Você deve inserir a descrição da bebida.")]
        [MaxLength(100, ErrorMessage = "A descrição deve conter no máximo 50 caracteres.")]
        public virtual string Descricao { get; set; }
    }

    public class BebidaParaCriacaoDTO : BebidaParaManipulacaoDTO
    { }

    public class BebidaParaAtualizacaoDTO : BebidaParaManipulacaoDTO
    {
        [MaxLength(100, ErrorMessage = "Você deve inserir uma descrição")]
        public override string Descricao { get => base.Descricao; set => base.Descricao = value; }
    }
}
