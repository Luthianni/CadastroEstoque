using AutoMapper;
using CadastroEstoque.DTOs;
using CadastroEstoque.Interface;
using CadastroEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroEstoque.Service
{
    public class AtivoService : IAtivoService
    {
        private readonly IMapper mapper;
        private readonly IAtivoRepository repository;

        public AtivoService(IMapper mapper, IAtivoRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task AddAsync(AtivoDTO ativoDTO)
        {
            var entidade = mapper.Map<Ativo>(ativoDTO);           
            await repository.Adicionar(entidade);   
        }

        public async Task<IEnumerable<AtivoDTO>> GetAllAsync()
        {
            var ativos = await repository.ObterTodos();
            var ativosVM = mapper.Map<IEnumerable<AtivoDTO>>(ativos);

            return ativosVM;
        }

        public async Task<AtivoDTO> GetByIdAsync(Guid Id)
        {
            var ativo = await repository.Editar(Id);
            var entidade = mapper.Map<AtivoDTO>(ativo);
            return entidade;
        }

        public async Task<AtivoDTO> UpdateAsync(AtivoDTO ativo)
        {
            var UpdateAtivo = mapper.Map<Ativo>(ativo);
            await repository.Update(UpdateAtivo);
            var AtivoUpdate = mapper.Map<AtivoDTO>(UpdateAtivo);

            return AtivoUpdate;
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await repository.Delete(Id);
        }

        
    }
}
