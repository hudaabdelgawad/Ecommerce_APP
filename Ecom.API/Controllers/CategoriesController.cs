using AutoMapper;
using Ecom.Core.Dtos;

using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("get_all_categories")]
        public async Task<ActionResult> Get()
        {
            var allCategories = await _unitOfWork.CategoryRepository.GetAllAsync();
            if (allCategories is not null)
            {//create customize for return  response
                //var res = allCategories.Select(x => new CategoryDto
                //{
                //    Name=x.Name,
                //    Description=x.Description
                //}).ToList();
               //mapper
               var res=_mapper.Map<IReadOnlyList<Category>,IReadOnlyList<ListingCategoryDto>>(allCategories);
                return Ok(res);
            }
               
            return BadRequest("Not Found");
        }
        [HttpGet("get_category_byid /{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(id);
            if (category is not null)
            {
                //var newcategorydto = new ListingCategoryDto()
                //{
                //    Id=category.Id,
                //    Name=category.Name,
                //    Description=category.Description
                //};
                //mapper
                var res = _mapper.Map<Category, ListingCategoryDto>(category);
                return Ok(res);
            }
               
            return BadRequest($"Not Found This id[{id}]");
        }
       // [ValidateAntiForgeryToken]
        [HttpPost("add_new_category")]
        public async Task<ActionResult> Post(CategoryDto categorydto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var Newcategory = new Category
                    //{
                    //    Name = categorydto.Name,
                    //    Description = categorydto.Description
                    //};
                    var res =_mapper.Map<Category>(categorydto);
                    await _unitOfWork.CategoryRepository.AddAsync(res);
                    return Ok(categorydto);
                }
                return BadRequest(categorydto);


            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
           
        }
        [HttpPut("upade_exiting_category_by_id")]
        public async Task<ActionResult> Put(UpdatingCategoryDto categorydto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exitingCategore = await _unitOfWork.CategoryRepository.GetAsync(categorydto.Id);
                    if (exitingCategore is not null)
                    {//mapper
                        _mapper.Map(categorydto, exitingCategore);
                        //exitingCategore.Name = categorydto.Name;
                        //exitingCategore.Description = categorydto.Description;
                        await _unitOfWork.CategoryRepository.UpdateAsync(categorydto.Id,exitingCategore);
                        return Ok(categorydto);
                    }

                }
                return BadRequest($"Category Not Found,Id [{categorydto.Id}] Incorrect");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("delete_category_by_id/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exitingCategor = await _unitOfWork.CategoryRepository.GetAsync(id);
                   if(exitingCategor !=null)
                    {
                        //mapper
                        var res = _mapper.Map<Category, ListingCategoryDto>(exitingCategor);
                       await _unitOfWork.CategoryRepository.DeleteAsync(id);
                        return Ok(res);

                    }
                   
                }
                return BadRequest($" category not found of id equal [{id}]");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

           }

}
