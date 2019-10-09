using AutoMapper;
using DotNetCoreWebAPI_3._0.Data;
using DotNetCoreWebAPI_3._0.Data.Models;
using DotNetCoreWebAPI_3._0.Data.Repositories;
using DotNetCoreWebAPI_3._0.DTO;
using DotNetCoreWebAPI_3._0.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreWebAPI_3._0.Services.Impl
{
    public class BeerService : IBeerService
    {
        private readonly IMapper _mapper;

        private readonly ApiDbContext _context;

        private readonly IBeerRepository _beerRepository;

        public BeerService(IMapper mapper, ApiDbContext context,  IBeerRepository beerRepository)
        {
            _mapper = mapper;
            _context = context;
            _beerRepository = beerRepository;
        }

        public List<BeerDTO> GetAll()
        {
            return _mapper.Map<List<BeerDTO>>(_beerRepository.Filter());
        }

        public BeerDTO GetOneBy(Func<Beer, bool> predicate)
        {
            return _mapper.Map<BeerDTO>(_beerRepository.Filter(predicate).SingleOrDefault());
        }

        public void Save(BeerDTO beerDTO)
        {
            //_context.Database.BeginTransaction();

            if (beerDTO.Id.HasValue)
            {
                var beerModel = _beerRepository.GetById(beerDTO.Id.Value);
                if (beerModel == null)
                {
                    //_context.Database.RollbackTransaction();
                    throw new NotFoundException("L'identifiant de la bière n'est pas valide!");
                }
                    
                beerModel.Name = beerDTO.Name;
                beerModel.Type = beerDTO.Type;

                _beerRepository.Edit(beerModel);
            }  
            else
            {
                var beerModel = new Beer()
                {
                    Id = null,
                    CreationDate = DateTime.Now,
                    Name = beerDTO.Name,
                    Type = beerDTO.Type
                };

                _beerRepository.Create(beerModel);
            }

            //_context.Database.CommitTransaction();
        }

        public void Delete(long id)
        {
            if (_beerRepository.GetById(id) == null)
                throw new NotFoundException("L'identifiant de la bière n'est pas valide!");

            _beerRepository.Delete(id);
        }
    }
}
