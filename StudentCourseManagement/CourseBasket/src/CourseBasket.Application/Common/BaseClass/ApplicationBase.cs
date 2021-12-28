using AutoMapper;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.UnitOfWork;

namespace CourseBasket.Application.Common.BaseClass
{
    public class ApplicationBase
    {

        public IUnitOfWork UnitOfWork { get; set; }
        public IConfigConstants ConfigConstants { get; set; }
        public IMapper Mapper { get; set; }

        public ApplicationBase(IConfigConstants configConstants, IUnitOfWork unitOfWork, IMapper mapper)
        {
            ConfigConstants = configConstants;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
