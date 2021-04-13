namespace Course.Application.Common.BaseClass
{
    using AutoMapper;
    using global::Course.Application.Common.Interfaces;
    using global::Course.Domain.UnitOfWork;

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
