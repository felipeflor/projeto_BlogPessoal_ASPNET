using BlogAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogAPI.Src.Repositorios.Implentacoes
{
    public interface ITema
    { 
        Task<List<Tema>> PegarTodosTemasAsync();

        Task<Tema> PegarTemaPeloIdAsync(int id);
        Task NovoTemaAsync(Tema tema);
        Task AtualizarTemaAsync(Tema tema);
        Task DeletarTemaAsync(int id);

    }
}
