using AutoMapper;
using EFCoreReproduce.Entities;

namespace EFCoreReproduce;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CommandMappings();
        PaymentOrderMappings();
    }

    private void CommandMappings()
    {
        CreateMap<CommandAuditLogEntry, CommandView>()
            .ForMember(domain => domain.RelatedPaymentOrder, opt => opt.MapFrom(command => command.PaymentOrder))
            ;
    }

    public static MapperConfiguration DefaultMapperConfiguration() =>
        new(cfg => cfg.AddProfile<MapperProfile>());

    private void PaymentOrderMappings()
    {
        CreateMap<PaymentOrder, PaymentModel>()
            .ForMember(domain => domain.ValueDate, opt => opt.MapFrom(po => po.ValueDate.ToUIDateOnlyString()))
            ;

        // This context is captured and will be provided in call to ProjectTo -- https://docs.automapper.org/en/stable/Queryable-Extensions.html#parameterization
        DatabaseExtContext? Context = null;

        CreateMap<PaymentOrder, PaymentInformation>()
            .ForMember(domain => domain.ValueDate, opt => opt.MapFrom(po => po.ValueDate.ToString("dd-MM-yyyy")))
            ;
    }
}
