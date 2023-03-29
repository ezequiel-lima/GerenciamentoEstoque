using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.WebApi.Services
{
    public class VendaService : IVendaService
    {
        private readonly IWriteRepository<Venda> _writeRepository;
        private readonly IReadRepository<Venda> _readRepository;
        private readonly IReadRepository<Produto> _readRepositoryProduto;
        private readonly IEstoqueService _estoqueService;
        private readonly IUnitOfWork _unitOfWork;

        public VendaService(IWriteRepository<Venda> writeRepository, IReadRepository<Venda> readRepository, IUnitOfWork unitOfWork, IReadRepository<Produto> readRepositoryProduto, IEstoqueService estoqueService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
            _readRepositoryProduto = readRepositoryProduto;
            _estoqueService = estoqueService;
        }

        public async Task<ActionResult<Venda>> Create(Venda venda)
        {
            var produto = await _readRepositoryProduto.FindByCondition(x => x.Id == venda.ProdutoId).FirstOrDefaultAsync();
            if (produto is null)
                return new StatusCodeResult(404);

            var result = new Venda(venda.ProdutoId, produto.Nome, DateTime.Now, venda.Quantidade);
            await _estoqueService.UpdateEstoqueQuantidade(result);
            await _writeRepository.AddAsync(result);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<Venda>>> GetAll()
        {
            return await _readRepository.FindAll().ToListAsync();
        }

        public async Task<ActionResult<Venda>> GetById(Guid id)
        {
            var result = await _readRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (result is null)
                return new StatusCodeResult(404);

            return result; 
        }
    }
}