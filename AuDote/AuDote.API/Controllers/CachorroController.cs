using AuDote.Database.Models;
using AuDote.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuDote.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("Cadastro de Cachorros")]
    public class CachorrosController : ControllerBase
    {
        private readonly IRepository<Cachorro> _cachorroRepository;

        public CachorrosController(IRepository<Cachorro> cachorroRepository)
        {
            _cachorroRepository = cachorroRepository;
        }

        /// <summary>
        /// Endpoint responsável por inserir um cachorro
        /// </summary>
        /// <param name="cachorro"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Cachorro cachorro)
        {
            if (cachorro == null) // Adicione esta verificação para evitar nulos
            {
                return BadRequest("Cachorro não pode ser nulo.");
            }

            try
            {
                _cachorroRepository.Add(cachorro);
                return StatusCode(StatusCodes.Status201Created, cachorro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar cachorro.");
            }
        }

        /// <summary>
        /// Endpoint responsável por buscar todos os cachorros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var cachorros = _cachorroRepository.GetAll();
                return Ok(cachorros);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar os cachorros.");
            }
        }

        /// <summary>
        /// Endpoint responsável por buscar um cachorro pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(string id)
        {
            try
            {
                var cachorro = _cachorroRepository.GetById(id);

                if (cachorro == null)
                    return NotFound("Cachorro não encontrado.");

                return Ok(cachorro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar o cachorro.");
            }
        }

        /// <summary>
        /// Endpoint responsável por atualizar um cachorro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cachorro"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Update(string id, [FromBody] Cachorro cachorro)
        {
            try
            {
                var existingCachorro = _cachorroRepository.GetById(id);

                if (existingCachorro == null)
                    return NotFound("Cachorro não encontrado.");

                _cachorroRepository.Update(cachorro);
                return Ok("Cachorro atualizado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar o cachorro.");
            }
        }

        /// <summary>
        /// Endpoint responsável por deletar um cachorro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(string id)
        {
            try
            {
                var cachorro = _cachorroRepository.GetById(id);

                if (cachorro == null)
                    return NotFound("Cachorro não encontrado.");

                _cachorroRepository.Delete(cachorro);
                return Ok("Cachorro deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar o cachorro.");
            }
        }
    }
}
