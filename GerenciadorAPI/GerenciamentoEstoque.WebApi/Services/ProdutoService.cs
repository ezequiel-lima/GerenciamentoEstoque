using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.WebApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IWriteRepository<Produto> _writeRepository;
        private readonly IReadRepository<Produto> _readRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IWriteRepository<Produto> writeRepository, IReadRepository<Produto> readRepository, IUnitOfWork unitOfWork)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            return await _readRepository.FindAll().ToListAsync();    
        }

        public async Task<ActionResult<Produto>> GetById(Guid id)
        {
            var result = await _readRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (result is null)
                return new StatusCodeResult(404);

            return result;
        }

        public async Task<ActionResult<Produto>> Create(Produto produto)
        {
            var result = new Produto(produto.Nome, produto.Descricao, produto.Preco);
            await _writeRepository.AddAsync(result);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<ActionResult<Produto>> Put(Guid id, Produto produto)
        {
            var result = _readRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (result is null)
                return new StatusCodeResult(404); 

            result.Alterar(produto);
            _writeRepository.Update(result);

            await _unitOfWork.CommitAsync();

            return result;
        }

        public async Task<ActionResult<Produto>> Delete(Guid id)
        {
            var result = _readRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (result is null)
                return new StatusCodeResult(404);

            _writeRepository.Delete(result);

            await _unitOfWork.CommitAsync();

            return result;
        }
    }
}