using System;
using System.Collections.Generic;
using AutoMapper;
using BebidasStore.DTO;
using BebidasStore.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace BebidasStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcasRepositorio _marcasRepositorio;
        private readonly IMapper _mapper;

        public MarcasController(IMarcasRepositorio marcasRepositorio, IMapper mapper)
        {
            _marcasRepositorio = marcasRepositorio ??
                throw new ArgumentNullException(nameof(marcasRepositorio));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarcaDTO>> ObterMarcas()
        {
            var marcasDoRepositorio = _marcasRepositorio.ObterMarcas();
            return Ok(_mapper.Map<IEnumerable<MarcaDTO>>(marcasDoRepositorio));
        }

        [HttpGet("{marcaId}")]
        public IActionResult ObterMarca(Guid marcaId)
        {
            var marcaDoRepositorio = _marcasRepositorio.ObterMarcaPorId(marcaId);

            if (marcaDoRepositorio == null)
                return NotFound();

            return Ok(_mapper.Map<MarcaDTO>(marcaDoRepositorio));
        }

        [HttpPost]
        public ActionResult<MarcaDTO> CriarMarcaDeBebida(MarcaParaManipulacaoDTO marcaDTO)
        {
            var marcaEntidade = _mapper.Map<Entidades.Marca>(marcaDTO);
            _marcasRepositorio.AdicionarMarca(marcaEntidade);
            _marcasRepositorio.Salvar();

            var marcaParaRetornar = _mapper.Map<MarcaDTO>(marcaEntidade);
            return Ok(marcaParaRetornar);
        }

        [HttpDelete("{marcaId}")]
        public ActionResult RemoverMarca(Guid marcaId)
        {
            var marcaDoRepositorio = _marcasRepositorio.ObterMarcaPorId(marcaId);

            if (marcaDoRepositorio == null)
                return NotFound();

            _marcasRepositorio.RemoverMarca(marcaDoRepositorio);
            _marcasRepositorio.Salvar();

            return NoContent();
        }
    }
}
