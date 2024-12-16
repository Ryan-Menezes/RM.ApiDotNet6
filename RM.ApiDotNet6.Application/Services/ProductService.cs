using AutoMapper;
using RM.ApiDotNet6.Application.DTOs.Validations;
using RM.ApiDotNet6.Application.DTOs;
using RM.ApiDotNet6.Domain.Entities;
using RM.ApiDotNet6.Domain.Repositories;
using RM.ApiDotNet6.Application.Services.Interfaces;

namespace RM.ApiDotNet6.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("O objeto deve ser informado");

            var result = new ProductDTOValidator().Validate(productDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problemas de validação", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);

            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado!");

            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("O objeto deve ser informado");

            var result = new ProductDTOValidator().Validate(productDTO);

            if (!result.IsValid)
                return ResultService.RequestError("Problemas de validação", result);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);

            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            product = _mapper.Map<ProductDTO, Product>(productDTO, product);

            await _productRepository.UpdateAsync(product);

            return ResultService.Ok($"Produto do id:{productDTO.Id} foi atualizado");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            await _productRepository.DeleteAsync(product);

            return ResultService.Ok($"Produto do id:{id} foi deletado");
        }
    }
}
