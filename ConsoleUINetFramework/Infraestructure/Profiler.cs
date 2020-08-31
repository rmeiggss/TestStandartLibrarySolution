using AutoMapper;
using TestModels.Models;
using TestService.DTO;

namespace ConsoleUINetFramework.Infraestructure
{
    public class Profiler : Profile
    {
        public Profiler()
        {
            AllowNullDestinationValues = true;
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();

            CreateMap<cuenta_contable, CuentaContableDTO>()
                .ForMember(dest => dest.IdCuenta, opt => opt.MapFrom(src => src.cue_cont_id))
                .ForMember(dest => dest.NumeroCuenta, opt => opt.MapFrom(src => src.cue_cont_numero))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.cue_cont_descri))
                .ForMember(dest => dest.Analisis, opt => opt.MapFrom(src => src.cue_cont_analisis))
                .ForMember(dest => dest.Destino, opt => opt.MapFrom(src => src.cue_cont_destino))
                .ForMember(dest => dest.Nivel, opt => opt.MapFrom(src => src.cue_cont_nivel))
                .ForMember(dest => dest.Nivel, opt => opt.MapFrom(src => src.cue_cont_nivel))
                .ForMember(dest => dest.OtrosTributos, opt => opt.MapFrom(src => src.cue_bflag_otros_tributos))
                .ForMember(dest => dest.FlagBaseImponible, opt => opt.MapFrom(src => src.cue_bflag_base_imponible))
                .ForMember(dest => dest.FlagCentroCosto, opt => opt.MapFrom(src => src.cue_cont_cent_cost))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.usuario_registro))
                .ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.fecha_registro))
                .ForMember(dest => dest.TipoCuenta, opt => opt.MapFrom(src => src.cue_cont_tipo))
                .ReverseMap();

        }
    }
}
