using AutoMapper;

using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("get_all_products")]
        public async Task<ActionResult> Get()
        {
            var src = await _unitOfWork.ProductRepository.GetAllAsync(x => x.Category);
            if (src != null)
            {
                var result = _mapper.Map<List<ProductDto>>(src);
                return Ok(result);
            }
            return BadRequest("Not Found");
        }
        [HttpGet("get_product_by_id/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var src = await _unitOfWork.ProductRepository.GetByIdAsync(id, x => x.Category);
            if (src != null)
            {
                var result = _mapper.Map<ProductDto>(src);
                return Ok(result);
            }
            return BadRequest($"Not Found This id[{id}]");
        }
        [HttpPost("add_new_product")]
        public async Task<ActionResult> Post([FromForm] CreateProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ProductRepository.AddAsync(productDto);
                    // return Ok(productDto);
                    return res ? Ok(productDto) : BadRequest(res);

                }
                return BadRequest(productDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("update_exiting_product_by_id/{id}")]
        public async Task<ActionResult> Update([FromForm] UpdateProductDto dto, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ProductRepository.UpdateAsync(id, dto);
                    return res ? Ok(dto) : BadRequest();
                }
                return BadRequest(dto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_product/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ProductRepository.DeleteAsyncWithPicture(id);
                    return res? Ok(res):BadRequest(res);
                }
                return BadRequest("$ This is {id} Not Found");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
