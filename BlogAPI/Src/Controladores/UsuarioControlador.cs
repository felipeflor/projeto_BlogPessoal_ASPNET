using BlogAPI.Src.Modelos;
using BlogAPI.Src.Repositorios;
using BlogAPI.Src.Repositorios.Implentacoes;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogAPI.Src.Controladores
{

    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos
        private readonly IUsuario _repositorio;
        #endregion

        #region Construtores
        public UsuarioControlador(IUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion


        #region Métodos
        [HttpGet("email/{emailUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);

            if (usuario == null) return NotFound(new { Mensagem = "Usuario não encontrado" });

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsynx([FromBody] Usuario usuario)
        {
            await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        #endregion
    }
}
