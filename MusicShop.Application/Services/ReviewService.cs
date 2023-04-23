using AutoMapper;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Review;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Enums;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Services
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly UserData _userData;

        public ReviewService
        (
            IReviewRepository reviewRepository,
            IMapper mapper,
            UserData userData
        )
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userData = userData;
        }
        public async Task<Guid> Create(ReviewCreateDTO dto)
        {
            var entity = _mapper.Map<ReviewEntity>(dto);
            entity.UserId = _userData.Id;
            var result = await _reviewRepository.Create(entity);
            return result;
        }
         public async Task Update(ReviewUpdateDTO dto)
        {
            var existingEntity = await _reviewRepository.GetById(dto.Id);
            if(existingEntity == null)
            {
                throw new ReviewNotFoundException();
            }
            _mapper.Map(dto, existingEntity);
             await _reviewRepository.Update(existingEntity);
           
        }
        public async Task<ReviewOutputDTO> GetById(Guid id)
        {
            var entity = await _reviewRepository.GetById(id);
            if(entity == null)
            {
                throw new ReviewNotFoundException();
            }
            var result = _mapper.Map<ReviewOutputDTO>(entity);
            return result;
        }
        public async Task<PageModelDTO<ReviewListOutputDTO>> GetPageByProductId(Guid productId,PaginationDTO pagination)
        {
            var pages = await _reviewRepository.GetPageByProductId(productId, pagination);
            var result = _mapper.Map<PageModelDTO<ReviewListOutputDTO>>(pages);
            return result;
        }
        public async Task<PageModelDTO<ReviewListOutputDTO>> GetPageByUserId(PaginationDTO pagination)
        {
            var pages = await _reviewRepository.GetPageByUserId(_userData.Id, pagination);
            var result = _mapper.Map<PageModelDTO<ReviewListOutputDTO>>(pages);
            return result;
        }
        public async Task Delete(Guid id)
        {
            var entity = await _reviewRepository.GetById(id);
            if (entity != null)
               await _reviewRepository.Delete(entity);
        }
    }
}
