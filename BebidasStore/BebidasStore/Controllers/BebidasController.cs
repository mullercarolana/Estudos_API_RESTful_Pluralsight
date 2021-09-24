using System;
using System.Collections.Generic;
using AutoMapper;
using BebidasStore.DTO;
using BebidasStore.Repositorios;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BebidasStore.Controllers
{
    [ApiController]
    [Route("api/marcas/{marcaId}/bebidas")]
    public class BebidasController : ControllerBase
    {
        private readonly IBebidasRepositorio _bebidasRepositorio;
        private readonly IMarcasRepositorio _marcasRepositorio;
        private readonly IMapper _mapper;

        public BebidasController(IBebidasRepositorio bebidasRepositorio, IMarcasRepositorio marcasRepositorio, IMapper mapper)
        {
            _bebidasRepositorio = bebidasRepositorio ??
                throw new ArgumentNullException(nameof(bebidasRepositorio));
            _marcasRepositorio = marcasRepositorio ??
                throw new ArgumentNullException(nameof(marcasRepositorio));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BebidaDTO>> ObterTodasBebidasPorMarca(Guid marcaId)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidasDoRepositorio = _bebidasRepositorio.ObterBebidas(marcaId);
            return Ok(_mapper.Map<IEnumerable<BebidaDTO>>(bebidasDoRepositorio));
        }

        [HttpGet("{bebidaId}")]
        public ActionResult<BebidaDTO> ObterBebidaPorMarca(Guid bebidaId, Guid marcaId)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidasDoRepositorio = _bebidasRepositorio.ObterBebidaPorId(bebidaId, marcaId);

            if (bebidasDoRepositorio == null)
                return NotFound();

            return Ok(_mapper.Map<BebidaDTO>(bebidasDoRepositorio));
        }

        [HttpPost]
        public ActionResult<BebidaDTO> InserirBebidaPorMarca(Guid marcaId, BebidaParaCriacaoDTO bebidaDTO)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidaEntidade = _mapper.Map<Entidades.Bebida>(bebidaDTO);
            _bebidasRepositorio.AdicionarBebida(marcaId, bebidaEntidade);
            _bebidasRepositorio.Salvar();

            var bebidaParaRetornar = _mapper.Map<BebidaDTO>(bebidaEntidade);
            return Ok(bebidaParaRetornar);
        }

        [HttpPut("{bebidaId}")]
        public IActionResult AtualizarBebidaPorMarca(Guid marcaId, Guid bebidaId, 
            BebidaParaAtualizacaoDTO bebidaDTO)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidaPorMarcaDoRepositorio = _bebidasRepositorio.ObterBebidaPorId(marcaId, bebidaId);

            if (bebidaPorMarcaDoRepositorio == null)
            {
                var bebidaParaAdicionar = _mapper.Map<Entidades.Bebida>(bebidaDTO);
                bebidaParaAdicionar.Id = bebidaId;

                _bebidasRepositorio.AdicionarBebida(marcaId, bebidaParaAdicionar);
                _bebidasRepositorio.Salvar();

                var bebidaParaRetornar = _mapper.Map<BebidaDTO>(bebidaParaAdicionar);

                return Ok(bebidaParaRetornar);
            }

            _mapper.Map(bebidaDTO, bebidaPorMarcaDoRepositorio);

            _bebidasRepositorio.AtualizarBebida(bebidaPorMarcaDoRepositorio);

            _bebidasRepositorio.Salvar();
            return NoContent();
        }

        [HttpPatch("{bebidaId}")]
        public ActionResult ParcialAtualizacaoBebidaPorMarca(Guid marcaId, Guid bebidaId, 
            JsonPatchDocument<BebidaParaAtualizacaoDTO> patchDocument)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidaPorMarcaDoRepositorio = _bebidasRepositorio.ObterBebidaPorId(marcaId, bebidaId);

            if (bebidaPorMarcaDoRepositorio == null)
            {
                var bebidaDto = new BebidaParaAtualizacaoDTO();
                patchDocument.ApplyTo(bebidaDto, ModelState);

                if (!TryValidateModel(bebidaDto))
                    return ValidationProblem(ModelState);

                var bebidaParaAdicionar = _mapper.Map<Entidades.Bebida>(bebidaDto);
                bebidaParaAdicionar.Id = bebidaId;

                _bebidasRepositorio.AdicionarBebida(marcaId, bebidaParaAdicionar);
                _bebidasRepositorio.Salvar();

                var bebidaParaRetornar = _mapper.Map<BebidaDTO>(bebidaParaAdicionar);

                return Ok(bebidaParaRetornar);
            }

            var bebidaParaPatch = _mapper.Map<BebidaParaAtualizacaoDTO>(bebidaPorMarcaDoRepositorio);
            patchDocument.ApplyTo(bebidaParaPatch, ModelState);

            if (!TryValidateModel(bebidaParaPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(bebidaParaPatch, bebidaPorMarcaDoRepositorio);

            _bebidasRepositorio.AtualizarBebida(bebidaPorMarcaDoRepositorio);

            _bebidasRepositorio.Salvar();

            return NoContent();
        }

        [HttpDelete("{bebidaId}")]
        public ActionResult RemoverBebidaPorMarca(Guid marcaId, Guid bebidaId)
        {
            if (!_marcasRepositorio.MarcaExiste(marcaId))
                return NotFound();

            var bebidaPorMarcaDoRepositorio = _bebidasRepositorio.ObterBebidaPorId(marcaId, bebidaId);

            if (bebidaPorMarcaDoRepositorio == null)
                return NotFound();

            _bebidasRepositorio.RemoverBebida(bebidaPorMarcaDoRepositorio);
            _bebidasRepositorio.Salvar();

            return NoContent();
        }
    }
}
