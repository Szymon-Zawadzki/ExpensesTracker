using AutoMapper;
using ExpensesTracker.Entities;
using ExpensesTracker.Interfaces;
using ExpensesTracker.Models.Resource;


namespace ExpensesTracker.Services
{
    public class ResourceService : IResourceServices
    {
        private readonly ExpensesDbContext _resourceDbContext;
        private readonly IMapper _mapper;
        public ResourceService(ExpensesDbContext incomingExpensesDbContext, IMapper mapper)
        {
            _resourceDbContext = incomingExpensesDbContext;
            _mapper = mapper;
        }

        public IEnumerable<ResourceDto> GetAll()
        {
            var resource = _resourceDbContext
                .Resource.ToList();
            var resourceDto = _mapper.Map<List<ResourceDto>>(resource);
            resourceDto.Sort(delegate (ResourceDto x, ResourceDto y) {
                return x.DateTime.CompareTo(y.DateTime);
            });
            return resourceDto;
        }

        public ResourceDto GetById(int id)
        {
            var resource = _resourceDbContext
                .Resource.FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return null;
            }

            var resourceDto = _mapper.Map<ResourceDto>(resource);
            return resourceDto;
        }

        public string Create(CreateResourceDto dto)
        {
            var resource = _mapper.Map<Resource>(dto);
            _resourceDbContext.Resource.Add(resource);
            _resourceDbContext.SaveChanges();

            return ("Resource has been added correctly");
        }

        public string DeleteById(int id)
        {
            var resource = _resourceDbContext
                .Resource
                .FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return null;
            }

            _resourceDbContext.Resource.Remove(resource);
            _resourceDbContext.SaveChanges();

            return ("Resource have been removed correctly");
        }

        public string Delete()
        {
            var resource = _resourceDbContext
                .Resource.ToList();

            if (resource == null)
            {
                return null;
            }

            _resourceDbContext.Resource.RemoveRange(resource);
            _resourceDbContext.SaveChanges();

            return ("All Resources has been removed correctly");
        }

        public string Update(UpdateResourceDto dto, int id)
        {
            var resource = _resourceDbContext
               .Resource
               .FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return null;
            }

            if (dto.DateTime != null)
            {
                resource.DateTime = dto.DateTime;
            }
            if (dto.Name != "string")
            {
                resource.Name = dto.Name;
            }
            if (dto.Description != "string")
            {
                resource.Description = dto.Description;
            }
            if (dto.Price != 0)
            {
                resource.Price = dto.Price;
                _resourceDbContext.SaveChanges();
            }

            return ("Resource have been updated correctly");
        }
    }
}
