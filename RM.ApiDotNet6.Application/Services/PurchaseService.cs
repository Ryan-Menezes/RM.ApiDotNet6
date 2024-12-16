using AutoMapper;
using RM.ApiDotNet6.Application.DTOs.Validations;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Application.Services.Interfaces;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;

namespace RM.ApiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository purchaseRepository, IPersonRepository personRepository, IProductRepository productRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _personRepository = personRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("O objeto deve ser informado");

            var result = new PurchaseDTOValidator().Validate(purchaseDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", result);

            var product = await _productRepository.GetByCodErpAsync(purchaseDTO.CodErp);

            if (product == null)
                return ResultService.Fail<PurchaseDTO>("Produto não encontrado!");

            var person = await _personRepository.GetByDocumentAsync(purchaseDTO.Document);

            if (product == null)
                return ResultService.Fail<PurchaseDTO>("Pessoa não encontrada!");

            var purchase = new Purchase(person.Id, product.Id);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;

            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();

            return ResultService.Ok<ICollection<PurchaseDetailDTO>>(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);

            if (purchase == null)
                return ResultService.Fail<PurchaseDetailDTO>("Compra não encontrada!");

            return ResultService.Ok(_mapper.Map<PurchaseDetailDTO>(purchase));
        }

        public async Task<ResultService> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("O objeto deve ser informado");

            var result = new PurchaseDTOValidator().Validate(purchaseDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", result);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);

            if (purchase == null)
                return ResultService.Fail("Compra não encontrada!");

            var product = await _productRepository.GetByCodErpAsync(purchaseDTO.CodErp);

            if (product == null)
                return ResultService.Fail<PurchaseDTO>("Produto não encontrado!");

            var person = await _personRepository.GetByDocumentAsync(purchaseDTO.Document);

            if (product == null)
                return ResultService.Fail<PurchaseDTO>("Pessoa não encontrada!");

            purchase.Edit(purchaseDTO.Id, person.Id, product.Id);

            await _purchaseRepository.UpdateAsync(purchase);

            return ResultService.Ok($"Compra do id:{purchaseDTO.Id} foi atualizada");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);

            if (purchase == null)
                return ResultService.Fail("Compra não encontrada!");

            await _purchaseRepository.DeleteAsync(purchase);

            return ResultService.Ok($"Compra do id:{id} foi deletada");
        }
    }
}
